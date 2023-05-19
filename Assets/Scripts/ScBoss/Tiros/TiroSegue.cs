using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroSegue : MonoBehaviour
{
    public int XouY = 1; //1 é X, 2 é Y
    float spawnTime = 6;
    public GameObject Laser;
    public GameObject LaserForte;
    bool parar = false;
    


    void Update()
    {
        if (Time.time > spawnTime)
            {
                StartCoroutine(Disparar());
                spawnTime = Time.time + 17;
            }

        if (parar == false)
        {
            if(XouY == 2)
                transform.position = Vector3.MoveTowards(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), new Vector3(this.transform.position.x, PC.PCpassar.position.y, this.transform.position.z), 5f * Time.deltaTime);
            if(XouY == 1)
                transform.position = Vector3.MoveTowards(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), new Vector3(PC.PCpassar.transform.position.x, this.transform.position.y, this.transform.position.z), 5f * Time.deltaTime);
            if(BossFase2.vidaTotal <= 50)
            {
                if(XouY == 2)
                    transform.position = Vector3.MoveTowards(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), new Vector3(this.transform.position.x, PC.PCpassar.position.y-0.5f, this.transform.position.z), 5f * Time.deltaTime);
                if(XouY == 1)
                    transform.position = Vector3.MoveTowards(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), new Vector3(PC.PCpassar.transform.position.x-0.5f, this.transform.position.y, this.transform.position.z), 5f * Time.deltaTime);
                if(XouY == 4)
                    transform.position = Vector3.MoveTowards(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), new Vector3(this.transform.position.x, PC.PCpassar.position.y+0.5f, this.transform.position.z), 5f * Time.deltaTime);
                if(XouY == 3)
                    transform.position = Vector3.MoveTowards(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), new Vector3(PC.PCpassar.transform.position.x+0.5f, this.transform.position.y, this.transform.position.z), 5f * Time.deltaTime);
            }
        }
    }

    IEnumerator Disparar()
    {
        Laser.SetActive(true);
        BossFase2.ativado = false;
        yield return new WaitForSeconds(4);
        parar = true;
        yield return new WaitForSeconds(2.5f);
        Laser.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        LaserForte.SetActive(true);
        yield return new WaitForSeconds(6);
        BossFase2.ativado = true;
        LaserForte.SetActive(false);
        parar = false;
    }
}

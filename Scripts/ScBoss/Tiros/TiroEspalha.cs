using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroEspalha : MonoBehaviour
{
    float velRotacao = 20;
    float vel = 0.25f;
    float spawnTime = 6;
    public static float rotacao1;

    Vector3 direcaoRotacao = new Vector3(0, 0, 10);
    public GameObject TiroLerdoEspalha;

    void Start()
    {
        StartCoroutine(Spawn());  //Autodestrói após X seg
    }


    void Update()
    {
        if (Time.time > spawnTime)
        {
            StartCoroutine(spawnTiro());
            spawnTime = Time.time + Random.Range(2, 6)/2;
        }

        transform.position = Vector3.MoveTowards(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), new Vector3(this.transform.position.x, 6.3f, 0), vel * Time.deltaTime);  //Move objeto da PosAtual para centro

        if (transform.position == (new Vector3(this.transform.position.x, 6.3f, this.transform.position.z)))
            Destroy(this.gameObject);

        transform.Rotate(velRotacao * direcaoRotacao * Time.deltaTime);
    }


    IEnumerator spawnTiro()
    {
        rotacao1 = Random.Range(1, 361);
        Instantiate(TiroLerdoEspalha, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(0.01f);
        
        rotacao1 += 72;
        Instantiate(TiroLerdoEspalha, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(0.01f);
        
        rotacao1 += 72;
        Instantiate(TiroLerdoEspalha, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(0.01f);
        
        rotacao1 += 72;
        Instantiate(TiroLerdoEspalha, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(0.01f);
        
        rotacao1 += 72;
        Instantiate(TiroLerdoEspalha, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(0.01f);
    }


    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(60);  //10 Segundos
        Destroy (this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : MonoBehaviour
{
    private Camera mainCamera;
    public GameObject Escudo;
    public GameObject tiroPlayer;
    int vida1 = 0;
    bool comeco = true;
    public Transform SalvaPC;
    public static Transform PCpassar;
    bool liberaAtirar = true;
    int tempoAtirar;


    void Start()
    {
        mainCamera = Camera.main; //salva info camera
        PCpassar = SalvaPC; //passa transf do PC para TiroSegue
        checaVida();
        tempoAtirar = 1 - PlayerPrefs.GetInt("Cooldown", 0);
    }


    void Update()
    {            
        if (comeco)
        {
            transform.position = Vector3.MoveTowards(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), new Vector3(0, 0, 0), 1 * Time.deltaTime);  //Move objeto da PosAtual para centro

            if (transform.position == (new Vector3(0, 0, 0)))
                comeco = false;
        }
        else
        {
            if (Input.GetKey(KeyCode.W) && liberaAtirar == true)
            {
                Instantiate(tiroPlayer, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
                liberaAtirar = false;  //Cooldown

                StartCoroutine(cooldownTiro());  //Timer pra atirar
            }
            SegueMousePosição();
        }
    }




    void checaVida()
    {
        if (vida1 > 0)
            Escudo.SetActive(true);
        else
            Escudo.SetActive(false);

        if(vida1 < 0)
            Destroy(this.gameObject);
    }


    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Shield"))
        {
            vida1++;
            Destroy(other.gameObject);
        }

        checaVida();
    }

    
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("tiro"))
        {
            vida1--;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Inimigo"))
        {
            vida1 = -1;
            Destroy(this.gameObject);
        }
        checaVida();
    }


    IEnumerator cooldownTiro()
    {
        yield return new WaitForSeconds(tempoAtirar);
        liberaAtirar = true;
    }

    private void SegueMousePosição()
    {
        transform.position = PegaPosicaoMouse();
    }
    private Vector2 PegaPosicaoMouse()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}


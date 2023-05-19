using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segue : MonoBehaviour
{
    public Transform player;
    public Transform direcaoFim;

    private float vel = 2;

    bool olhando = false;
    bool seguindo = false;
    bool comeco = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());  //Autodestrói após X seg
        StartCoroutine(Rotina());  //Autodestrói após X seg
        
        direcaoFim = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() 
    {
        if (NaveMov.PCpassar == null)
        {
            player = direcaoFim;
        }
        else
            player = NaveMov.PCpassar;


        if (olhando)
        {
            transform.up = player.transform.position - transform.position;
        }
        else
        {
            if (seguindo)
            {
                transform.Translate (new Vector2 (0, vel * Time.deltaTime));
            }
            if (comeco)
            {
                transform.Translate (new Vector2 (0, vel * Time.deltaTime));
            }
        }
    }



    IEnumerator Rotina()
    {
        transform.Rotate(0, 0, 90);
        yield return new WaitForSeconds(0.7f);  //2 Segundos
        comeco = false;
        olhando = true;
        seguindo = false;
        yield return new WaitForSeconds(6);  //2 Segundos
        olhando = false;
        yield return new WaitForSeconds(2);  //2 Segundos
        seguindo = true;
        vel = 5f;
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(12);  //2 Segundos
        Destroy (this.gameObject);
    }




    void OnCollisionEnter2D(Collision2D other) //Colidir com tudo menos tiro e arma
    {
        if (!other.gameObject.CompareTag("Imortal"))
        {
            if (other.gameObject.CompareTag("tiro"))
            {
                Destroy (this.gameObject);
            }
            if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("tiro"))
            {
                Destroy (other.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) //Colidir com moedas e power ups
    {
        Destroy (other.gameObject);
    }
}

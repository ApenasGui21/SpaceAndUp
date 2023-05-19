using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtirandoIni : MonoBehaviour
{
    public float vel = 1f;

    void Start()
    {
        StartCoroutine(Spawn());  //Autodestrói após X seg
    }

    void Update()
    {
        transform.Translate (new Vector2 (0, vel * Time.deltaTime));  //Se movimenta para cima
    }


    void OnCollisionEnter2D(Collision2D other) 
    {
        if (!other.gameObject.CompareTag("Inimigo") && !other.gameObject.CompareTag("arma") && !other.gameObject.CompareTag("tiro") && !other.gameObject.CompareTag("obstaculo"))
        {
            Destroy (other.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        Destroy (other.gameObject);
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(10);  //2 Segundos
        Destroy (this.gameObject);
    }
}

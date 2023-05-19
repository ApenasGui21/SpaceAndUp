using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiroPC : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Spawn());  //Autodestrói após X seg
    }

    void Update()
    {
        transform.Translate (new Vector2 (0, 5 * Time.deltaTime));  //Se movimenta para cima
    }



    void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("ShieldInim"))
        {
            Destroy(this.gameObject);
        }
    }


    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2);  //2 Segundos
        Destroy (this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Spawn());  //Autodestrói após X seg
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("obstaculo"))
        {
            Destroy (other.gameObject);
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(1.5f);  //2 Segundos
        Destroy (this.gameObject);
    }
}

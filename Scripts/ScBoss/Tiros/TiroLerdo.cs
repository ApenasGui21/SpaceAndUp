using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroLerdo : MonoBehaviour
{
    public float vel = 2f;

    void Start()
    {
        StartCoroutine(Spawn());  //Autodestrói após X seg
    }

    void Update()
    {
        transform.Translate (new Vector2 (0, vel * Time.deltaTime));  //Se movimenta para cima
    }


    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(10);  //10 Segundos
        Destroy (this.gameObject);
    }
}

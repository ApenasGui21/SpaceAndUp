using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroRapido : MonoBehaviour
{
    public float vel = 10f;

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
        yield return new WaitForSeconds(3);  //10 Segundos
        Destroy (this.gameObject);
    }
}

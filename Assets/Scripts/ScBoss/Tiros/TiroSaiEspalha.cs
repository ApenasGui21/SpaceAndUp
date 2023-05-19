using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroSaiEspalha : MonoBehaviour
{
    float vel = 1f;
    float inclinacao;

    void Start()
    {
        StartCoroutine(Spawn());  //Autodestrói após X seg
        inclinacao = TiroEspalha.rotacao1;
        transform.Rotate(0, 0, inclinacao);
    }

    void Update()
    {
        transform.Translate (new Vector2 (0, vel * Time.deltaTime));  //Se movimenta para cima
    }


    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(8);  //10 Segundos
        Destroy (this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestroi : MonoBehaviour
{
    public float tempoDestoir = 1;

    void Start()
    {
        StartCoroutine(Destroi(tempoDestoir));
    }

    IEnumerator Destroi(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        Destroy (this.gameObject);
    }
}

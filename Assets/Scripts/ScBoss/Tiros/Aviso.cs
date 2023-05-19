using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aviso : MonoBehaviour
{
    public SpriteRenderer AvisoForma;
    public GameObject TiroLerdo;
    public GameObject TiroRapido;


    void Start()
    {
        StartCoroutine(Destroi());
    }


    IEnumerator Destroi()
    {
        StartCoroutine(pisca());
        yield return new WaitForSeconds(0.9f);
        StartCoroutine(pisca());
        yield return new WaitForSeconds(0.9f);
        StartCoroutine(pisca());
        yield return new WaitForSeconds(0.9f);
        StartCoroutine(pisca());
        yield return new WaitForSeconds(0.9f);
        StartCoroutine(pisca());
        yield return new WaitForSeconds(0.9f);

        Instantiate(TiroRapido, new Vector3(this.transform.position.x+0.4f, -4, 0), Quaternion.identity).transform.parent = this.transform;
        Instantiate(TiroRapido, new Vector3((this.transform.position.x-0.4f), -4, 0), Quaternion.identity).transform.parent = this.transform;

        yield return new WaitForSeconds(4); //Tempo do tiro
        Destroy (this.gameObject);
    }

    IEnumerator pisca()
    {
        AvisoForma.enabled = true;
        yield return new WaitForSeconds(0.6f);
        AvisoForma.enabled = false;
        yield return new WaitForSeconds(0.3f);
    }
}

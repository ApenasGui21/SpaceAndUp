using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMinera : MonoBehaviour
{
    float vel = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoDestruicao());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (new Vector2 (0, -vel * Time.deltaTime * NaveMov.velocidadeSuper));
    }

    IEnumerator AutoDestruicao()
    {
        yield return new WaitForSeconds(20);  //7 Segundos
        Destroy (this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("tiro") || other.gameObject.CompareTag("Inimigo") || other.gameObject.CompareTag("Player"))
        {
            Destroy (this.gameObject);
        }
        if (!other.gameObject.CompareTag("Inimigo") && !other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("tiro"))
            Destroy (other.gameObject);
    }
}
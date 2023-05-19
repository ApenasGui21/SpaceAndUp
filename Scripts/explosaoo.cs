using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosaoo : MonoBehaviour
{
    public bool menor = false;
    public float tempoExplosao = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(explodiu());
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if ((!other.gameObject.CompareTag("Player") || menor == true) && !other.gameObject.CompareTag("Imortal"))
        {
            Destroy (other.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Destroy (other.gameObject);
    }


    IEnumerator explodiu()
    {
        yield return new WaitForSeconds(tempoExplosao);
        Destroy (this.gameObject);
    }
}

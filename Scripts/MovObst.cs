using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovObst : MonoBehaviour
{
    public float vel = 3;
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
        yield return new WaitForSeconds(7);  //7 Segundos
        Destroy (this.gameObject);
    }
}

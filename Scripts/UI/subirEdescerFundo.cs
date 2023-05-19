using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class subirEdescerFundo : MonoBehaviour
{
    bool parou = false;
    public int direcao = 1;
    bool rodando = false;

    // Start is called before the first frame update
    void Start()
    {
        if (this.transform.position.y > 0 )
            direcao = -1;
    }

    void Update()
    {
        if(rodando == false)
            StartCoroutine(Parar());
        if(parou == false)
            transform.Translate (new Vector2 (0, direcao* 0.5f * Time.deltaTime));
    }

    IEnumerator Parar()
    {
        rodando = true;
        yield return new WaitForSeconds(3);
        parou = true;
    }
}

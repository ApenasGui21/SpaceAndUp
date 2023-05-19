using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFundo : MonoBehaviour
{
    float speed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (new Vector2 (0, -speed * Time.deltaTime * NaveMov.velocidadeSuper));

        if (transform.position.y < -25)
        {
            Reposition();
        }
    }

    void Reposition()
    {
        Vector2 vector = new Vector2(0, 47.75f); //mais
        transform.position = (Vector2)transform.position + vector;
    }
}

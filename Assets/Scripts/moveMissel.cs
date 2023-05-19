using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveMissel : MonoBehaviour
{
    public Vector3 screenPosition;
    public Vector3 worldPosition;

    Vector3 posAtual;
    public GameObject explodiu;


    void Start()
    {
        screenPosition = Input.mousePosition;  //Pega posiçãoo mouse
        screenPosition.z = 1;  //Faz o input não ser atrás da camera

        worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);  //Não lembro

        Vector2 direction = new Vector2(  //Rotação do objeto
            worldPosition.x - transform.position.x,
            worldPosition.y - transform.position.y
        );        

        transform.up = direction;  //Ajusta rotação do objeto
    }


    void Update()
    {
        posAtual = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);  //Define Posição Atual
        transform.position = Vector3.MoveTowards(posAtual, worldPosition, 20 * Time.deltaTime);  //Move objeto da PosAtual para onde clicou no começo

        if (worldPosition == posAtual)  //Checa se já cheegou no destino
        {
            Instantiate(explodiu, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);  //Cria explosão
            Destroy (this.gameObject); //Destroi missel
        }
    }
}

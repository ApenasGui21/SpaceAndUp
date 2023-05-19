using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossFase2 : MonoBehaviour
{
    bool comeco = true;
    bool primeira = true;
    public GameObject dispTiroX;
    public GameObject dispTiroY;
    public GameObject dispTiroX2;
    public GameObject dispTiroY2;
    public static bool ativado = true;

    public Image barraVida;
    public GameObject Vida;
    public static float vidaTotal = 50f;

    public GameObject escudao;
    public GameObject escudo1;
    public GameObject escudo2;
    public GameObject escudo3;
    public GameObject escudo4;
    public GameObject escudo5;
    int qualescudo = 0;
    bool passouLoop = true;

    void Update()
    {
        if (comeco)
        {
            transform.position = Vector3.MoveTowards(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), new Vector3(0, 4.2f, 0), 0.5f * Time.deltaTime);  //Move objeto da PosAtual para centro

            if (transform.position == (new Vector3(0, 4.2f, 0)))
                comeco = false;
        }
        else
        {
            if (primeira)
            {
                Vida.SetActive(true);
                Instantiate(dispTiroX, new Vector3(-2.14f, 2.92f, 0), Quaternion.identity);
                Instantiate(dispTiroY, new Vector3(-2.48f, 2.59f, 0), transform.rotation * Quaternion.Euler (0f, 0f, 90f));
                primeira = false;
                if (vidaTotal <= 50)
                {
                    Instantiate(dispTiroX2, new Vector3(-2.14f, 2.92f, 0), Quaternion.identity);
                    Instantiate(dispTiroY2, new Vector3(-2.48f, 2.59f, 0), transform.rotation * Quaternion.Euler (0f, 0f, 90f));
                }
            }
        }

        if (ativado == false)
        {
            if (passouLoop)
            {
                escudao.SetActive(false);
                qualescudo = Random.Range(1, 4); //1 até 3
                escudo1.SetActive(true);
                escudo5.SetActive(true);
                print(qualescudo);
                if(qualescudo != 1)
                    escudo2.SetActive(true);
                if(qualescudo != 2)
                    escudo3.SetActive(true);
                if(qualescudo != 3)
                    escudo4.SetActive(true);
                passouLoop = false;
            }
        }
        else
        {
            escudao.SetActive(true);
            escudo1.SetActive(false);
            escudo2.SetActive(false);
            escudo3.SetActive(false);
            escudo4.SetActive(false);
            escudo5.SetActive(false);
            passouLoop = true;
        }
    }

    void DanoRecebido(float dano)
    {
        vidaTotal -= dano;
        barraVida.fillAmount = vidaTotal / 100f;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("tiroPC"))
        {
            DanoRecebido(4);
            Destroy(other.gameObject);
        }
    }
}

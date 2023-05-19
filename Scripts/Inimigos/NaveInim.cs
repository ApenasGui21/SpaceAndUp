using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveInim : MonoBehaviour
{
    bool liberaTiro = false;
    bool entrar = true;
    int sair = 0;

    bool tempo = true;
    bool liberaAnim = false;
    bool anima1Vez = true;
    bool boostMorre = false;

    Animator animacao;
    public GameObject Tiro;
    public GameObject Arma;
    public GameObject Arma2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Delay());
        animacao = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(NaveMov.rapidao == true)
            boostMorre = true;

        if (liberaTiro) //Mecaniso de atirar
        {
            Instantiate(Tiro, new Vector3(Arma.transform.position.x,Arma.transform.position.y,Arma.transform.position.z), Quaternion.identity);  //Cria Tiro
            Instantiate(Tiro, new Vector3(Arma2.transform.position.x,Arma2.transform.position.y,Arma2.transform.position.z), Quaternion.identity);  //Cria Tiro2

            liberaTiro = false;  //Cooldown
            StartCoroutine(Delay());  //Timer pra atirar
        }

        if(entrar)
        {
            if(Randomizador() < 6) //Começa vendo se entra pela Esq ou Dir
            {
                animacao.SetBool("SubDir", true);
            } else {
                animacao.SetBool("SubEsq", true);
            }
            entrar = false; //Não entra mais nesse if
        }
        else
        {
            animacao.SetBool("SubEsq", false); //Desativa por precaução
            animacao.SetBool("SubDir", false); //Testar se da pra tirar!!!
            if (tempo)
            {
                StartCoroutine(Tempo()); //Tempo entre fases
            }
            if(liberaAnim)
            {
                if (anima1Vez) //Desativa animações para resetar
                {  
                    animacao.SetBool("EsqTUDO", false);
                    animacao.SetBool("DirTUDO", false);
                    animacao.SetBool("Esq1", false);
                    animacao.SetBool("Dir1", false);
                    animacao.SetBool("Esq2", false);
                    animacao.SetBool("Dir2", false);
                    anima1Vez = false;
                }

                if(Randomizador() < 6) //Escolha das anim no Animator
                {
                    animacao.SetBool("EsqTUDO", true); //Escolha de cima das animações (+ ou -)
                    animacao.SetBool("DirTUDO", true);
                    animacao.SetBool("Dir2", true);
                } else {
                    animacao.SetBool("Esq1", true); //Escolha de baixo das animações (+ ou -)
                    animacao.SetBool("Dir1", true);
                    animacao.SetBool("Esq2", true);
                }
                
                liberaAnim = false; //Espera para tempo deixar sortear de novo
                tempo = true; //Faz tempo contar de novo
                anima1Vez = true;
            }
            if(sair >= 6)
            {
                animacao.SetBool("Dir1", true); //Habilita sempre ir pro meio quando passar desse numero de repetições
                animacao.SetBool("Esq1", true);
                animacao.SetBool("Sair", true);
            }
        }
    }



    IEnumerator Delay() //Cooldown atirar
    {
        yield return new WaitForSeconds(5);  //5 Segundos
        if(boostMorre == false)
            liberaTiro = true;
    }

    IEnumerator Tempo() //Randomiza numero para sua ação
    {
        tempo = false;
        yield return new WaitForSeconds(5);  //5 Segundos
        liberaAnim = true;
    }

    int Randomizador() //Randomiza numero para sua ação
    {
        sair++; //Contador para sair da tela
        return (Random.Range(0, 11)); //Num de 1 a 10
    }



    void OnCollisionEnter2D(Collision2D other) //Colidir com tudo menos tiro e arma
    {
        if (!other.gameObject.CompareTag("tiro") && !other.gameObject.CompareTag("arma") && !other.gameObject.CompareTag("Kill") && !other.gameObject.CompareTag("Imortal"))
        {
            Destroy (other.gameObject);
        }
        if (other.gameObject.CompareTag("Kill")) //Colidir com bloco para autodestruir
        {
            Destroy (other.gameObject);
            Destroy (this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //Colidir com moedas e power ups
    {
        Destroy (other.gameObject);
    }
}

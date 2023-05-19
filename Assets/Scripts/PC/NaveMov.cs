using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NaveMov : MonoBehaviour
{
    private Camera mainCamera;

    [Header("Próprio PC")]
    private Rigidbody2D RBnave;
    public Transform PC;
    public GameObject Escudo;
    public static Transform PCpassar;

    int i = 0;
    int vida = 0;
    int vidaSalva;
    int poder = 0;
    int move = 0;
    bool dash;
    bool rodando = false;
    bool rodando2 = true;
    bool liberaTiro = false;
    bool jaComecou = true;
    int posicao = 0;
    
    public static int velocidadeSuper = 1;
    public static bool rapidao = false;
    public static bool comeca = false;
    public static bool go = false;


    [Header("Relacionados")]
    public GameObject explodir;
    public GameObject tiroSegue;


    [Header("Outros Objetos")]
    public TextMeshProUGUI textComecar;
    public GameObject cinematica;
    public GameObject BtnComeco;

    public static int numeroDeMoedas;
    bool fim = false;


    void Start()
    {
        posicao = 0;
        mainCamera = Camera.main; //salva info camera
        RBnave = gameObject.GetComponent<Rigidbody2D>(); //pega RB nave

        PCpassar = PC; //Salva obj PC para .... (?)
    }


    void Update()
    {
        if (vida > 0)
            Escudo.SetActive(true);
        else
            Escudo.SetActive(false);

        if (go) //Clica Reiniciar
        {
            vida = PlayerPrefs.GetInt("Escudo", 0); //Vida do Player
            checaMissoes();
            dash = true;

            go = false;
            comeca = true;
        }

        if(comeca == false)
        {
            vida = PlayerPrefs.GetInt("Escudo", 0); //Vida do Player
            checaMissoes();
            dash = true;
            
            Time.timeScale = 0f;
            textComecar.enabled = true;
            BtnComeco.SetActive(true);
            GameOver.UIjogando.SetActive(false);
        }
        else
        {
            if (PlayerPrefs.GetInt("Dash", 0) > 0 && dash == true)
                StartCoroutine(SuperRapido(PlayerPrefs.GetInt("Dash", 0)*2) );

            textComecar.enabled = false;
            BtnComeco.SetActive(false);


            if (poder == 0 && ScoreManager.dificuldade < 7 && ScoreManager.dificuldade > 0)  //Sem poder, segue mouse, normal
            {
                //SegueMousePosição();
                mudaPosicao();
                print("LIBERADO");
            }
            else if (poder == 1) //Explosão
            {
                print("Explosao");
                PowerUpExplosao();
            } 
            else if (poder == 2) //Dash
            {
                print("Dash");
                StartCoroutine(SuperRapido(2));
            }  
            else if (poder == 3) //Resfriamento
            {
                print("Resfriamento");
                StartCoroutine(Resfriamento());
            } 
            else if (poder == 4) //Tank
            {
                print("Tank");
                StartCoroutine(Tank());
            }

            
            

            if (jaComecou) //Entra toda vez que começa
            {
                Time.timeScale = 1f;
                GameOver.UIjogando.SetActive(true);
                jaComecou = false;
            }


            if (ScoreManager.dificuldade == 7)
            {
                transform.position = Vector3.MoveTowards(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), new Vector3(0, 0, 0), 1 * Time.deltaTime);  //Move objeto da PosAtual para centro
                if (fim == false)
                {
                    Instantiate(cinematica, new Vector3(0, -5.89f, 0), Quaternion.identity);
                    Instantiate(cinematica, new Vector3(0, 5.89f, 0), Quaternion.identity);
                    fim = true;
                }
            }

            if (ScoreManager.dificuldade == 8)
            {
                transform.Translate (new Vector2 (0, 2 * Time.deltaTime));
            }
        }
    }


    //Movimentação
    private void mudaPosicao()
    {
        if(Input.GetKeyDown(KeyCode.A))
            moveEsq();
        if(Input.GetKeyDown(KeyCode.D))
            moveDir();
    }

    public void moveEsq()
    {
        if (posicao > -2)
        {
            print("Esq");
            Vector3 lugarAtual = new Vector3(this.transform.position.x-1, this.transform.position.y, 0);
            transform.position = lugarAtual;
            posicao -= 1;
        }
    }

    public void moveDir()
    {
        if (posicao < +2)
        {
            print("Dir");
            Vector3 lugarAtual = new Vector3(this.transform.position.x+1, this.transform.position.y, 0);
            transform.position = lugarAtual;
            posicao += 1;
        }
    }

    private void SegueMousePosição()
    {
        transform.position = PegaPosicaoMouse();
    }

    private Vector2 PegaPosicaoMouse()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }



    //EXPLOSAO
    void PowerUpExplosao()
    {
        if (Input.GetKey(KeyCode.Mouse0) && liberaTiro == true)
            StartCoroutine(TiroMissel());

        if((i == 4 || i == 0) && rodando2)
            StartCoroutine(explosao());
        if (rodando && i <= 3)
        {
            rodando = false;
            StartCoroutine(moverSozinho());
            i++;
        }
        transform.Translate (new Vector2 (move * Time.deltaTime, 0));
    }

    IEnumerator moverSozinho()
    {
        move = 1;
        yield return new WaitForSeconds(2.2f);
        move = -1;
        yield return new WaitForSeconds(4.5f); 
        move = 1;
        yield return new WaitForSeconds(2.3f);
        rodando = true;
        rodando2 = true;
    }

    IEnumerator explosao()
    {
        move = 0;
        liberaTiro = false;
        rodando2 = false;
        transform.position = new Vector3(0, -2, 0);
        RBnave.isKinematic = true;
        Instantiate(explodir, new Vector3(0, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(2);
        RBnave.isKinematic = false;
        liberaTiro = true;
        rodando = true;
        if(i == 4)
        {
            poder = 0;
            i = 0;
            rodando = false;
            rodando2 = true;
            liberaTiro = false;
        }   
    }

    IEnumerator TiroMissel()
    {
        liberaTiro = false;
        Instantiate(tiroSegue, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        if(i >= 1 && i < 4)
            liberaTiro = true;
    }


    //DASH
    IEnumerator SuperRapido(int superRapido)
    {
        rapidao = true;
        dash = false;
        poder = 0;
        vidaSalva = vida;
        vida = 10000;
        velocidadeSuper = 10;

        yield return new WaitForSeconds(superRapido);
        velocidadeSuper = 1;
        rapidao = false;

        yield return new WaitForSeconds(2); //tempo invulneravel
        vida = vidaSalva;
    }


    //TIRO ILIMITADO
    IEnumerator Resfriamento()
    {
        poder = 0;
        Atirando.liberaAtirar = true;
        Atirando.tempoAtirar -= 3;
        yield return new WaitForSeconds(30);
        Atirando.tempoAtirar += 3;
    }


    //TANK
    IEnumerator Tank()
    {   
        poder = 0;
        vidaSalva = vida;
        vida = 10000;
        yield return new WaitForSeconds(10);
        vida = vidaSalva;
    }





    void checaMissoes()
    {
        Missoes.missaoTotal = PlayerPrefs.GetInt("Missao1Panel", 1) * PlayerPrefs.GetInt("Missao2Panel", 1)* PlayerPrefs.GetInt("Missao3Panel", 1);
    }




    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("obstaculo") || other.gameObject.CompareTag("Inimigo"))
        {
            if (vida == 0)
            {
                Destroy (this.gameObject); 
            } else {
                vida--;
                Destroy (other.gameObject);  //ADICIONAR ANIMAÇÃO
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("powerUP"))
        {
            poder = Random.Range(1, 5); //1 ou 2 ou 3 ou 4
            Destroy (other.gameObject);
        }
        if (other.gameObject.CompareTag("moeda"))
        {
            NaveMov.numeroDeMoedas++;
            Destroy (other.gameObject);
            PlayerPrefs.SetInt("Missao6", (PlayerPrefs.GetInt("Missao6", 0)+1)); //Missao6
        }
        if (other.gameObject.CompareTag("moedaAst"))
        {
            NaveMov.numeroDeMoedas += 5;
            Destroy (other.gameObject);
        }
        if (other.gameObject.CompareTag("moedaDev"))
        {
            NaveMov.numeroDeMoedas += 200;
            Destroy (other.gameObject);
        }
    }

    public void Comecando()
    {
        comeca = true;
    }
}

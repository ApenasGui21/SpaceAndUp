using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirando : MonoBehaviour
{
    public static bool liberaAtirar = true;
    public static int tempoAtirar = 10;

    public GameObject Tiro;
    public GameObject arma;
    SpriteRenderer Nave;
    Rigidbody2D RBnave;

    
    // Start is called before the first frame update
    void Start()
    {
        RBnave = gameObject.GetComponent<Rigidbody2D>();
        Nave = GetComponent<SpriteRenderer>();

        tempoAtirar = 10 - PlayerPrefs.GetInt("Cooldown", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("PowerUp", 0) == 0)
        {
            if(Input.GetKey(KeyCode.W) && liberaAtirar == true && PlayerPrefs.GetInt("SabeAtirar", 0) >= 1 && AtirarCooldown.rodando == false)  //ATACAR
            {
                Instantiate(Tiro, new Vector3(arma.transform.position.x,arma.transform.position.y,arma.transform.position.z), Quaternion.identity);  //Cria Tiro

                liberaAtirar = false;  //Cooldown

                StartCoroutine(cooldownTiro());  //Timer pra atirar
            }
        }
        if(PlayerPrefs.GetInt("PowerUp", 0) == 1)
        {
            if(Input.GetKey(KeyCode.W) && liberaAtirar == true && PlayerPrefs.GetInt("SabeIntang", 0) >= 1)  //ATACAR
            {
                RBnave.isKinematic = true;
                Nave.color = new Color (255, 255, 255, 0.5f); 

                liberaAtirar = false;  //Cooldown

                StartCoroutine(Intangivel());
                StartCoroutine(cooldownTiro());  //Timer pra atirar
            }
        }
    }


    IEnumerator cooldownTiro()
    {
        yield return new WaitForSeconds(tempoAtirar);
        liberaAtirar = true;
    }

    IEnumerator Intangivel()
    {
        yield return new WaitForSeconds(PlayerPrefs.GetInt("SabeIntang", 0));
        RBnave.isKinematic = false;
        Nave.color = new Color (255, 255, 255, 1);
    }
}

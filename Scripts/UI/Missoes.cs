using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Missoes : MonoBehaviour
{
    public static bool missao1 = false; //Checa as missões em NaveMov
    public static bool missao2 = false; //No inicio de qualquer partida
    public static bool missao3 = false; //Salva num da missao na variavel
    public static int missaoTotal;

    public TextMeshProUGUI Txt1;
    public TextMeshProUGUI Txt2;
    public TextMeshProUGUI Txt3;

    public GameObject Botao1;
    public GameObject Botao2;
    public GameObject Botao3;



    void Start()
    {
        if (PlayerPrefs.GetInt("Missao1Panel", 0) == 0)
            PlayerPrefs.SetInt("Missao1Panel", 2);
        if (PlayerPrefs.GetInt("Missao2Panel", 0) == 0)
            PlayerPrefs.SetInt("Missao2Panel", 3);
        if (PlayerPrefs.GetInt("Missao3Panel", 0) == 0)
            PlayerPrefs.SetInt("Missao3Panel", 5);

        ImprimeMissoes(Txt1, PlayerPrefs.GetInt("Missao1Panel"));
        ImprimeMissoes(Txt2, PlayerPrefs.GetInt("Missao2Panel"));
        ImprimeMissoes(Txt3, PlayerPrefs.GetInt("Missao3Panel"));

        Botao1.SetActive(false);
        Botao2.SetActive(false);
        Botao3.SetActive(false);
    }

    void Update()
    {
        if (missao1 == true)
        {
            missao1 = false;
            Botao1.SetActive(true);
            print("btn1");
        }

        if (missao2 == true)
        {
            missao2 = false;
            Botao2.SetActive(true);
            print("btn2");
        }

        if (missao3 == true)
        {
            missao3 = false;
            Botao3.SetActive(true);
        }
    }


    void ImprimeMissoes(TextMeshProUGUI Nmissao, int prefs)
    {
        if (prefs == 2)
        {
            Nmissao.text = "Dispare contra 20 asteroides ("+PlayerPrefs.GetInt("Missao1", 0)+"/20)";
        } else 
        if (prefs == 3)
        {
            Nmissao.text = "Percorra 1000 km em uma partida";
        } else 
        if (prefs == 5)
        {
            Nmissao.text = "Sobreviva por 500 km seguidos sem usar a habilidade especial";
        } else 
        if (prefs == 7)
        {
            Nmissao.text = "Use a habilidade especial 10 vezes ("+PlayerPrefs.GetInt("Missao4", 0)+"/10)";
        } else 
        if (prefs == 11)
        {
            Nmissao.text = "Destrua 3 naves inimigas ("+PlayerPrefs.GetInt("Missao5", 0)+"/3)";
        } else 
        if (prefs == 13)
        {
            Nmissao.text = "Pegue 20 ou mais esmeraldas em uma partida";
        }
    }



    int maiorValorMissao(int maior = 0)
    {
        if (PlayerPrefs.GetInt("Missao1Panel") > maior)
            maior = PlayerPrefs.GetInt("Missao1Panel");
        if (PlayerPrefs.GetInt("Missao2Panel") > maior)
            maior = PlayerPrefs.GetInt("Missao2Panel");
        if (PlayerPrefs.GetInt("Missao3Panel") > maior)
            maior = PlayerPrefs.GetInt("Missao3Panel");
        return maior;
    }

    public int ProximaMissao(int maior = 0)
    {
        maior = maiorValorMissao();
        if(maior == 5)
        {
            PlayerPrefs.SetInt("Missao4", 0);
            return 7;
        }
        if(maior == 7)
        {
            PlayerPrefs.SetInt("Missao5", 0);
            return 11;
        }
        if(maior == 11)
        {
            PlayerPrefs.SetInt("Missao6", 0);
            return 13;
        }
        return 1;
    }


    public void Btn1()
    {
        PlayerPrefs.SetInt("Missao1Panel", ProximaMissao());
        Botao1.SetActive(false);
        ImprimeMissoes(Txt1, PlayerPrefs.GetInt("Missao1Panel"));
    }

    public void Btn2()
    {
        PlayerPrefs.SetInt("Missao2Panel", ProximaMissao());
        Botao2.SetActive(false);
        ImprimeMissoes(Txt2, PlayerPrefs.GetInt("Missao2Panel"));
    }

    public void Btn3()
    {
        PlayerPrefs.SetInt("Missao3Panel", ProximaMissao());
        Botao3.SetActive(false);
        ImprimeMissoes(Txt3, PlayerPrefs.GetInt("Missao3Panel"));
    }
}   //Terminei o botao coletar, fazer nos outros

/*
Missao1
    Dispare contra X asteroides
    Pega info de moveTiro.cs

Missao2
    Alcance a pontuação X
    Pega info de GameOver.cs

Missao3
    Sobreviva por X (500) km sem usar a habilidade especial
    Pega info de ScoreManager.cs e AtirarCooldown.cs

Missao4
    Use a habilidade especial X vezes
    Pega info de AtirarCooldown.cs

Missao5
    Destrua X naves inimigas
    Pega info de moveTiro.cs

Missao6
    Pegue X esmeraldas em uma partida
    Pega info de NaveMov.cs e GameOver.cs
*/
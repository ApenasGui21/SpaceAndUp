using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopPanel : MonoBehaviour
{
    private int nivel;
    
    int precoPU1 = 50;
    int precoPU2 = 75;
    int precoPU3 = 100;
    int precoPU4 = 100;
    int precoPU5 = 100;

    public TextMeshProUGUI TXTpreco1;
    public TextMeshProUGUI TXTpreco2;
    public TextMeshProUGUI TXTpreco3;
    public TextMeshProUGUI TXTpreco4;
    public TextMeshProUGUI TXTpreco5;


    public TextMeshProUGUI moedasTotal;
    public static int numMoedas;
    

    // Start is called before the first frame update
    void Start()
    {
        numMoedas = PlayerPrefs.GetInt("NumeroDeMoedas");
        moedasTotal.text = numMoedas.ToString();

        AtualizaPreco(TXTpreco1, precoPU1, "SabeAtirar", 5);
        AtualizaPreco(TXTpreco2, precoPU2, "SabeIntang");
        AtualizaPreco(TXTpreco3, precoPU3, "Escudo");
        AtualizaPreco(TXTpreco4, precoPU4, "Dash");
        AtualizaPreco(TXTpreco5, precoPU5, "Cooldown");
    }


    public void PowerUp1 () //ATIRAR OK
    {
        nivel = PlayerPrefs.GetInt("SabeAtirar", 0);
        if (nivel == 0)
        {
            partePreco(precoPU1, "SabeAtirar");
            if(PlayerPrefs.GetInt("SabeAtirar", 0) == 0)
                PlayerPrefs.SetInt("PowerUp", 1);
            else if(PlayerPrefs.GetInt("SabeIntang", 0) == 0)
                PlayerPrefs.SetInt("PowerUp", 0);
        } else if (nivel == 1)
        {
            partePreco(precoPU1*2, "SabeAtirar");
        } else if (nivel == 2)
        {
            partePreco(precoPU1*3, "SabeAtirar");
        } else if (nivel == 3)
        {
            partePreco(precoPU1*4, "SabeAtirar");
        } else if (nivel == 4)
        {
            partePreco(precoPU1*5, "SabeAtirar");
        } else
            print("Nivel Máx!");
        AtualizaPreco(TXTpreco1, precoPU1, "SabeAtirar", 5);
    }
    


    public void PowerUp2 ()  //INTANGIBILIDADE OK
    {
        nivel = PlayerPrefs.GetInt("SabeIntang", 0);
        if (nivel == 0)
        {
            partePreco(precoPU2, "SabeIntang");
            if(PlayerPrefs.GetInt("SabeAtirar", 0) == 0)
                PlayerPrefs.SetInt("PowerUp", 1);
            else if(PlayerPrefs.GetInt("SabeIntang", 0) == 0)
                PlayerPrefs.SetInt("PowerUp", 0);
        } else if (nivel == 1)
        {
            partePreco(precoPU2*2, "SabeIntang");
        } else if (nivel == 2)
        {
            partePreco(precoPU2*3, "SabeIntang");
        } else
            print("Nivel Máx!");
        AtualizaPreco(TXTpreco2, precoPU2, "SabeIntang");
    }



    public void PowerUp3 ()  //ESCUDO OK
    {
        nivel = PlayerPrefs.GetInt("Escudo", 0);
        if (nivel == 0)
        {
            partePreco(precoPU3, "Escudo");
        } else if (nivel == 1)
        {
            partePreco(precoPU3*2, "Escudo");
        } else if (nivel == 2)
        {
            partePreco(precoPU3*3, "Escudo");
        } else
            print("Nivel Máx!");
        AtualizaPreco(TXTpreco3, precoPU3, "Escudo");
    }



    public void PowerUp4 ()  //COMEÇO RÁPIDO OK
    {
        nivel = PlayerPrefs.GetInt("Dash", 0);
        if (nivel == 0)
        {
            partePreco(precoPU4, "Dash");
        } else if (nivel == 1)
        {
            partePreco(precoPU4*2, "Dash");
        } else if (nivel == 2)
        {
            partePreco(precoPU4*3, "Dash");
        } else
            print("Nivel Máx!");
        AtualizaPreco(TXTpreco4, precoPU4, "Dash");
    }



    public void PowerUp5 ()  //COOLDOWN GERAL OK
    {
        nivel = PlayerPrefs.GetInt("Cooldown", 0);
        if (nivel == 0)
        {
            partePreco(precoPU5, "Cooldown");
        } else if (nivel == 1)
        {
            partePreco(precoPU5*2, "Cooldown");
        } else if (nivel == 2)
        {
            partePreco(precoPU5*3, "Cooldown");
        } else
            print("Nivel Máx!");
        AtualizaPreco(TXTpreco5, precoPU5, "Cooldown");
    }




    void partePreco(int custo, string tipoUpgrade)
    {
        if(custo <= numMoedas) //Checa se pode comprar
        {
            print("COMPRADO");  //Avisa o user que comprou
            numMoedas -= custo;  //diminui valor do total de $
            PlayerPrefs.SetInt("NumeroDeMoedas", numMoedas);  //Salva total $
            moedasTotal.text = numMoedas.ToString();  //Muda para $ atual

            PlayerPrefs.SetInt((string)tipoUpgrade, nivel+1);  //Salva Nivel
        } else
            print("FALTA GRANA!");  //Avisa que não tem $ suficiente
    }


    void AtualizaPreco(TextMeshProUGUI texto, int preco, string tipoUpgrade, int nvlMax=3)
    {
        texto.text = (preco*(PlayerPrefs.GetInt((string)tipoUpgrade, 0)+1)).ToString();  //Muda o texto do Preço (multiplica +1 do nivel)

        if (PlayerPrefs.GetInt((string)tipoUpgrade, 0) == nvlMax)
        {
            texto.text = "Nivel Máx!";  //Caso nvl max, avisa
        }
    }


}

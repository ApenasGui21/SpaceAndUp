using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtirarCooldown : MonoBehaviour
{
    private Slider slider;
    public int equipamento;

    public GameObject TiroLogo;

    public static bool rodando = false;
    float FillSpeed = 0.1f;

    private string tipoUpgrade;

    private void Awake() 
    {
        slider = gameObject.GetComponent<Slider>();
    }

    void Start()
    {
        if(PlayerPrefs.GetInt("SabeAtirar", 0) == 0)
            PlayerPrefs.SetInt("PowerUp", 1);
        else if(PlayerPrefs.GetInt("SabeIntang", 0) == 0)
            PlayerPrefs.SetInt("PowerUp", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Cooldown", 0) > 0)
            FillSpeed = (float)1 / Atirando.tempoAtirar;
        
        if(equipamento == 0)
            tipoUpgrade =  "SabeAtirar";
        else
            tipoUpgrade =  "SabeIntang";


        if(PlayerPrefs.GetInt("PowerUp", 0) == equipamento)
        {
            if(PlayerPrefs.GetInt((string)tipoUpgrade, 0) == 0)
                TiroLogo.SetActive(false);
            else if(PlayerPrefs.GetInt((string)tipoUpgrade, 0) > 0)
                TiroLogo.SetActive(true);
        } else {
            TiroLogo.SetActive(false);
        }

        if(Atirando.liberaAtirar == false && rodando == false)
        {
            PlayerPrefs.SetInt("Missao3.1", 1);
            PlayerPrefs.SetInt("Missao4", (PlayerPrefs.GetInt("Missao4", 0)+1));
            
            rodando = true;
            slider.value = 0;
        }
        
        if (slider.value < 1)
            slider.value += FillSpeed * Time.deltaTime;

        if (slider.value == 1 && Atirando.liberaAtirar)
            rodando = false;


        if (NaveMov.comeca == false)
            TiroLogo.SetActive(true);
    }
}
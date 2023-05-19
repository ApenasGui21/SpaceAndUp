using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FimDoJogo : MonoBehaviour
{
    int numMoedas;
    int moedasAgora;
    public TextMeshProUGUI moedasFim;

    // Start is called before the first frame update
    void Start()
    {
        numMoedas = PlayerPrefs.GetInt("NumeroDeMoedas");
        moedasAgora = NaveMov.numeroDeMoedas;

        PlayerPrefs.SetInt("NumeroDeMoedas", (numMoedas + moedasAgora));
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = 0f;

        moedasFim.text = numMoedas + " + " + moedasAgora;
    }
}

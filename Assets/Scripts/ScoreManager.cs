using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public TextMeshProUGUI scoreGameOver;
    public Text dindin;
    public static float score;
    float score2 = 0;

    public static float dificuldade;

    void Start()
    {
        score = 0;
    }

    void Update()
    {
        dindin.text = ""+NaveMov.numeroDeMoedas;

        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            score += 10 * Time.deltaTime * NaveMov.velocidadeSuper;
            scoreText.text = ((int)score).ToString();
            scoreGameOver.text = ((int)score).ToString();

            if (PlayerPrefs.GetInt("Missao3.1", 0) == 1)
            {
                PlayerPrefs.SetInt("Missao3", 0);
                PlayerPrefs.SetInt("Missao3.1", 0);
                score2 = 0;
            }
            score2 += (10 * Time.deltaTime * NaveMov.velocidadeSuper);
            PlayerPrefs.SetInt("Missao3", (int)score2);
        }

        if (score < 20) {
            dificuldade = 0;
        } else if (score >= 20 && score < 200) {
            dificuldade = 1;
        } else if (score >= 200 && score < 500) {
            dificuldade = 1.5f;

        } else if(score >= 500 && score < 750) {
            dificuldade = 2;
        } else if(score >= 750 && score < 1000) {
            dificuldade = 2.5f;

        } else if(score < 1500  && score >= 1000) {
            dificuldade = 3;
        } else if(score < 2000  && score >= 1500) {
            dificuldade = 4;
        } else if(score < 3960 && score >= 2000) {
            dificuldade = 5;
        } 
        
        //FIM
        else if(score < 4020 && score >= 3960) {
            dificuldade = 6;
        } else if(score < 4070 && score >= 4020) {
            dificuldade = 7;
        } else if(score >= 4070) {
            dificuldade = 8;
        }
    }
}

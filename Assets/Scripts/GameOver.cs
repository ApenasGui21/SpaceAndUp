using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public GameObject lojaPanel;
    public GameObject missoesPanel;
    bool jaClicadoL = false;
    bool jaClicadoM = false;

    public static GameObject UIjogando;
    public GameObject UIjogandoSalva;

    bool isPaused = false;
    bool liberaFim = false;
    public static bool acabouFIM;

    public GameObject BotaoTiro;
    public GameObject BotaoInvis;
    public GameObject BotaoMissao;
    public GameObject BotaoLoja;
    public GameObject Tiro;
    public GameObject Invis;
    public GameObject Hud;

    public TextMeshProUGUI HighScore;
    public TextMeshProUGUI NovoRecorde;

    void Start()
    {
        UIjogando = UIjogandoSalva;

        RefazLogoArma();
    }


    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            if (PlayerPrefs.GetInt("HighScore", 0) < ScoreManager.score)
            {
                PlayerPrefs.SetInt("HighScore", (int)ScoreManager.score);
                NovoRecorde.enabled = true;
            }
            else
                NovoRecorde.enabled = false;
            
            PlayerPrefs.SetInt("Missao2", (int)ScoreManager.score); //Missao2
            PlayerPrefs.SetInt("Missao6", 0); //Missao6

            HighScore.text = (PlayerPrefs.GetInt("HighScore", 0)).ToString();
            StartCoroutine(cooldown(1, 1));
            acabouFIM = true;

            if(liberaFim == true)
            {
                gameOverPanel.SetActive(true);
                UIjogando.SetActive(false);
            }   
        }
        else
            acabouFIM = false;

        if(Input.GetKeyDown(KeyCode.Escape))
            pausedOrNot();

        if (NaveMov.comeca == true)
        {
            Hud.SetActive(false);
            Tiro.SetActive(false);
            Invis.SetActive(false);
            BotaoMissao.SetActive(false);
            BotaoLoja.SetActive(false);
        } else {
            if (PlayerPrefs.GetInt("SabeAtirar", 0) >= 1)
                Tiro.SetActive(true);
            else
                Tiro.SetActive(false);
            if (PlayerPrefs.GetInt("SabeIntang", 0) >= 1)
                Invis.SetActive(true);
            else
                Invis.SetActive(false);
            BotaoMissao.SetActive(true);
            BotaoLoja.SetActive(true);
            Hud.SetActive(true);
        }

        zerarMissoes();
        checarMissoes();
    }




    public void Recomecar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        NaveMov.go = true;
        NaveMov.numeroDeMoedas = 0;
        ScoreManager.score = 0;
        Atirando.liberaAtirar = true;
    }

    public void LojaPanel()
    {
        gameOverPanel.SetActive(false);
        missoesPanel.SetActive(false);
        if (jaClicadoL == true)
        {
            lojaPanel.SetActive(false);
            jaClicadoL = false;
        }
        else
        {
            lojaPanel.SetActive(true);
            jaClicadoL = true;
            jaClicadoM = false;
        }
    }

    public void MissoesPanel()
    {
        gameOverPanel.SetActive(false);
        lojaPanel.SetActive(false);
        if (jaClicadoM == true)
        {
            missoesPanel.SetActive(false);
            jaClicadoM = false;
        }
        else
        {
            missoesPanel.SetActive(true);
            jaClicadoM = true;
            jaClicadoL = false;
        }
    }

    public void VoltarTelaInicial()
    {
        gameOverPanel.SetActive(false);
        lojaPanel.SetActive(false);
        missoesPanel.SetActive(false);
        liberaFim = false;
        Recomecar();
        NaveMov.go = false;
        NaveMov.comeca = false;
    }


    public void pausedOrNot()
    {
        if(isPaused)
            ResumeGame();
        else
            PauseGame();
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        isPaused = false;
    }



    public void SelectTiro()
    {
        PlayerPrefs.SetInt("PowerUp", 0);
        if (PlayerPrefs.GetInt("SabeAtirar", 0) >= 1)
            BotaoTiro.SetActive(true);
        BotaoInvis.SetActive(false);
        RefazLogoArma();
    }
    public void SelectInvis()
    {
        PlayerPrefs.SetInt("PowerUp", 1);
        BotaoTiro.SetActive(false);
        if (PlayerPrefs.GetInt("SabeIntang", 0) >= 1)
            BotaoInvis.SetActive(true);
        RefazLogoArma();
    }


    void RefazLogoArma()
    {
        if(PlayerPrefs.GetInt("PowerUp", 0) == 0)
        {
            if (PlayerPrefs.GetInt("SabeAtirar", 0) >= 1)
                BotaoTiro.SetActive(true);
            BotaoInvis.SetActive(false);
        }
        if(PlayerPrefs.GetInt("PowerUp", 0) == 1)
        {
            BotaoTiro.SetActive(false);
            if (PlayerPrefs.GetInt("SabeIntang", 0) >= 1)
                BotaoInvis.SetActive(true);
        }
    }




    void zerarMissoes()
    {
        if ((Missoes.missaoTotal % 2) != 0)
            PlayerPrefs.GetInt("Missao1", 0);
        if ((Missoes.missaoTotal % 3) != 0)
            PlayerPrefs.GetInt("Missao2", 0);
        if ((Missoes.missaoTotal % 5) != 0)
            PlayerPrefs.GetInt("Missao3", 0);
        if ((Missoes.missaoTotal % 7) != 0)
            PlayerPrefs.GetInt("Missao4", 0);
        if ((Missoes.missaoTotal % 11) != 0)
            PlayerPrefs.GetInt("Missao5", 0);
        if ((Missoes.missaoTotal % 13) != 0)
            PlayerPrefs.GetInt("Missao6", 0);
    }

    void checarMissoes()
    {
        if(PlayerPrefs.GetInt("Missao1", 0) >= 20)
            confirmarMissao(2);
        if(PlayerPrefs.GetInt("Missao2", 0) >= 1000)
            confirmarMissao(3);
        if(PlayerPrefs.GetInt("Missao3", 0) >= 500)
            confirmarMissao(5);
        if(PlayerPrefs.GetInt("Missao4", 0) >= 10)
            confirmarMissao(7);
        if(PlayerPrefs.GetInt("Missao5", 0) >= 3)
            confirmarMissao(11);
        if(PlayerPrefs.GetInt("Missao6", 0) >= 20)
            confirmarMissao(13);
    }

    void confirmarMissao(int valor)
    {
        if((PlayerPrefs.GetInt("Missao1Panel", 0) % valor) == 0)
        {
            Missoes.missao1 = true;
            print("Missao 1 Feita");
        }
        else if((PlayerPrefs.GetInt("Missao2Panel", 0) % valor) == 0)
        {
            Missoes.missao2 = true;
        }
        else if((PlayerPrefs.GetInt("Missao3Panel", 0) % valor) == 0)
        {
            Missoes.missao3 = true;
        }
    }



    IEnumerator cooldown(int tempo, int qual)
    {
        if(qual == 1)
        {
            yield return new WaitForSeconds(tempo);
            liberaFim = true;
        }
    }
}

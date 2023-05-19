using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTiro : MonoBehaviour
{
    public float vel = 5f;
    int vidaTiro = 1;

    void Start()
    {
        StartCoroutine(Spawn());  //Autodestrói após X seg
        vidaTiro = PlayerPrefs.GetInt("SabeAtirar", 0);
    }

    void Update()
    {
        transform.Translate (new Vector2 (0, vel * Time.deltaTime));  //Se movimenta para cima

        if (vidaTiro == 0)
        {
            Destroy (this.gameObject);
        }
    }


    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("obstaculo"))
        {
            vidaTiro--;

            PlayerPrefs.SetInt("Missao1", (PlayerPrefs.GetInt("Missao1", 0)+1)); //Missao1
        }

        if(other.gameObject.CompareTag("Inimigo"))
        {
            vidaTiro--;
            
            PlayerPrefs.SetInt("Missao5", (PlayerPrefs.GetInt("Missao5", 0)+1)); //Missao5
        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2);  //2 Segundos
        Destroy (this.gameObject);
    }
}
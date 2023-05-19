using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFase1 : MonoBehaviour
{
    public GameObject Aviso;
    public GameObject TiroLerdo;
    public GameObject TiroRapido;
    public GameObject TiroEspalha;
    bool comeco = true;
    bool fim = false;
    int guardaLerdo = 0;
    int guardaTiro = 0;
    int guardaEspalha = 0;
    int espalhaVezes = 0;
    float spawnTime = 0;
    float tempoEntreSpwan = 1.8f;
    float spawnTime2 = 18;
    float tempoEntreSpwan2;


    void Update()
    {
        if (comeco)
        {
            transform.position = Vector3.MoveTowards(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), new Vector3(0, -4.2f, 0), 0.35f * Time.deltaTime);  //Move objeto da PosAtual para centro

            if (transform.position == (new Vector3(0, -4.2f, 0)))
                comeco = false;
        }
        else
        {
            if (Time.time > spawnTime && Time.time < 40)
            {
                Spawn(1, 0);
                spawnTime = Time.time + tempoEntreSpwan;
            }
            if (Time.time > spawnTime && Time.time > 45 && espalhaVezes < 5)
            {
                Spawn(3, 0);
                spawnTime = Time.time + 20;
                espalhaVezes ++;
            }
            if (Time.time > spawnTime2 && espalhaVezes < 5)
            {
                Spawn(2, Random.Range(6, 20));
                spawnTime2 = Time.time + tempoEntreSpwan2;
            }


            if (espalhaVezes >= 0 && Time.time > spawnTime+30)
            {
                //Fim da fase 1!!!!!!!!
                if(fim == false)
                {
                    transform.position = Vector3.MoveTowards(new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), new Vector3(0, -7f, 0), 0.5f * Time.deltaTime);  //Move objeto da PosAtual para centro

                    if (transform.position == (new Vector3(0, -7f, 0)))
                    {
                        fim = true;
                        BossMang.boss2 = true;
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }


    void Spawn(int num, int tempo, int tiroL1 = 0, int tiroL1N = 0, int tiroL2 = 0, int tiroL3 = 0)
    {
        if (num == 1)
        {
            tiroL1 = Random.Range(1, 8); //1 até 7
            if(guardaLerdo == 2)
            {
                guardaLerdo = 0;
                do
                {
                    tiroL1N = Random.Range(1, 8);
                } while(tiroL1 == tiroL1N || tiroL1 == tiroL1N-1 || tiroL1 == tiroL1N+1);

                tiroL1 = tiroL1N;
            }
            if(tiroL1 == guardaTiro || tiroL1 == guardaTiro-1 || tiroL1 == guardaTiro+1)
               guardaLerdo ++;
            guardaTiro = tiroL1;
            tiroL2 = tiroL1 - 1;
            tiroL3 = tiroL1 + 1;

            if(tiroL1 != 1 && tiroL2 != 1 && tiroL3 != 1)
            {
                Instantiate(TiroLerdo, new Vector3(-2.36f, -4, 0), Quaternion.identity).transform.parent = this.transform;
            }
            if(tiroL1 != 2 && tiroL2 != 2 && tiroL3 != 2)
            {
                Instantiate(TiroLerdo, new Vector3(-1.77f, -4, 0), Quaternion.identity).transform.parent = this.transform;
            }
            if(tiroL1 != 3 && tiroL2 != 3 && tiroL3 != 3)
            {
                Instantiate(TiroLerdo, new Vector3(-1.18f, -4, 0), Quaternion.identity).transform.parent = this.transform;
            }
            if(tiroL1 != 4 && tiroL2 != 4 && tiroL3 != 4)
            {
                Instantiate(TiroLerdo, new Vector3(-0.58f, -4, 0), Quaternion.identity).transform.parent = this.transform;
            }
            if(tiroL1 != 5 && tiroL2 != 5 && tiroL3 != 5)
            {
                Instantiate(TiroLerdo, new Vector3(0, -4, 0), Quaternion.identity).transform.parent = this.transform;
            }
            if(tiroL1 != 6 && tiroL2 != 6 && tiroL3 != 6)
            {
                Instantiate(TiroLerdo, new Vector3(0.58f, -4, 0), Quaternion.identity).transform.parent = this.transform;
            }
            if(tiroL1 != 7 && tiroL2 != 7 && tiroL3 != 7)
            {
                Instantiate(TiroLerdo, new Vector3(1.18f, -4, 0), Quaternion.identity).transform.parent = this.transform;
            }
            if(tiroL1 != 8 && tiroL2 != 8 && tiroL3 != 8)
            {
                Instantiate(TiroLerdo, new Vector3(1.77f, -4, 0), Quaternion.identity).transform.parent = this.transform;
            }
            if(tiroL1 != 9 && tiroL2 != 9 && tiroL3 != 9)
            {
                Instantiate(TiroLerdo, new Vector3(2.36f, -4, 0), Quaternion.identity).transform.parent = this.transform;
            }
        } 
        else if (num == 2)
        {
            tempoEntreSpwan2 = tempo;

            tiroL1 = Random.Range(1, 4); //1 ou 2 ou 3
            tiroL2 = Random.Range(1, 4);
            while (tiroL1 == tiroL2)
                tiroL2 = Random.Range(1, 4);

            if (tiroL1 == 1 || tiroL2 == 1)
                Instantiate(Aviso, new Vector3(-1.77f, -2.8f, 0), Quaternion.identity).transform.parent = this.transform;
            if (tiroL1 == 2 || tiroL2 == 2)
                Instantiate(Aviso, new Vector3(0, -2.8f, 0), Quaternion.identity).transform.parent = this.transform;
            if (tiroL1 == 3 || tiroL2 == 3)
                Instantiate(Aviso, new Vector3(1.77f, -2.8f, 0), Quaternion.identity).transform.parent = this.transform;
        }
        else if (num == 3)
        {
            tiroL1 = Random.Range(1, 4); //1 à 3
            while(guardaEspalha == tiroL1)
                tiroL1 = Random.Range(1, 4);
            guardaEspalha = tiroL1;

            if (tiroL1 == 1)
                Instantiate(TiroEspalha, new Vector3(0, -3.2f, 0), Quaternion.identity);
            if (tiroL1 == 2)
                Instantiate(TiroEspalha, new Vector3(-1.77f, -3.2f, 0), Quaternion.identity);
            if (tiroL1 == 3)
                Instantiate(TiroEspalha, new Vector3(1.77f, -3.2f, 0), Quaternion.identity);
        }
    }
}

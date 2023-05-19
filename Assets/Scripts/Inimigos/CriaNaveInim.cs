using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriaNaveInim : MonoBehaviour
{
    public GameObject NaveDoMal;
    public GameObject DestroiNave;

    public GameObject NaveSegue;

    public GameObject spawnpoint;
    public GameObject spawnSegue;
    public GameObject SpawnNaveInim;

    private int tempoEntreSpwan;
    private float spawnTime;

    Vector3 pos1;
    

    void Start() 
    {
        spawnTime = Time.time + Random.Range(14, 31); //Deixar 1 a mais e 1 a menos
    }
    
    // Update is called once per frame
    void Update()
    {
        if (NaveMov.rapidao)
        {
            SpawnNaveInim.transform.Translate (new Vector2 (0, -10 * Time.deltaTime));
        }

        if (Time.time > spawnTime)
        {
            if (ScoreManager.dificuldade == 1)
                Spawn(1);
            else if (ScoreManager.dificuldade < 6 && ScoreManager.dificuldade > 2)
                Spawn(Random.Range(1, 3));
            else if (ScoreManager.dificuldade >= 6)
                tempoEntreSpwan = 100;

            spawnTime = Time.time + tempoEntreSpwan;
        }
    }

    void Spawn(int Inimigo)
    {
        if (Inimigo == 1)
        {
            pos1 = spawnpoint.transform.position;
            SpawnNaveInim.transform.position = pos1;

            Instantiate(NaveDoMal, new Vector3(SpawnNaveInim.transform.position.x,SpawnNaveInim.transform.position.y,SpawnNaveInim.transform.position.z), Quaternion.identity).transform.parent = SpawnNaveInim.transform;
            Instantiate(DestroiNave, new Vector3(0.018f, -6.288f, 0), Quaternion.identity).transform.parent = SpawnNaveInim.transform;
            tempoSpawn(31);
        } 
        else if (Inimigo == 2)
        {
            Instantiate(NaveSegue, new Vector3(spawnSegue.transform.position.x,spawnSegue.transform.position.y,spawnSegue.transform.position.z), Quaternion.identity).transform.parent = spawnSegue.transform;
            tempoSpawn(10);
        }
    }

    void tempoSpawn(int duracaoInim)
    {
        tempoEntreSpwan = Random.Range(duracaoInim+19, duracaoInim+51); //Entre 20 a 50 seg
    }
}

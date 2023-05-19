using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject meteoro;
    public GameObject meteoroForte;
    public GameObject meteoro3;
    public GameObject moeda;
    public GameObject AstMoeda;
    public GameObject powerUp;
    public GameObject NaveMinera;
    public GameObject pai;
    float maxX = 2.8f;  //min = -2.8f
    float maxY;
    float minY = 1;
    float tempoEntreSpwan;
    private float spawnTime;
    private float spawnTime2;
    int chanceDobro;
    int chanceTriplo;
    int guardaX;
    float comparaX;

    
    void Update()
    {
        if (ScoreManager.dificuldade == 0) 
        {
            spawnTime2 = Time.time + 25;
            chanceTriplo = 10;
            chanceDobro = 3;
            guardaX = 0;
            maxY = 4;
        }
            
        if (ScoreManager.dificuldade == 1) 
        {
            tempoEntreSpwan = 0.6f;
        }
        if (ScoreManager.dificuldade == 1.5f) 
        {
            tempoEntreSpwan = 0.5f;
            chanceDobro = 2;
        } 

        else if(ScoreManager.dificuldade == 2) 
        {
            tempoEntreSpwan = 0.45f;
        } 
        else if(ScoreManager.dificuldade == 2.5) 
        {
            chanceDobro = 1;
        } 

        else if(ScoreManager.dificuldade == 3) 
        {
            chanceTriplo = 8;
        }
        else if(ScoreManager.dificuldade == 4) 
        {
            
        } 
        else if(ScoreManager.dificuldade == 5) 
        {
            chanceTriplo = 6;
        } 
        else if(ScoreManager.dificuldade == 6) 
        {
            chanceTriplo = 4;
        }


        if (Time.time > spawnTime && ScoreManager.dificuldade > 0)
        {
            if (((int)Random.Range(0, chanceTriplo)) == 0)
                Spawn();
            if (((int)Random.Range(0, chanceDobro)) == 0)
                Spawn();
            Spawn(); //Sempre spawna 1

            spawnTime = Time.time + (tempoEntreSpwan / NaveMov.velocidadeSuper );
        }

        if (Time.time > spawnTime2)  //Cria PowerUP
        {
            CriaObst(powerUp);
            spawnTime2 = Time.time + Random.Range(41, 81);
        }
    }



    void Spawn()
    {
        int tipoObst;
        tipoObst = Random.Range(0, 101);

        if (ScoreManager.dificuldade == 1 || ScoreManager.dificuldade == 1.5)
        {
            if (tipoObst < 85)  // 85%
                CriaObst(meteoro);
            if (tipoObst >= 85 && tipoObst < 101)  // 15%
                CriaObst(moeda);
        }

        if (ScoreManager.dificuldade == 2 || ScoreManager.dificuldade == 2.5)
        {
            if (tipoObst < 55)  // 55%
                CriaObst(meteoro);
            if (tipoObst >= 55 && tipoObst < 85)  // 30%
                CriaObst(meteoroForte);
            if (tipoObst >= 85 && tipoObst < 101)  // 15%
                CriaObst(moeda);
        }

        if (ScoreManager.dificuldade == 3)
        {
            if (tipoObst < 53)  // 53%
                CriaObst(meteoro);
            if (tipoObst >= 53 && tipoObst < 83)  // 30%
                CriaObst(meteoroForte);
            if (tipoObst >= 83 && tipoObst < 85)  // 2%
                CriaObst(NaveMinera);
            if (tipoObst >= 85 && tipoObst < 101)  // 15%
                CriaObst(moeda);
        }

        if (ScoreManager.dificuldade == 4)
        {
            if (tipoObst < 40)  // 40%
                CriaObst(meteoro);
            if (tipoObst >= 40 && tipoObst < 70)  // 30%
                CriaObst(meteoroForte);
            if (tipoObst >= 70 && tipoObst < 85)  // 15%
                CriaObst(meteoro3);
            if (tipoObst >= 85 && tipoObst < 86)  // 1%
                CriaObst(NaveMinera);
            if (tipoObst >= 86 && tipoObst < 96)  // 10%
                CriaObst(moeda);
            if (tipoObst >= 96 && tipoObst < 101)  // 5%
                CriaObst(AstMoeda);
        }

        if (ScoreManager.dificuldade == 5)
        {
            if (tipoObst < 26)  // 25%
                CriaObst(meteoro);
            if (tipoObst >= 26 && tipoObst < 66)  // 40%
                CriaObst(meteoroForte);
            if (tipoObst >= 66 && tipoObst < 86)  // 20%
                CriaObst(meteoro3);
            if (tipoObst >= 86 && tipoObst < 91)  // 10%
                CriaObst(moeda);
            if (tipoObst >= 91 && tipoObst < 101)  // 5%
                CriaObst(AstMoeda);
        }
    }


    void CriaObst(GameObject objeto)
    {
        float randomX, randomY;

        randomX = PosRandomX();
        if((comparaX - 0.6f) < randomX && (comparaX + 0.6f) > randomX)
            randomX = PosRandomX2(comparaX);
        comparaX = randomX;

        if (randomX < 0) //2 vezes menor que 0 (para a direita)
            guardaX--;
        else //2 vezes maior que 0 (para a esquerda)
            guardaX++;

        randomY = Random.Range(minY, maxY);

        Instantiate(objeto, transform.position + new Vector3(randomX, randomY, 0), transform.rotation).transform.parent = pai.transform;
    }


    float PosRandomX()
    {
        if(guardaX == 3)
        {
            guardaX = 0;
            return Random.Range(-maxX, 0);
        } 
        else if(guardaX == -3)
        {
            guardaX = 0;
            return Random.Range(0, maxX);
        }
        return Random.Range(-maxX, maxX);
    }

    float PosRandomX2(float antigo)
    {
        if(antigo > 0)
            return Random.Range(-maxX, 0);
        else
            return Random.Range(0, maxX);
    }
}

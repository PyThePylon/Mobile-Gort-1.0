using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    [Header("EnemySpawnerList")]
    public Transform[] spawnNum;

    [Header("EnemyModels")]
    public GameObject[] enemyModel;

    int maxNum;

    void Start()
    {
        maxNum = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if(maxNum != 10)
        {
            int randNum = Random.Range(0, 3);

            Vector3 spawnPos = spawnNum[randNum].position;

            spawnPos.y = 0.5f;
            Instantiate(enemyModel[0], spawnNum[randNum].transform.position, Quaternion.identity);
            maxNum++;
        }
    }
}

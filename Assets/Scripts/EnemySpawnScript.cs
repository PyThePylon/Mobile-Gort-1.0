using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    [Header("EnemySpawnerList")]
    public Transform[] spawnNum;

    [Header("EnemyModels")]
    public GameObject[] enemyModel;

    int maxNum = 0;
    public bool spawning = false;


    public void spawningEnemies()
    {
        spawning = true;
        StartCoroutine(enemySpawn());
    }

    public void endSpawning()
    {
        spawning = false;
        maxNum = 0;
        StopAllCoroutines();
    }

    IEnumerator enemySpawn()
    {
        while (spawning)
        {
            if (maxNum < 2)
            {
                int randNum = Random.Range(0, 1);
                Vector3 spawnPos = spawnNum[randNum].position;
                GameObject spawnEnemy = Instantiate(enemyModel[0], spawnNum[0].transform.position, Quaternion.identity);
                maxNum++;
                yield return new WaitForSeconds(Random.Range(1f, 2f));
            }
            else
            {
                yield return null;
            }
        }
    }
}

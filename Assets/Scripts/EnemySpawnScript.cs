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

        if(maxNum != 2)
        {
            int randNum = Random.Range(0, 1);
            Vector3 spawnPos = spawnNum[randNum].position;
            StartCoroutine(enemySpawnDelay(spawnPos, randNum));
        }
    }

    IEnumerator enemySpawnDelay(Vector3 spawnPos, int randNum)
    {
        maxNum++;
        yield return new WaitForSeconds(2f);
        GameObject spawnEnemy = Instantiate(enemyModel[0], spawnNum[randNum].transform.position, Quaternion.identity);
    }
}

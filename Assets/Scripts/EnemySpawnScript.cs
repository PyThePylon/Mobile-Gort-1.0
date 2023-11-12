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

    // Value used to spawn enemies from the enemyModel array
    private int activeEnemyID = 0;

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

    public int IncrementEnemyID()
    {
        Debug.Log("The enemies grow stronger....");
        return activeEnemyID++;
    }

    IEnumerator enemySpawn()
    {
        while (spawning)
        {
            if (maxNum < 2)
            {
                int randNum = Random.Range(0, spawnNum.Length);
                Vector3 spawnPos = spawnNum[randNum].position;

                // Spawns enemy based on wave progression
                if (activeEnemyID < enemyModel.Length)
                {
                    GameObject spawnEnemy = Instantiate(enemyModel[activeEnemyID], spawnPos, Quaternion.identity);
                    Debug.Log("Enemy spawned!");
                }
                else
                {
                    GameObject spawnEnemy = Instantiate(enemyModel[0], spawnPos, Quaternion.identity);
                    Debug.Log("Unable to spawn the desired model. Falling back to index 0.");
                }

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

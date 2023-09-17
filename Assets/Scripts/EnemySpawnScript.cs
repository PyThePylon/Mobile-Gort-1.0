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
    Wave_Test wT;

    void Start()
    {
        maxNum = 0;
        GameObject grabWT = GameObject.FindWithTag("Player");
        if (grabWT == null)
        {
            Debug.Log("Cannot grab the script!");
        }
        else
        {
            Debug.Log("script!");
            wT = grabWT.GetComponent<Wave_Test>();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(maxNum != 2 && wT.waveActive)
        {
            int randNum = Random.Range(0, 1);
            Vector3 spawnPos = spawnNum[randNum].position;
            StartCoroutine(enemySpawnDelay(spawnPos, randNum));
        }
        else
        {
            if (!wT.waveActive)
            {
                maxNum = 0;
            }
        }
    }

    IEnumerator enemySpawnDelay(Vector3 spawnPos, int randNum)
    {
        maxNum++;
        yield return new WaitForSeconds(2f);
        GameObject spawnEnemy = Instantiate(enemyModel[0], spawnNum[0].transform.position, Quaternion.identity);
    }



}

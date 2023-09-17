using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerActions : MonoBehaviour
{
    public float towerRange = 15f;

    [Header("Single Target")]
    public Transform selectedTarget;

    public Transform firePos;

    bool snowFallOnCD = false;
    bool plantSpikeOnCD = false;
    bool basicAttackOnCD = false;



    void Update()
    {
        detectedEnemy();

        if (selectedTarget == null)
        {
            return;
        }

        if (gameObject.name.Equals("Ice_Tower(Clone)") && !snowFallOnCD)
        {
            if (selectedTarget != null)
            {
                iceTowerAction(selectedTarget.transform);
            }
        }
        else if (gameObject.name.Equals("Plant_Tower(Clone)") && !plantSpikeOnCD)
        {
            if(selectedTarget != null)
            {
                plantTowerAction(selectedTarget.transform);
            }
        }
        else if (gameObject.name.Equals("Basic_Tower(Clone)") && !basicAttackOnCD)
        {
            if (selectedTarget != null)
            {
                basicTowerAction(selectedTarget.transform);
            }
        }
    }

    void detectedEnemy()
    {
        GameObject[] enemiesInRange = GameObject.FindGameObjectsWithTag("EnemyCube");
        float closetEnemy = Mathf.Infinity;
        GameObject closeTarget = null;
        foreach (GameObject enemy in enemiesInRange)
        {
            float enemyDist = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyDist < closetEnemy)
            {
                closetEnemy = enemyDist;
                closeTarget = enemy;
            }
        }

        if (closeTarget != null && closetEnemy <= towerRange)
        {
            selectedTarget = closeTarget.transform;
        }
        else
        {
            selectedTarget = null;
        }
    }

    void iceTowerAction(Transform enemy)
    {
        GameObject snowFall = Resources.Load("Particles/Snow") as GameObject;


        if(!snowFallOnCD)
        {
            snowFallOnCD = true;
            Vector3 newEnemyY = new Vector3(enemy.position.x, 3f, enemy.position.z);
            GameObject snowFallInstant = Instantiate(snowFall, newEnemyY, Quaternion.identity);
            StartCoroutine(playSnowFallCD(snowFallInstant));
        }

    }

    IEnumerator playSnowFallCD(GameObject sFI)
    {
        Destroy(sFI, 20f);

        yield return new WaitForSeconds(20f);
        Debug.Log("Wait a little longer!");
        yield return new WaitForSeconds(5f);
        snowFallOnCD = false;
    }

    void plantTowerAction(Transform enemy)
    {
        GameObject plantSpikes = Resources.Load("Prefabs/Tower_Ammo_Types/Spikes") as GameObject;

        if (!plantSpikeOnCD)
        {
            plantSpikeOnCD = true;
            Vector3 newEnemyY = new Vector3(enemy.position.x, -2f, enemy.position.z);
            GameObject plantS = Instantiate(plantSpikes, newEnemyY, Quaternion.identity);
            StartCoroutine(raiseSpikes(plantS));

        }
    }

    IEnumerator raiseSpikes(GameObject plantSpikes)
    {
        float getHeight = .6f;

        while(plantSpikes.transform.position.y < getHeight)
        {
            plantSpikes.transform.Translate(Vector3.up * .7f * Time.deltaTime);
            yield return null;
        }

        Destroy(plantSpikes);
        yield return new WaitForSeconds(1f);
        plantSpikeOnCD = false;

    }

    void basicTowerAction(Transform enemy)
    {
        GameObject giantPellet = Resources.Load("Prefabs/Tower_Ammo_Types/Tower_Ball_Ammo") as GameObject;

        if (!basicAttackOnCD)
        {
            basicAttackOnCD = true;
            Vector3 spawnH = new Vector3(firePos.position.x, .7f, firePos.position.z);
            GameObject giantB = Instantiate(giantPellet, spawnH, Quaternion.identity);
            Vector3 ballDirct = (enemy.position - firePos.position).normalized;
            Rigidbody ballRB = giantB.GetComponent<Rigidbody>();
            ballRB.AddForce(ballDirct * 10f, ForceMode.Impulse);
            StartCoroutine(giantBall());

        }
    }

    IEnumerator giantBall()
    {
        yield return new WaitForSeconds(2f);
        basicAttackOnCD = false;

    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, towerRange);
    }


}

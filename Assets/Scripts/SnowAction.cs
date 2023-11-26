using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SnowAction : MonoBehaviour
{

    EnemyHealth eH;
    NavMeshAgent enemyNMA;

    float originalSpeed;
    public float slowT = 0;
    bool slowed = false;
   
    void Start()
    {

        GameObject[] grabEH = GameObject.FindGameObjectsWithTag("EnemyGort");
        
        if (grabEH == null)
        {
            Debug.Log("Cannot grab the script!");
        }
        else
        {
            foreach (GameObject enemy in grabEH)
            {
                eH = enemy.GetComponent<EnemyHealth>();
                enemyNMA = enemy.GetComponent<NavMeshAgent>();
            }

            if (eH != null && enemyNMA != null)
            {
                originalSpeed = enemyNMA.speed;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        slowT -= Time.deltaTime;
    }
    
    void OnParticleCollision(GameObject other)
    {
        //Debug.Log("SLOWED!");
        if (eH != null)
        {
            slowT = 5;
            if (slowed == false)
            {
                slowed = true;
                StartCoroutine(snowTimer());
            }
        }
    }
    
    IEnumerator snowTimer()
    {
        yield return new WaitForSeconds(.5f);
        if (eH != null)
        {
            eH.enemyHP -= .20f;
            enemyNMA.speed *= .02f;

            if(enemyNMA.speed < 1.5f)
            {
                enemyNMA.speed = 1.5f;
            }

            if (slowT > .5f)
            {
                StartCoroutine(snowTimer());
            }
            else
            {
                slowT = 0;
                while (slowT > 0)
                {
                    enemyNMA.speed += (originalSpeed - enemyNMA.speed) * Time.deltaTime;
                }
                slowed = false;
                enemyNMA.speed = originalSpeed;
            }
        }
    }
}

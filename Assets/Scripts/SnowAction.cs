using System.Collections;
using System.Collections.Generic;
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

        GameObject grabEH = GameObject.FindWithTag("EnemyCube");
        if (grabEH == null)
        {
            Debug.Log("Cannot grab the script!");
        }
        else
        {
            eH = grabEH.GetComponent<EnemyHealth>();
            enemyNMA = grabEH.GetComponent<NavMeshAgent>();
            originalSpeed = enemyNMA.speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        slowT -= Time.deltaTime;
    }
    
    void OnParticleCollision(GameObject other)
    {
        Debug.Log("SLOWED!");
        if (eH != null)
        {
            eH.enemyHP -= .20f;
            slowT = 3;
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
            enemyNMA.speed *= .5f;
            if (slowT > .5f)
            {
                StartCoroutine(snowTimer());
            }
            else
            {
                slowT = 0;
                slowed = false;
                enemyNMA.speed = originalSpeed;
            }
        }
    }
}

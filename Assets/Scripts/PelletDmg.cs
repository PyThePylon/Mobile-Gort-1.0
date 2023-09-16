using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletDmg : MonoBehaviour
{

    public EnemyHealth emHP;

    void Start()
    {
        emHP = emHP.GetComponent<EnemyHealth>();
    }

}

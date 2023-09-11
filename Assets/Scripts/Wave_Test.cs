using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Wave_Test : MonoBehaviour
{
    //Use wave number increment to spawn 2+ enemies
    public TextMeshProUGUI waveTxt;

    int waveCounter = 0;

    void Start()
    {
        waveCounter = 1;
        waveTxt.text = "Wave #: " + waveCounter;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            waveCounter++;
            waveTxt.text = "Wave #: " + waveCounter;
        }
    }

}

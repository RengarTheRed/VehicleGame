using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private CheckPointManager _checkPointManager;
    
    //Trigger hit report to manager
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _checkPointManager.PointHit();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class CheckPoint : MonoBehaviour
{
    private CheckPointManager _checkPointManager;

    private void Start()
    {
        _checkPointManager = FindFirstObjectByType<CheckPointManager>();
    }
    //Trigger hit report to manager
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _checkPointManager.PointHit();
            this.gameObject.SetActive(false);
        }
    }
}

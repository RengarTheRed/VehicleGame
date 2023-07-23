using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CheckPointManager : MonoBehaviour
{
    private List<CheckPoint> _checkpointList = new List<CheckPoint>();
    private int _currentPointIndex=0;
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        var all = FindObjectsByType<CheckPoint>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (var point in all)
        {
            _checkpointList.Add(point);
        }
        GetNextPoint();
    }

    public void PointHit()
    {
        _player.IncreaseScore(3);
        GetNextPoint();
    }

    private void GetNextPoint()
    {
        _player.IncreaseTimer(30);
        int newIndex=_currentPointIndex;

        newIndex = Random.Range(0, _checkpointList.Count);
        _checkpointList[newIndex].gameObject.SetActive(true);
        _currentPointIndex = newIndex;
        _player.SetGoal(_checkpointList[_currentPointIndex].transform);
    }
}

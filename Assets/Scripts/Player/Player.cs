using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ReSharper disable All

public class Player : MonoBehaviour
{
    private int _score=0;
    public float _timer=60f;
    private HUD _hud;
    public Transform _arrow;
    private Transform _goal;

    private void Start()
    {
        _hud = FindFirstObjectByType<HUD>();
    }

    public void SetGoal(Transform goal)
    {
        _goal = goal;
    }

    public void IncreaseScore(int toIncrease)
    {
        _score += toIncrease;
        _hud._score.SetText(_score.ToString("F0"));
    }

    public void IncreaseTimer(float toIncrease)
    {
        _timer += toIncrease;
    }

    private void Update()
    {
        TargetArrow();
        _timer -= Time.deltaTime;
        _hud._timer.SetText(_timer.ToString("F0"));
        if (_timer <= 0)
        {
            GameOver();
        }
    }

    private Vector3 origin;
    private Vector3 dest;
    private Vector3 relativePos;
    private void TargetArrow()
    {
        origin = GetComponent<CarControler>().gameObject.transform.position;
        dest = _goal.position;
        dest.y = _arrow.position.y;
        relativePos = origin - dest;
        _arrow.transform.rotation = Quaternion.LookRotation(relativePos, Vector3.back);
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        _hud.GameOver();
    }
}

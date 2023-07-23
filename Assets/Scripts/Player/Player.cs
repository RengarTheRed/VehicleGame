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

    private void TargetArrow()
    {
        Vector3 dest = _goal.position;
        dest.y = _arrow.position.y;
        Debug.Log(dest);
        _arrow.transform.LookAt(_goal.position*Time.deltaTime * .2f, Vector3.forward);
    }

    private void GameOver()
    {
        Time.timeScale = 0;
        _hud.GameOver();
    }
}

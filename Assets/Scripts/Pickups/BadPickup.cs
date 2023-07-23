using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadPickup : MonoBehaviour
{
    private Player _player;
    private void Start()
    {
        _player = FindFirstObjectByType<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player.IncreaseTimer(-10);
            gameObject.SetActive(false);
        }
    }
}

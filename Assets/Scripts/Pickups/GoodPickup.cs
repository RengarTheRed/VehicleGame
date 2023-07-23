using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodPickup : MonoBehaviour
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
            _player.IncreaseScore(5);
            gameObject.SetActive(false);
        }
    }
}

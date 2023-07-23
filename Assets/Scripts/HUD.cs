using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public TMP_Text _timer;
    public TMP_Text _score;
    public GameObject _gameoverPanel;
    public Button _restartButton;

    private void Start()
    {
        _restartButton.onClick.AddListener(Restart);
    }

    public void GameOver()
    {
        _gameoverPanel.SetActive(true);
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

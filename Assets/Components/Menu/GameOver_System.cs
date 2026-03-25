using System;
using UnityEngine;

public class GameOver_System : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverWindow;

    private void Awake()
    { 
        _gameOverWindow.SetActive(false);
        EventSystem.OnPlayerLifeUpdated += PlayerLife;
    }
    private void OnDestroy()
    {
        EventSystem.OnPlayerLifeUpdated -= PlayerLife;
    }

    private void PlayerLife(int Life)
    {
        if (Life > 0)
        {
            return;
        }

        _gameOverWindow.SetActive(true);
    }
}

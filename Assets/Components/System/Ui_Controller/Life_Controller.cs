using UnityEngine;

public class Life_Controller : MonoBehaviour
{
    [SerializeField] private int _lifeCount = 3;

    private int _currentLifeCount;

    private void Start()
    {
        _currentLifeCount = _lifeCount;

        EventSystem.OnPlayerLifeUpdated?.Invoke(_currentLifeCount);

        EventSystem.OnPlayerCollision += PlayerCollision;
    }

    private void OnDestroy()
    {
        EventSystem.OnPlayerCollision -= PlayerCollision;
    }

    private void PlayerCollision()
    {
        if (_currentLifeCount <= 0)
        {
            //GameOver();
            return;
        }

        _currentLifeCount--;
        EventSystem.OnPlayerLifeUpdated?.Invoke(_currentLifeCount);
    }
}
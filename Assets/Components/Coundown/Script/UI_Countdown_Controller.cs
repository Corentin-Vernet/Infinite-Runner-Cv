using TMPro;
using UnityEngine;

public class UI_Countdown_Controller : MonoBehaviour
{
    [SerializeField] private TMP_Text _countdownText;

    private bool _inCountdown;
    private Countdown_State _countdown_State;

    private void Awake()
    {
        EventSystem.OnGameStateChange += HandleStateChange;
    }

    private void OnDestroy()
    {
        EventSystem.OnGameStateChange -= HandleStateChange;
    }

    private void HandleStateChange(State state)
    {
        if (state is not Countdown_State countdown_State)
        {
            _inCountdown = false;
            return;
        }

        _countdown_State = countdown_State;
        _inCountdown = true;
    }

    private void Update()
    {
        if (!_inCountdown)
        {
            return;
        }

        _countdownText.text = _countdown_State.Timer.ToString("0.000");
    }
}
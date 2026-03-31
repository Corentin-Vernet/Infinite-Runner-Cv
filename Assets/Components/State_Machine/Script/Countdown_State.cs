using UnityEngine;

public class Countdown_State : State
{
    private float _time = 3f;
    private float _timer;

    public Countdown_State(State_Machine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Countdown start");
        _timer = _time;
    }

    public override void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer > 0)
        {
        Debug.Log($"Countdown: {_timer}");
            return;
        }
        var gameState = new Game_State(StateMachine);
        StateMachine.ChangeState(gameState);            
    }

    public override void Exit()
    {
        Debug.Log("Countdown fin");
    }
}
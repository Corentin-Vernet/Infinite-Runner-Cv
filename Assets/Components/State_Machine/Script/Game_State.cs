using UnityEngine;

public class Game_State : State
{
    public float _timer;

    public Game_State(State_Machine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Game start");
    }

    public override void Update()
    {
        _timer += Time.deltaTime;
    }

    public override void Exit()
    {
        Debug.Log("Game fin");
    }
}
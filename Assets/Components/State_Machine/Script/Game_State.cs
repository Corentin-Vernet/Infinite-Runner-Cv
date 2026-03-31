using UnityEngine;

public class Game_State : State
{
    public Game_State(State_Machine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Game start");
    }

    public override void Update()
    {

    }

    public override void Exit()
    {
        Debug.Log("Game fin");
    }
}
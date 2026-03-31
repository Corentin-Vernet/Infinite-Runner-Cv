using UnityEngine;

public class GameOver_State : State
{
    public GameOver_State(State_Machine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("GameOver start");
    }

    public override void Update()
    {

    }

    public override void Exit()
    {
        Debug.Log("GameOver fin");
    }
}
using UnityEngine;

public class State_Machine_Contoller : MonoBehaviour
{
    private State_Machine _stateMachine;

    private void Start()
    {
        _stateMachine = new State_Machine();
        var initialState = new Countdown_State(_stateMachine);

        _stateMachine.ChangeState(initialState);
    }

    private void Update()
    {
        _stateMachine.Update();
    }
}
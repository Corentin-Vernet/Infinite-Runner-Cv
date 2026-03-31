
public class State_Machine
{
    public State currentState;

    public void ChangeState (State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    public void Update()
    {
        currentState?.Update();
    }
}
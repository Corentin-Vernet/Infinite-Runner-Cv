
public abstract class State
{
    protected readonly State_Machine StateMachine;

    protected State(State_Machine stateMachine)
    {
        StateMachine = stateMachine;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}


public abstract class State
{
    protected FSMEntity FsmEntity;

    protected State(FSMEntity fsmEntity)
    {
        FsmEntity = fsmEntity;
    }

    public virtual void OnStateEnter()
    {

    }

    public virtual void OnStateUpdate()
    {

    }

    public virtual void OnStateExit()
    {

    }
}

using System;

public class Transition
{
    private readonly Func<bool> condition;
    private State _targetState;

    public Func<bool> Condition => condition;
    public State TargetState => _targetState;

    public Transition(State target, Func<bool> condition)
    {
        _targetState = target;
        this.condition = condition;
    }
}

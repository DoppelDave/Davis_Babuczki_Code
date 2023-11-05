using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State currentState;
    private Dictionary<State, List<Transition>> transitions;

    public StateMachine(State start, Dictionary<State, List<Transition>> transitions)
    {
        currentState = start;
        this.transitions = transitions;
    }

    public void Update()
    {
        State nextState = GetNextState();
        if (nextState != null) SwitchState(nextState);

        currentState.OnStateUpdate();
    }

    private State GetNextState()
    {
        List<Transition> currentTransitions = transitions[currentState];

        foreach (var transition in currentTransitions)
        {
            if (transition.Condition()) return transition.TargetState;
        }

        return null;
    }

    
    private void SwitchState(State targetState)
    {
        if (currentState == targetState) return;

        currentState.OnStateExit();
        targetState.OnStateEnter();
        currentState = targetState;
    }
}

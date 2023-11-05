using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectState : State
{
    public CollectState(FSMEntity fsmEntity) : base(fsmEntity)
    {

    }

    public override void OnStateEnter()
    {
        FsmEntity.StartCoroutine(FsmEntity.Collect());
        FsmEntity.agent.isStopped = true;
    }

    public override void OnStateUpdate()
    {
        
    }

    public override void OnStateExit()
    {
        FsmEntity.StopAllCoroutines();
    }
}

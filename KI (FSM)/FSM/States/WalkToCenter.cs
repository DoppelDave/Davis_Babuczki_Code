using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WalkToCenter : State
{
    public WalkToCenter(FSMEntity fsmEntity) : base(fsmEntity)
    {

    }

    public override void OnStateEnter()
    {
        FsmEntity.FindCenter();
        FsmEntity.agent.isStopped = false;
        FsmEntity.anim.SetBool("isWalking", true);
    }

    public override void OnStateUpdate()
    {
        FsmEntity.GoToCenter();
    }

    public override void OnStateExit()
    {
        FsmEntity.ResetInventory();
        FsmEntity.anim.SetBool("isWalking", false);
    }
}

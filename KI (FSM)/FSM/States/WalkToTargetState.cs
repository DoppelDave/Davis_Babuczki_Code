using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkToTarget : State
{
    public WalkToTarget(FSMEntity fsmEntity) : base(fsmEntity)
    {

    }

    public override void OnStateEnter()
    {
        FsmEntity.FindRessource();
        FsmEntity.anim.SetBool("isWalking", true);
    }

    public override void OnStateUpdate()
    {
        FsmEntity.GoToRessource();
    }

    public override void OnStateExit()
    {
        FsmEntity.anim.SetBool("isWalking", false);
    }
}

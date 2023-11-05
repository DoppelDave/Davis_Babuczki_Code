using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(FSMEntity fsmEntity) : base(fsmEntity)
    {

    }

    public override void OnStateEnter()
    {
        FsmEntity.anim.SetBool("isIdeling", true);
    }

    public override void OnStateUpdate()
    {

    }

    public override void OnStateExit()
    {
        FsmEntity.anim.SetBool("isIdeling", false);
    }
}

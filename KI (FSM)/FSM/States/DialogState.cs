using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogState : State
{
    [SerializeField] GameObject dialogPanel;

    public DialogState(FSMEntity fsmEntity) : base(fsmEntity)
    {

    }

    public override void OnStateEnter()
    {
        dialogPanel.SetActive(true);
    }

    public override void OnStateUpdate()
    {
        Debug.Log("In Dialog State");
    }

    public override void OnStateExit()
    {
        
    }
}

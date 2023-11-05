using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBehaviour : MonoBehaviour
{
    protected FSMEntity entity;
    protected StateMachine stateMachine;

    public FSMEntity FsmEntity => entity;

    protected virtual void Start()
    {
        entity = GetComponent<FSMEntity>();
    }

    void Update()
    {
        stateMachine.Update();
    }
}

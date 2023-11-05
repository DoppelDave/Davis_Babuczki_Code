using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public enum RessourceToCollect
{
    Wood,
    Stone
}
public class CollectBehaviour : EntityBehaviour
{
    public RessourceToCollect order;

    [SerializeField] private GameObject ressource;
    public GameObject Ressource => ressource;
    
    public float StopDistance => entity.agent.stoppingDistance;

    [SerializeField] private int inventory;
    public int Inventory
    {
        get => inventory; set => inventory = value;
    } 

    [SerializeField] private int maxInventory;
    public int MaxInventory => maxInventory;

    [SerializeField] private GameObject center;
    public GameObject Center => center;

    public bool isWorking;

    void Start()
    {
        base.Start();
        CreateStateMachine(entity);        
    }

    

    private void CreateStateMachine(FSMEntity fsmEntity)
    {
        IdleState idleState = new IdleState(fsmEntity);
        CollectState collectState = new CollectState(fsmEntity);
        WalkToTarget walkToTargetState = new WalkToTarget(fsmEntity);
        WalkToCenter walkToCenterState = new WalkToCenter(fsmEntity);

        Dictionary<State, List<Transition>> transitions = new Dictionary<State, List<Transition>>()
        {
            [idleState] = new List<Transition>()
            {
                new Transition(walkToTargetState, condition: () => GotWork()),
            },
            [walkToTargetState] = new List<Transition>()
            {
                new Transition(collectState, condition: () => ReachedRessource(fsmEntity)),
                new Transition(idleState, condition: () => !GotWork())
            },
            [collectState] = new List<Transition>()
            {
                new Transition(walkToCenterState, condition: () => ReachedInventoryCapacity())
            },
            [walkToCenterState] = new List<Transition>()
            {
                new Transition(walkToTargetState, condition: () => ReachedCenter(fsmEntity))
            },
        };

        stateMachine = new StateMachine(idleState, transitions);

    }

    private bool GotWork()
    {
        if (isWorking) return true;
        else return false;
    }

    private bool ReachedRessource(FSMEntity fsmEntity)
    {
        var ressourcePos = _targetRessource().transform.position;

        if(ressourcePos == null)
        {
            isWorking = false;
            GotWork();
            return false;
        } 
        else
        {
            return Vector3.Distance(fsmEntity.transform.position, ressourcePos) < StopDistance;
        }
    }  

    private bool ReachedCenter(FSMEntity fsmEntity)
    {
        var centerPos = _center().transform.position;
        return Vector3.Distance(fsmEntity.transform.position, centerPos) < StopDistance;
    }

    private bool ReachedInventoryCapacity()
    {
        if (inventory >= maxInventory) return true;
        else return false;
    }

    public GameObject _targetRessource()
    {
        switch (order)
        {
            case RessourceToCollect.Wood:
                ressource = GameObject.FindGameObjectWithTag("Tree");
                break;
            case RessourceToCollect.Stone:
                ressource = GameObject.FindGameObjectWithTag("Stone");
                break;
        }

        if(ressource == null)
        {
            isWorking = false;
            GotWork();
        }

        return ressource;
    }

    public GameObject _center()
    {
        center = GameObject.FindGameObjectWithTag("Center");   
        return center;
    }

  
    
    
}

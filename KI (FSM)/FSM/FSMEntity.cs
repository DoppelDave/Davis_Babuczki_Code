using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class FSMEntity : MonoBehaviour
{
    [SerializeField] public EntityBehaviour behaviour;
    [HideInInspector]
    public Animator anim;
    [HideInInspector]
    public NavMeshAgent agent;
    [SerializeField] float collectRatio = 2.0f;
    public Transform transformHuman;

    


    
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }


    public void ResetInventory()
    {
        switch (((CollectBehaviour)behaviour).order)
        {
            case (RessourceToCollect.Wood):
                GameManager.Instance.Data.Wood += ((CollectBehaviour)behaviour).Inventory;
                GameManager.Instance.UI.SetWood();
                break;
            case (RessourceToCollect.Stone):
                GameManager.Instance.Data.Wood += ((CollectBehaviour)behaviour).Inventory;
                GameManager.Instance.UI.SetStone();
                break;

        }
        ((CollectBehaviour)behaviour).Inventory = 0;
        
    }

    public void SetOrder(RessourceToCollect order)
    {
        ((CollectBehaviour)behaviour).isWorking = true;
        ((CollectBehaviour)behaviour).order = order;
    }
    public void GoToRessource() 
    {        
        var targetPosition = ((CollectBehaviour)behaviour).Ressource.transform.position;

        if (targetPosition != null)
        {
            agent.SetDestination(targetPosition);
        }
        else
        {
            ((CollectBehaviour)behaviour).isWorking = false;
        }

        
    }

    public void FindRessource() 
    {
        ((CollectBehaviour)behaviour)._targetRessource();

        if (((CollectBehaviour)behaviour)._targetRessource() == null)
        {
            ((CollectBehaviour)behaviour).isWorking = false;
        }
    }

    public void FindCenter()
    {
        ((CollectBehaviour)behaviour)._center();
    }

    public void GoToCenter()
    {
        var targetPosition = ((CollectBehaviour)behaviour).Center.transform.position;
        agent.SetDestination(targetPosition);       
    }


    public IEnumerator Collect()
    {
        while (true)
        {
            anim.SetTrigger("Attack");
            ((CollectBehaviour)behaviour).Inventory++;
            ((CollectBehaviour)behaviour).Ressource.GetComponentInParent<Ressource>().Collect();
            yield return new WaitForSeconds(collectRatio);
        }
    }
}

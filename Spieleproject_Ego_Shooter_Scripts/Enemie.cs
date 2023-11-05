using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.InputSystem.Editor;

public class Enemie : MonoBehaviour
{
    public PlayerStats playerStats;
    public UnityEvent<int> OnHealthChanged;

    [SerializeField] private float stopDistance = 2f;
    [SerializeField] private float timeBetweenAttacks = 2f;
    [SerializeField] private int dmg = 5;
    private float attackTime;
    private bool hasDied;
  
    private NavMeshAgent agent;
    private Animator anim;
    private GameObject player;
    private Rigidbody rb;
    private AudioSource audioSource;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private List<AudioClip> dmgSounds = new List<AudioClip>();
  
    void Start()
    {       
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.stoppingDistance = stopDistance;
    }

    
    void Update()
    {
        if (agent != null && !hasDied && player != null)
        {
            if ((player.transform.position - transform.position).sqrMagnitude-2f < Mathf.Pow(agent.stoppingDistance, 2))
            {
                anim.SetBool("isWalking", false);

                if (Time.time > attackTime)
                {
                    int rnd = Random.Range(0, dmgSounds.Count);
                    audioSource.clip = dmgSounds[rnd];
                    audioSource.Play();
                    anim.SetTrigger("Attack");
                    Health -= dmg;
                    attackTime = Time.time + timeBetweenAttacks;
                }
            }
            else
            {
                Movement();
                anim.SetBool("isWalking", true);
            }
        }             
    }

    void Movement()
    {
        agent.destination = player.transform.position;        
    }

    public void Die()
    {
        hasDied = true;
        agent.speed = 0;
        agent.angularSpeed = 0;        
        

        agent = null;
        rb.isKinematic = true;

        float rnd = Random.Range(0.8f, 1.1f);
        audioSource.clip = deathSound;
        audioSource.pitch = rnd;
        audioSource.Play();
        anim.SetTrigger("Die");
        Destroy(gameObject,8.0f);    
    }

    public int Health
    {
        get => playerStats.Health; set
        {
            playerStats.Health = value;
            OnHealthChanged.Invoke(playerStats.Health);
        }
    }

   
}

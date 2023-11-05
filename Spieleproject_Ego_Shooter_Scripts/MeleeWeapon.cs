using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MeleeWeapon : MonoBehaviour
{
    [SerializeField] private int dmg = 3;
    [SerializeField] private float timeBetweenAttacks = 1.0f;
    private float attackTime;
    private bool isCharging;

    [SerializeField] private AudioClip hitSoundEasy;
    [SerializeField] private AudioClip hitSoundHeavy;
    [SerializeField] private List<AudioClip> collisionSounds = new List<AudioClip>();

    [SerializeField] private GameObject hitEffect;
    private AudioSource audioSource;
    private PlayerInput playerInput;
    private InputAction fireInput;
    private InputAction aimInput;
    private Animator anim;

    

    void Start()
    {
        playerInput = new PlayerInput();

        fireInput = playerInput.Player.Fire;
        fireInput.performed += Fire;
        fireInput.canceled += Fire;
        fireInput.Enable();

        aimInput = playerInput.Player.Aim;
        aimInput.performed += Aim;
        aimInput.canceled += Aim;
        aimInput.Enable();
        

        audioSource = GetComponent<AudioSource>();
        anim = GetComponentInParent<Animator>();
        
    }


    public void Fire(InputAction.CallbackContext context)
    {

        if (context.performed)
        {

            if (Time.time > attackTime)
            {
                if (isCharging)
                {                   
                    anim.SetTrigger("hardHit");
                    audioSource.clip = hitSoundHeavy;
                    audioSource.Play();
                } else
                {
                    anim.SetTrigger("easyHit");
                    audioSource.clip = hitSoundEasy;
                    audioSource.Play();

                }
                
                attackTime = Time.time + timeBetweenAttacks;
            }
        }
    }

    public void Aim(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            anim.SetBool("isCharging", true);            
            isCharging = true;            
        }
        else if (context.canceled)
        {
            anim.SetBool("isCharging", false);
            isCharging = false;
        }
    }


    private void OnDisable()
    {
        fireInput.Disable();
        aimInput.Disable();

        fireInput.performed -= Fire;
        fireInput.canceled -= Fire;
        aimInput.performed -= Aim;
        aimInput.canceled -= Aim;
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Debug.Log("hit");
            int rnd = Random.Range(0, collisionSounds.Count);
            other.transform.GetComponent<EnemieHealth>().TakeDamage(dmg, collisionSounds[rnd]);

            Instantiate(hitEffect, other.transform.position + new Vector3(0,+2,0), other.transform.rotation);
        }
    }

    
}

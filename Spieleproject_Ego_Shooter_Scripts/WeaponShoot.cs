using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponShoot : MonoBehaviour
{    
    [SerializeField] private float timeBetweenShoots = 1.0f;
    private float shootTime;

    [SerializeField] private Transform muzzle;    
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private GameObject bullet;

    
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
        audioSource.clip = shootSound;
    }

    public void Update()
    {
        AimCenter();
    }
    public void Fire(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            
            if(Time.time > shootTime)
            {
                Instantiate(bullet, muzzle.position, transform.rotation);
                audioSource.Play();
                shootTime = Time.time + timeBetweenShoots;
            }
        }
    }

    public void Aim(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            anim.SetBool("isAiming", true);            
        } else if(context.canceled)
        {
            anim.SetBool("isAiming", false);
        }
    }
    
    public void AimCenter()
    {
        float screenX = Screen.width / 2;
        float screenY = Screen.height / 2;

       
        

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay( new Vector3 (screenX, screenY));

        if (Physics.Raycast(ray, out hit))
        {           
            transform.LookAt(hit.point);
            
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
}

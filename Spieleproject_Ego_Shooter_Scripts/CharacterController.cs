using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5;
    [SerializeField] private float runSpeed = 10;
    [SerializeField] private float jumpHeight = 5;
    [SerializeField] private float airAcceleration = 2;
    [SerializeField] private float groundAcceleration = 8;
    [SerializeField] private List<AudioClip> stepSounds = new List<AudioClip>();
    [SerializeField] private AudioClip jumpSound;

    public float maxStamina = 300;
    

    private float currentAcceleration;
    public float stamina;
    private bool isRunning;

    private bool doStepSound = true;
    private float waitForStep = 0.8f;
    
    
    private AudioSource audioSource;
    private PlayerInput playerInput;
    private InputAction moveInput;
    private InputAction jumpInput;
    private InputAction runInput;
   

    private Rigidbody rb;
    private Transform cameraTransform;

    private Vector3 lerpedInput;
    private Vector3 currentVelocity;

    private void Awake()
    {
        stamina = maxStamina;
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        cameraTransform = Camera.main.transform;

        playerInput = new PlayerInput();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start()
    {
        currentAcceleration = groundAcceleration;
    }
    private void OnEnable()
    {
        moveInput = playerInput.Player.Move;
        moveInput.Enable();

        jumpInput = playerInput.Player.Jump;
        jumpInput.Enable();

        runInput = playerInput.Player.Run;
        runInput.Enable();

        runInput.performed += Run;
        runInput.canceled += Run;
        
    }
    void Update()
    {       
        Movement();
        StartCoroutine(StaminaController());      
    }

    void Run(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            isRunning = true;
        }
        if(context.canceled || stamina < 10)
        {
            isRunning = false;
        }
    }
    
    private void Movement()
    {
        bool isGrounded = IsGrounded();

        Vector3 input = Vector3.zero;

        input.x = moveInput.ReadValue<Vector2>().x;
        input.z = moveInput.ReadValue<Vector2>().y;

        input = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0) * input;

        transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);

        currentAcceleration = isGrounded ? groundAcceleration : airAcceleration;
        lerpedInput = Vector3.Lerp(lerpedInput, input, currentAcceleration * Time.deltaTime);

        if (!isRunning || stamina < 10)
        {
            currentVelocity = lerpedInput * movementSpeed;
            
        } else if(isRunning)
        {
            currentVelocity = lerpedInput * runSpeed;            
        }
        
        currentVelocity.y = rb.velocity.y;
        
        if (isGrounded && jumpInput.triggered && stamina > 10)
        {
            currentVelocity.y = jumpHeight;
            stamina -= 100;
            audioSource.clip = jumpSound;
            audioSource.Play();
        }

        rb.velocity = currentVelocity;

        if (input.x != 0)
        {
            if (doStepSound)
            {
                DoWalkSounds(waitForStep);
            }
        } else if (input.x == 0)
        {
            StopCoroutine(WaitForStepSounds(waitForStep));
        }

    }

    bool IsGrounded()
    {
        bool groundCheck = Physics.Raycast(transform.position + Vector3.up, Vector3.down, 0.5f);

        return groundCheck;
    }

    private void OnDisable()
    {
        moveInput.Disable();
        jumpInput.Disable();
        runInput.Disable();

        runInput.performed -= Run;
    }

    public IEnumerator StaminaController()
    {
        if (isRunning && stamina > 0 && IsGrounded())
        {
            stamina--;
        } else if (!isRunning && stamina < maxStamina && IsGrounded())
        {
            stamina++;
        }
        
        yield return new WaitForSeconds(2f);
    }

    public IEnumerator WaitForStepSounds(float waitForStepWalk)
    {
        doStepSound = false;
        if(isRunning == true)
        {
            waitForStepWalk = 0.5f;
        } else if(isRunning == false || stamina < 10)
        {
            waitForStepWalk = 1f;
        }
       
        yield return new WaitForSeconds(waitForStepWalk);
        
        doStepSound = true;
    }

    void DoWalkSounds(float waitForStep)
    {
        int rnd = Random.Range(0, stepSounds.Count);
        audioSource.clip = stepSounds[rnd];
        audioSource.Play();
        StartCoroutine(WaitForStepSounds(waitForStep));
    }

    
}

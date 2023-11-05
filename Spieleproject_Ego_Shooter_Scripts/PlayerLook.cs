using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float sensitivity = 0.3f;

    private PlayerInput playerInput;
    private InputAction lookInput;

    private Vector3 angle;
    private Vector3 lerpAngle;

    
    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        lookInput = playerInput.Player.Look;
        lookInput.Enable();
    }
    // Update is called once per frame
    void Update()
    {
        angle.x -= lookInput.ReadValue<Vector2>().y * sensitivity;
        angle.y += lookInput.ReadValue<Vector2>().x * sensitivity;

        angle.x = Mathf.Clamp(angle.x, -60, 30);

        lerpAngle = Vector3.Lerp(lerpAngle, angle, 40 * Time.deltaTime);
        transform.eulerAngles = lerpAngle;
        
    }

    private void OnDisable()
    {
        lookInput.Disable();
    }
}

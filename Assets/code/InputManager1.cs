using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager1 : MonoBehaviour
{
    // 1. These define the "Input System"
    private PlayerControls playerInput; 
    public PlayerControls.OnFootActions onFoot;

    // 2. These define the "Scripts" we are talking to (THIS IS WHAT WAS MISSING)
    private PlayerMotor motor;
    private playerLook look;

    void Awake()
    {
        playerInput = new PlayerControls();
        onFoot = playerInput.OnFoot;
        
        // 3. Find the scripts on the object
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<playerLook>();

        // 4. Connect the Jump action
        onFoot.JUMP.performed += ctx => motor.Jump();
    }

    void FixedUpdate()
    {
        // Tell the motor to move using the value from our "Movement" action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        // Tell the look script to rotate using the value from our "look" action
        look.ProcessLook(onFoot.look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
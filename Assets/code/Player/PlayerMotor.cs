using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool isGrounded;

    public float speed = 5f;
    public float gravity = -9.8f; 
    public float jumpHeight = 3f;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;

        moveDirection.x = input.x;
        moveDirection.z = input.y;

        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;
        
        if(isGrounded && playerVelocity.y < 0)
            playerVelocity.y = -2f;
            
        controller.Move(playerVelocity * Time.deltaTime);
    }

    // FIXED: Capitalized J to match the call in InputManager1.cs
    public void Jump()
    {
        if (isGrounded)
        {
            // FIXED: Changed 'Squrt' to 'Sqrt'
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravity );
        }
    }
}
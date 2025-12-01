using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        // Calculate camera rotation for looking up and down
        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        
        // FIXED: Use '=' instead of '-=' to correctly apply the limit
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);

        // Apply the rotation to the camera transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        
        // Rotate the player body left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensitivity);
    }
}
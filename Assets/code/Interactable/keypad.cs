using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField]
    private GameObject gate;
    
    private bool doorOpen;

    // --- REMOVED THE DUPLICATE LINES HERE ---

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This function is where we will design our interaction using code.
    protected override void Interact()
    {
        doorOpen = !doorOpen;
        gate.GetComponent<Animator>().SetBool("IsOpen", doorOpen);
    }
}
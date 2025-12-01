using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // Message displayed to player when looking at an interactable.
    public string promptMessage;

    // This function will be called from our player.
    public void BaseInteract()
    {
        Interact();
    }

    // Template function to be overridden by subclasses
    protected virtual void Interact()
    {
        // We don’t write code here,
        // child classes (Door, ItemPickup, etc.) will override this.
    }
}

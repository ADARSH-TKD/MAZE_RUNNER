using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;

    [SerializeField]
    private float distance = 3f;

    [SerializeField]
    private LayerMask mask;
    
    private PlayerUI playerUI;

    // FIXED: Changed 'InputManager' to 'InputManager1' to match your script name
    private InputManager1 inputManager;

    void Start()
    {
        cam = Camera.main;
        playerUI = GetComponent<PlayerUI>();
        
        // FIXED: Changed 'InputManager' to 'InputManager1'
        inputManager = GetComponent<InputManager1>();
    }

    void Update()
    {
        playerUI.UpdateText(string.Empty);
        
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {   
                // FIXED: Changed 'colloider' (typo) to 'collider'
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                
                playerUI.UpdateText(interactable.promptMessage);
                
                // NOTE: This line requires setup in InputManager1 (see below)
                if(inputManager.onFoot.Interact.triggered)
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
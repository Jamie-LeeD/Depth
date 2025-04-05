using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    Transform interactionPosition;
    [SerializeField]
    float range;
    [SerializeField]
    float offsetRadius;
    [SerializeField]
    Camera cam;
    [SerializeField]
    LayerMask interactables;

    IInteractable currentInteraction;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) Interact(); 
        currentInteraction?.Interact(interactionPosition);
    }

    void Interact()
    {
        if (currentInteraction == null)
        {
            if (Physics.SphereCast(cam.transform.position, offsetRadius, cam.transform.forward, out RaycastHit hit, range, interactables))
            {
                currentInteraction = hit.collider.gameObject.GetComponent<IInteractable>();
                if (currentInteraction != null) currentInteraction.ComponentsEnabled = false;
            }
        }
        else
        {
            currentInteraction.ComponentsEnabled = true;
            currentInteraction = null;
        }
    }
}

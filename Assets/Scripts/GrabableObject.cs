using UnityEngine;

[RequireComponent (typeof(Rigidbody), typeof(Collider))]
public class GrabableObject : MonoBehaviour, IInteractable
{
    Rigidbody rb;
    Collider c;

    public bool ComponentsEnabled { get; set; }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        c = GetComponent<Collider>();
        ComponentsEnabled = true;
    }

    public void Interact(Transform t)
    {
        rb.isKinematic = ComponentsEnabled;
        c.enabled = ComponentsEnabled;
        transform.position = t.position;
        transform.rotation = t.rotation;
    }
}

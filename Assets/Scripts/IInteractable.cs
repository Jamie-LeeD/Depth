using UnityEngine;

public interface IInteractable
{
    public bool ComponentsEnabled { get; set; }

    public void Interact(Transform t);
}

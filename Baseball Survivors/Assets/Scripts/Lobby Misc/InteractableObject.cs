using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    public GameObject highlightEffect;

    public abstract void Interact();
    public abstract void HighlightObject();
    public abstract void DeactivateHighlight();
}

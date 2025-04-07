using UnityEngine;

public class MapInteractable : InteractableObject
{
    public override void DeactivateHighlight()
    {
        highlightEffect.gameObject.SetActive(false);
    }

    public override void HighlightObject()
    {
        highlightEffect.gameObject.SetActive(true);
    }

    public override void Interact()
    {
        Debug.Log("You interacted with the map");
    }
}

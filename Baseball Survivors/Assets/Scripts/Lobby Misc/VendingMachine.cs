using UnityEngine;

public class VendingMachine : InteractableObject
{
    public override void Interact()
    {
        Debug.Log("You interacted with the vending machine");
    }

    public override void HighlightObject()
    {
        highlightEffect.gameObject.SetActive(true);
    }

    public override void DeactivateHighlight()
    {
        highlightEffect.gameObject.SetActive(false);
    }
}

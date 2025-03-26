using UnityEngine;

public class HUD_PlayerIcon : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void UpdatePlayerHudIcon()
    {
        if(PlayerHealth.instance.PlayerHealthPercentage() > 0.75f)
        {
            animator.SetTrigger("icon_1");
        }
        else if(PlayerHealth.instance.PlayerHealthPercentage() > 0.5f)
        {
            animator.SetTrigger("icon_2");
        }
        else if(PlayerHealth.instance.PlayerHealthPercentage() > 0.25f)
        {
            animator.SetTrigger("icon_3");
        }
        else if(PlayerHealth.instance.PlayerHealthPercentage() > 0)
        {
            animator.SetTrigger("icon_4");
        }
        else
        {
            animator.SetTrigger("icon_5");
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Numbers")]
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int currentHealth;

    [Header("Health Bar Set Up")]
    [SerializeField] Slider healthSlider;

    private CameraShake cameraShake;

    [Header("Sprites")]
    [SerializeField] private SpriteRenderer bodySR;
    [SerializeField] private SpriteRenderer legsSR;
    [SerializeField] private Material whiteFlashMat;
    private Material bodyDefaultMat;
    private Material legsDefaultMat;

    private void Awake()
    {
        cameraShake = GetComponent<CameraShake>();
        bodyDefaultMat = bodySR.material;
        legsDefaultMat = legsSR.material;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        cameraShake.StartCoroutine(cameraShake.ScreenShakeCo());
        StartCoroutine(FlashCo());

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            cameraShake.StopCameraShake();
            this.gameObject.SetActive(false);
        }

        healthSlider.value = currentHealth;
    }

    public void HealHealth(int amount)
    {
        currentHealth += amount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthSlider.value = currentHealth;
    }

    public void RaiseMaxHealth(int amount)
    {
        maxHealth += amount;
        HealHealth(amount);
        healthSlider.maxValue = maxHealth;
    }

    public IEnumerator FlashCo()
    {
        bodySR.color = new Color(1f, 1f, 1f, 0.5f);
        legsSR.color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(0.2f);
        bodySR.color = Color.white;
        legsSR.color = Color.white;
    }
}

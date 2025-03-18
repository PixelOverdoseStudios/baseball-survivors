using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    [Header("Health Numbers")]
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int currentHealth;

    [Header("Health Bar Set Up")]
    [SerializeField] Slider healthSlider;

    [SerializeField] private CameraShake cameraShake;

    [Header("Sprites")]
    [SerializeField] private SpriteRenderer bodySR;
    [SerializeField] private SpriteRenderer legsSR;
    [SerializeField] private Material whiteFlashMat;
    private Material bodyDefaultMat;
    private Material legsDefaultMat;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;

        bodyDefaultMat = bodySR.material;
        legsDefaultMat = legsSR.material;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        cameraShake.StartCoroutine(cameraShake.ScreenShakeCo());
        StartCoroutine(FlashCo());

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            this.gameObject.SetActive(false);
        }

        UpdateHealthBar();
    }

    public void HealHealth(int amount)
    {
        currentHealth += amount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateHealthBar();
    }

    public void RaiseMaxHealth(int amount)
    {
        maxHealth += amount;
        HealHealth(amount);
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public IEnumerator FlashCo()
    {
        bodySR.color = new Color(1f, 1f, 1f, 0.5f);
        legsSR.color = new Color(1f, 1f, 1f, 0.5f);
        yield return new WaitForSeconds(0.2f);
        bodySR.color = Color.white;
        legsSR.color = Color.white;
    }

    public int GetPlayerMaxHealth() => maxHealth;
}

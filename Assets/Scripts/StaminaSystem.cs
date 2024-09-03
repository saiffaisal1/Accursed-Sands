using UnityEngine;
using UnityEngine.UI;

public class StaminaSystem : MonoBehaviour
{
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRegenRate = 10f;
    public float regenDelay = 2f;

    private bool isRegenerating = false;
    private float regenTimer;

    public Slider staminaSlider;

    void Start()
    {
        currentStamina = maxStamina;

        if (staminaSlider != null)
        {
            staminaSlider.maxValue = maxStamina;
            staminaSlider.value = currentStamina;
        }
    }

    void Update()
    {
        if (isRegenerating)
        {
            RegenerateStamina();
        }
        else
        {
            regenTimer += Time.deltaTime;
            if (regenTimer >= regenDelay)
            {
                isRegenerating = true;
            }
        }

        if (staminaSlider != null)
        {
            staminaSlider.value = currentStamina;
        }
    }

    // Method to check if there is enough stamina for an action
    public bool CanPerformAction(float staminaCost)
    {
        return currentStamina >= staminaCost;
    }

    // Method to consume stamina when an action is performed
    public void ConsumeStamina(float staminaCost)
    {
        if (CanPerformAction(staminaCost))
        {
            currentStamina -= staminaCost;
            regenTimer = 0f;
            isRegenerating = false;
        }
    }

    void RegenerateStamina()
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        }
        else
        {
            isRegenerating = false;
        }
    }
}

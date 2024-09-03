
using UnityEngine;
using UnityEngine.UI;

public class StamBar2 : MonoBehaviour{
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRegenRate = 10f;
    public float staminaDrainAmount = 20f;
    public float dashStaminaCost = 30f;
    public float regenDelay = 2f;

    private bool isRegenerating = false;
    private float regenTimer;

    public Slider stamSlider;

    void Start()
    {
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dash();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }

        if (stamSlider != null)
        {
            stamSlider.value = currentStamina;
        }
    }

    void Dash()
    {
        if (currentStamina >= dashStaminaCost)
        {
            currentStamina -= dashStaminaCost;
            regenTimer = 0f;
            isRegenerating = false;
        }
    }

    void Attack()
    {
        if (currentStamina >= staminaDrainAmount)
        {
            currentStamina -= staminaDrainAmount;
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

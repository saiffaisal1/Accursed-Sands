using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;

    public HealthBar healthbar;

    public Animator animator;
 


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.MaxHealth = maxHealth;
        healthbar.healthSlider.maxValue = maxHealth;
        healthbar.easeHealthSlider.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.health = currentHealth;

        if (Input.GetKeyDown(KeyCode.F))
        {
            takeDamage(10);
            animator.SetTrigger("Hurt");
        }
    }

    void takeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.setHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();

        }
    }

    void Die()
    {
        animator.SetBool("isDead", true);


        cantMove();
        cantAttack();
    }


    void cantMove()
    {
        GetComponent<PlayerMovement>().enabled = false;
    }

    void cantAttack()
    {
        GetComponent<PlayerCombat>().enabled = false;
    }

}

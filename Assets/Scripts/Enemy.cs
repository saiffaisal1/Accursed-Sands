using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;


    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;

    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;

        //Play hurt animation
        animator.SetTrigger("Hurt");


        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
        {
            //Die
            animator.SetBool("isDead", true);

            //Disable the enemy
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            
        }

}

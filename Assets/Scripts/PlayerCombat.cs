using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform AttackPoint;
    public LayerMask EnemyLayers;
    public float Attackrange = 0.5f;
    public int attackDamage = 40;
    public float attackRate = 1f;
    float nextAttacktime = 0f;
    public StaminaSystem stam;
    public float staminaAttackCost = 20f;


    void Update()
    {
        if (Time.time >= nextAttacktime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && stam.CanPerformAction(staminaAttackCost))
            {
                Attack();
                nextAttacktime = Time.time + 1 / attackRate;
                stam.ConsumeStamina(staminaAttackCost);
            }
        }
       
    }

    void Attack() {
        animator.SetTrigger("Attack");


        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(AttackPoint.position, Attackrange, EnemyLayers);

        foreach (Collider2D enemy in hitenemies)
        {
            enemy.GetComponent<Enemy>().takeDamage(attackDamage);

        }
    }

    void OnDrawGizmosSelected() {

        if (AttackPoint == null)
        {
            return;
        }
        
        Gizmos.DrawWireSphere(AttackPoint.position, Attackrange);


    }

}
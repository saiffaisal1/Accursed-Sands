using System.Collections;
using System.Collections.Generic;
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


    void Update()
    {
        if (Time.time >= nextAttacktime)
        {
            GetComponent<PlayerMovement>().enabled = true;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttacktime = Time.time + 1 / attackRate;
<<<<<<< Updated upstream
                GetComponent<PlayerMovement>().enabled = false;
=======
>>>>>>> Stashed changes
                

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform AttackPoint;
    public float Attackrange = 0.5f;
    public LayerMask EnemyLayers;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            Attack();

        }
    }

    void Attack() {
        animator.SetTrigger("Attack");

        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(AttackPoint.position, Attackrange, EnemyLayers);

        foreach (Collider2D enemy in hitenemies)
        {
            Debug.Log("We hit " + enemy.name);

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

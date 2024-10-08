using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    private float vertical;
    private float horizontal;
    public float speed = 5f;
    private bool isFacingRight = true;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    public StaminaSystem stam;
    public float dashStaminaCost = 30f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;

    private void Update()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("isDead"))
        {
            speed = 0f;
        }
        else{
            speed = 5f;
        }

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            speed = 0f;
        } 
        else 
        {
            speed = 5f;
        }

        if (isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space) && canDash && stam.CanPerformAction(dashStaminaCost))
        {
            animator.SetBool("IsDashing", true);
            StartCoroutine(Dash());            
            stam.ConsumeStamina(dashStaminaCost);
        }

        animator.SetFloat("Speed", rb.velocity.magnitude);

        Flip();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal, vertical).normalized * speed;
        
    }


    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            Vector3 localScale = transform.localScale;
            isFacingRight = !isFacingRight;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(horizontal, vertical).normalized * dashingPower;
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        isDashing = false;
        animator.SetBool("IsDashing", false);
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
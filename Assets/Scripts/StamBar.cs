using UnityEngine;
using UnityEngine.UI;

public class StamBar : MonoBehaviour
{
    public Slider stamSlider;
    public float maxStam;
    public float stam;
    private float dashCost = 20;
    private float attackCost = 5;
    [HideInInspector] public bool hasRegened = true;
    [SerializeField] private Animator animator;

    [Range(0, 50)] [SerializeField] private float stamRegen = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update(){
        if(stamSlider.value != stam){
            stamSlider.value = stam;
        }

        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !animator.GetCurrentAnimatorStateInfo(0).IsName("isDashing"))
        {
            if (stam <= maxStam - 0.01)
            {
                stam += stamRegen * Time.deltaTime;

                if (stam >= maxStam)
                {
                    hasRegened = true;
                }
            }
        }

        if (stam <= 0)
        {
            stamSlider.value = 0;
            hasRegened = false;
        }
    }

    void FixedUpdate()
    {
        stamAttack();
        stamDash();

    }



    public void stamAttack()
    {
        if (stam >= (maxStam * attackCost / maxStam) && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            stam -= attackCost;
        }
    }

    public void stamDash()
    {
        if (stam >= (maxStam * dashCost / maxStam) && animator.GetCurrentAnimatorStateInfo(0).IsName("isDashing"))
        {
            stam -= dashCost;
        }
    }

}

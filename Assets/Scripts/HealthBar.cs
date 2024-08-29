using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider healthSlider;
    public Slider easeHealthSlider;
    public int MaxHealth;
    public int health;
    [SerializeField] private float lerpSpeed;

    void Start(){
        
    }

    void Update(){
        if (healthSlider.value != health){
            healthSlider.value = health;
        }

        if (healthSlider.value != easeHealthSlider.value){
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);
        }
    }
    public void setHealth(int health)
    {
        healthSlider.value = health; 
    }

}

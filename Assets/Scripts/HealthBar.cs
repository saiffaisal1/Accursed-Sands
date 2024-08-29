using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;


    private void Start(){
        
    }
    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }


    public void setHealth(int health)
    {

    slider.value = health; 
    
    }

}

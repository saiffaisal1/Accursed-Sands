using UnityEngine;
using UnityEngine.UI;

public class StamBar : MonoBehaviour
{
    public Slider stamSlider;
    public int maxStam;
    public int stam;
    void Start()
    {
        stam = maxStam;
    }

    void Update(){
        if(stamSlider.value != stam){
            stamSlider.value = stam;
        }
    }

    public void setStam(int stam){
        stamSlider.value = stam;
    }
}

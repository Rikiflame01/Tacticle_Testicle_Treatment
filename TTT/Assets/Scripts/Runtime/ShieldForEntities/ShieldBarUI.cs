using UnityEngine;
using UnityEngine.UI;


public class ShieldBarUI : MonoBehaviour
{
    public Slider shieldSlider;

     public void UpdateShieldBar(int shieldValue)
    {
        shieldSlider.value = shieldValue;
    }
}


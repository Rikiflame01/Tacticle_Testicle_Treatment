using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider healthSlider;

    public void UpdateHealthBar(int currentHealth)
    {
        healthSlider.value = currentHealth;
    }
}

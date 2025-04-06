using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider slider;
    public void SetHealth()
    {
        slider.value = HealthManager.Instance.getCurrentHealth();
    }

    private void Update()
    {
        SetHealth();
    }
}

using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider _slider;
    public Gradient _gradient;
    public Image _fill;

    public void setMaxHealth(float health)
    {
        _slider.maxValue = health;
        _slider.value = health;

       _fill.color = _gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        _slider.value = health;

        _fill.color = _gradient.Evaluate(_slider.normalizedValue);

    }

}

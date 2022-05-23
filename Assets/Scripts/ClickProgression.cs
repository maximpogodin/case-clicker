using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClickProgression : MonoBehaviour
{
    private Slider slider;
    public int progressionMaxValue = 100;
    public float smoothTime = 1f;

    private void Awake() 
    {
        slider = GetComponent<Slider>();
        slider.maxValue = progressionMaxValue;
        slider.value = 0;
    }

    public void ValueChanged()
    {
        if (slider.value >= slider.maxValue)
        {
            slider.value = 0;
        }
    }

    private IEnumerator IncreaseSliderSmooth(float clickPower)
    {
        float curValue = slider.value;
        float nextValue = slider.value + clickPower;

        float elapsedTime = 0f;

        while (elapsedTime < smoothTime)
        {
            slider.value = Mathf.Lerp(curValue, nextValue, elapsedTime / smoothTime);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        slider.value = nextValue;
    }

    public void IncreaseSlider(float clickPower)
    {
        StartCoroutine(IncreaseSliderSmooth(clickPower));
    }
}
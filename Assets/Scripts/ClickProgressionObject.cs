using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClickProgressionObject : MonoBehaviour
{
    [Header("Progression settings")]
    [SerializeField]
    private ClickProgression _clickProgression;
    [SerializeField]
    private float _inactionCooldown;

    private Slider slider;
    private ClickerObject _clickerObject;

    private float _timeLeft;

    private void Awake() 
    {
        _clickerObject = FindObjectOfType<ClickerObject>();
        slider = GetComponent<Slider>();
        slider.maxValue = _clickProgression.MaxValue;
        slider.value = 0;
    }

    private void Start()
    {
        StartCoroutine(DecreaseSliderForInaction());
    }

    private IEnumerator IncreaseSliderSmooth(float clickPower)
    {
        float curValue = slider.value;
        float nextValue = slider.value + clickPower;

        float elapsedTime = 0f;

        while (elapsedTime < _clickProgression.IncrementSmoothDuration)
        {
            slider.value = Mathf.Lerp(curValue, nextValue, elapsedTime / _clickProgression.IncrementSmoothDuration);
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        slider.value = nextValue;

        if (slider.value >= slider.maxValue)
        {
            slider.value = 0;
            _clickerObject.IncreaseMultiplier(_clickProgression.IncrementMultiplier);
        }
    }

    public IEnumerator DecreaseSliderSmooth()
    {
        //float curValue = slider.value;
        //float prevValue = slider.value - 1f;

        //float elapsedTime = 0f;

        //while (elapsedTime < _clickProgression.DecrementSmoothDuration)
        //{
        //    slider.value = Mathf.Lerp(curValue, prevValue, elapsedTime / _clickProgression.DecrementSmoothDuration);
        //    elapsedTime += Time.deltaTime;

        //    yield return null;
        //}

        //StartCoroutine(DecreaseSliderSmooth());

        //while (true)
        //{
        //    if (_clickerObject.GetClickMultiplier() <= 1f)
        //        break;

        //    slider.value = Mathf.Lerp(curValue, prevValue, elapsedTime / _clickProgression.SmoothDuration);
        //    elapsedTime += Time.deltaTime;

        //    yield return null;

        //    if (_clickerObject.GetClickMultiplier() > 1f)
        //    {
        //        if (slider.value <= 0f)
        //        {
        //            slider.value = slider.maxValue;
        //        }
        //    }
        //}

        //_isCoroutineRunning = false;
        //StopCoroutine("DecreaseSliderSmooth");

        yield return null;
    }

    private IEnumerator DecreaseSliderForInaction()
    {
        while (true)
        {
            yield return new WaitForSeconds(_inactionCooldown);

            slider.value -= 1f;

            if (_clickerObject.Click.ClickMultiplier > 1f)
            {
                if (slider.value <= 0f)
                {
                    slider.value = slider.maxValue;
                    _clickerObject.DecreaseMultiplier();
                }
            }
        }
    }

    public void IncreaseSlider(float clickPower)
    {
        slider.value += clickPower;

        if (slider.value >= slider.maxValue)
        {
            slider.value = 0;
            _clickerObject.IncreaseMultiplier(_clickProgression.IncrementMultiplier);
        }

        //StartCoroutine(IncreaseSliderSmooth(clickPower));
    }
}
using UnityEngine;
using UnityEngine.UI;

public class ClickParticle : MonoBehaviour
{
    private Text _text;

    private void Awake()
    {
        _text = GetComponentInChildren<Text>();
    }

    public void UpdateText(string text)
    {
        _text.text = text;
    }
}
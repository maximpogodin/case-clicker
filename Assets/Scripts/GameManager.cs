using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameStats _gameStats;

    [Header("Text for resources")]
    [SerializeField]
    private Text textCoin;
    [SerializeField]
    private Text textStone;
    [SerializeField]
    private Text textCrystal;

    private void Awake()
    {
        _gameStats = new GameStats();

        textCoin = GameObject.Find("TextCoin").GetComponent<Text>();
        textStone = GameObject.Find("TextStone").GetComponent<Text>();
        textCrystal = GameObject.Find("TextCrystal").GetComponent<Text>();
    }

    public void IncreaseResourceValue(ResourceType resourceType, float value)
    {
        Resource resource = _gameStats.GetResource(resourceType);
        resource.InreaseValue(value);

        UpdateResourceText(resourceType, ValueFormatter.GetFormattedValue(resource.GetValue()));
    }

    public void UpdateResourceText(ResourceType resourceType, string text)
    {
        switch (resourceType)
        {
            case ResourceType.Coin:
                textCoin.text = text;
                break;
            case ResourceType.Stone:
                textStone.text = text;
                break;
            case ResourceType.Crystal:
                textCrystal.text = text;
                break;
        }
    }
}
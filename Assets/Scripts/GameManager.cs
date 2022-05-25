using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameStats _gameStats;

    [Header("Text for resources")]
    [SerializeField]
    private Text textCoin;
    [SerializeField]
    public Text textStone;
    [SerializeField]
    public Text textCrystal;

    private void Awake()
    {
        _gameStats = new GameStats();
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
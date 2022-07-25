using UnityEngine;

public enum Rarity
{
    Common,
    Unique,
    Rare,
    Legendary,
    Hybrid
}

[System.Serializable]
public class Card : MonoBehaviour
{
    public Rarity Rarity { get; set; }
    public decimal Cost { get; set; }
}
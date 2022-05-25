public enum ResourceType
{
    Coin,
    Crystal,
    Stone
}

public class Resource
{
    private float _value;
    private ResourceType _resourceType;
    public ResourceType ResourceType
    {
        get { return _resourceType; }
        set { _resourceType = value; }
    }

    public Resource()
    {
        _value = 0;
    }

    public void InreaseValue(float value)
    {
        _value += value;
    }

    public float GetValue()
    {
        return _value;
    }

    public override string ToString()
    {
        return ValueFormatter.GetFormattedValue(_value);
    }
}
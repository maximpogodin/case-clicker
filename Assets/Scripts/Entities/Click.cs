public class Click
{
    private float _clickPower;
    public float ClickPower
    {
        get { return _clickPower; }
        set { _clickPower = value; }
    }

    private float _clickMultiplier;
    public float ClickMultiplier
    {
        get { return _clickMultiplier; }
        set { _clickMultiplier = value; }
    }

    public Click(float clickPower)
    {
        ClickPower = clickPower;
    }
}
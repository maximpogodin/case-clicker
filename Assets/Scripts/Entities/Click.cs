public class Click
{
    private float _clickPower;
    public float ClickPower
    {
        get { return _clickPower; }
        set { _clickPower = value; }
    }

    public Click(float clickPower)
    {
        ClickPower = clickPower;
    }
}
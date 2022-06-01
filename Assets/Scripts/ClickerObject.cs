using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickerObject : MonoBehaviour, IPointerClickHandler
{
    [Header("Click settings")]
    public Click Click;

    [Header("Other")]
    [SerializeField]
    private Transform _parent;
    private ClickProgressionObject _clickProgression;
    public float textClickDropForce;
    public float particleDropForce;
    public float Z;
    public float rotation;

    private GameManager _gameManager;
    private Camera _mainCamera;

    [SerializeField]
    private Transform _textParticleTransform;

    private Vector3 _textParticlePosition;

    [SerializeField]
    private Transform _textParticleParent;

    [SerializeField]
    private Text _comboText;

    private void Awake() 
    {
        _mainCamera = Camera.main;
        _gameManager = FindObjectOfType<GameManager>();
        _clickProgression = FindObjectOfType<ClickProgressionObject>();
    }

    private void Start()
    {
        _textParticlePosition = _mainCamera.WorldToScreenPoint(_textParticleTransform.position);
    }

    public void IncreaseMultiplier(float value)
    {
        Click.ClickMultiplier += value;
        _comboText.text = $"x{ValueFormatter.GetFormattedValue(Click.ClickMultiplier)}";
    }

    public void DecreaseMultiplier()
    {
        if (Click.ClickMultiplier > 0f)
        {
            Click.ClickMultiplier -= 0.1f;
            _comboText.text = $"x{ValueFormatter.GetFormattedValue(Click.ClickMultiplier)}";
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        float randomSize = Random.RandomRange(0.5f, 1f);
        Vector3 randomScale = new Vector3(randomSize, randomSize, randomSize);

        TextParticle textParticle = TextParticlePool.SharedInstance.GetPooledObject();
        if (textParticle != null)
        {
            textParticle.transform.parent = _textParticleParent;
            textParticle.transform.position = _textParticlePosition;
            textParticle.transform.rotation = Quaternion.identity;
            textParticle.gameObject.transform.localScale = randomScale;
            textParticle.ShowTextParticle();
            textParticle.UpdateText(ValueFormatter.GetFormattedValue(Click.ClickPower * Click.ClickMultiplier));
        }

        //var particleClone = Instantiate(particlePrefab, particlePosition, Quaternion.identity);
        //particleClone.GetComponent<Rigidbody>().AddForce(randomPosition * particleDropForce);
        //Destroy(particleClone, 1f);

        //var clickParticleClone = Instantiate(_clickParticlePrefab, _parent);
        //clickParticleClone.transform.position = eventData.position;

        //Rigidbody2D rb = clickParticleClone.GetComponent<Rigidbody2D>();
        //rb.AddForce(randomPosition * textClickDropForce);
        //rotation = randomPosition.x <= 0f ? rotation : -rotation;
        //rb.AddTorque(rotation);

        //clickParticleClone.transform.SetAsFirstSibling();
        //clickParticleClone.transform.localScale = randomScale;

        //clickParticleClone.GetComponent<ClickParticle>().UpdateText((_click.ClickPower * _click.ClickMultiplier).ToString("f1"));

        //Destroy(clickParticleClone.gameObject, 1f);

        _clickProgression.IncreaseSlider(Click.ClickPower);
        _gameManager.IncreaseResourceValue(ResourceType.Stone, Click.ClickPower * Click.ClickMultiplier);
    }
}
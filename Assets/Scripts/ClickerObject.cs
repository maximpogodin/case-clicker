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

    public ParticlePool _dustPool;
    public ParticlePool _textPool;

    private void Awake() 
    {
        _mainCamera = Camera.main;
        _gameManager = FindObjectOfType<GameManager>();
        _clickProgression = FindObjectOfType<ClickProgressionObject>();
    }

    private void Start()
    {
        _textParticlePosition = _textParticleTransform.position;
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
        Particle dustObj = _dustPool.GetPooledObject();
        if (dustObj != null)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f));
            dustObj.transform.parent = _textParticleParent;
            dustObj.transform.position = _textParticlePosition + randomPosition;
            dustObj.SetAsFirst();
            dustObj.gameObject.SetActive(true);
        }

        Particle textObj = _textPool.GetPooledObject();
        if (textObj != null)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f));
            float randomSize = Random.Range(0.5f, 1f);
            Vector3 randomScale = new Vector3(randomSize, randomSize, randomSize);

            textObj.transform.parent = _textParticleParent;
            textObj.transform.position = _textParticlePosition + randomPosition;
            textObj.transform.rotation = Quaternion.identity;
            textObj.gameObject.transform.localScale = randomScale;
            textObj.SetAsFirst();
            textObj.gameObject.SetActive(true);
            (textObj as TextParticle).ShowTextParticle();
            (textObj as TextParticle).UpdateText(ValueFormatter.GetFormattedValue(Click.ClickPower * Click.ClickMultiplier));
        }

        _clickProgression.IncreaseSlider(Click.ClickPower);
        _gameManager.IncreaseResourceValue(ResourceType.Stone, Click.ClickPower * Click.ClickMultiplier);
    }
}
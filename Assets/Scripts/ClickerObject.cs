using UnityEngine;
using UnityEngine.EventSystems;

public class ClickerObject : MonoBehaviour, IPointerClickHandler
{
    [Header("Click settings")]
    [SerializeField]
    private Click _click;

    [Header("Other")]
    private GameObject _ui;
    private ClickProgressionObject _clickProgression;
    private GameObject particlePrefab;
    private GameObject _clickParticlePrefab;
    public float textClickDropForce;
    public float particleDropForce;
    public float Z;
    public float rotation;

    private GameManager _gameManager;

    private void Awake() 
    {
        _ui = GameObject.Find("UI");
        _gameManager = FindObjectOfType<GameManager>();
        _clickProgression = FindObjectOfType<ClickProgressionObject>();
        particlePrefab = Resources.Load<GameObject>("Prefabs/particlePrefab");
        _clickParticlePrefab = Resources.Load<GameObject>("Prefabs/clickParticlePrefab");
    }

    public float GetClickMultiplier()
    {
        return _click.ClickMultiplier;
    }

    public void IncreaseMultiplier(float value)
    {
        _click.ClickMultiplier += value;
    }

    public void DecreaseMultiplier()
    {
        if (_click.ClickMultiplier > 0f)
            _click.ClickMultiplier -= 0.1f;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        float randomSize = Random.RandomRange(0.5f, 1f);
        Vector3 randomScale = new Vector3(randomSize, randomSize, randomSize);
        Vector3 randomPosition = new Vector3(Random.RandomRange(-10f, 10f), Random.RandomRange(5f, 10f), Random.RandomRange(-10f, 10f));

        Vector3 particlePosition = Input.mousePosition;
        particlePosition.z = Z;
        particlePosition = Camera.main.ScreenToWorldPoint(particlePosition);

        var particleClone = Instantiate(particlePrefab, particlePosition, Quaternion.identity);
        particleClone.GetComponent<Rigidbody>().AddForce(randomPosition * particleDropForce);
        Destroy(particleClone, 1f);

        var clickParticleClone = Instantiate(_clickParticlePrefab, _ui.transform);
        clickParticleClone.gameObject.AddComponent<ClickParticle>();
        clickParticleClone.transform.position = eventData.position;
        clickParticleClone.GetComponent<Rigidbody2D>().AddForce(randomPosition * textClickDropForce);
        rotation = randomPosition.x <= 0f ? rotation : -rotation;
        clickParticleClone.GetComponent<Rigidbody2D>().AddTorque(rotation);
        clickParticleClone.transform.SetAsFirstSibling();
        clickParticleClone.transform.localScale = randomScale;
        clickParticleClone.GetComponent<ClickParticle>().UpdateText((_click.ClickPower * _click.ClickMultiplier).ToString("f1"));
        Destroy(clickParticleClone.gameObject, 1f);

        _clickProgression.IncreaseSlider(_click.ClickPower);
        _gameManager.IncreaseResourceValue(ResourceType.Stone, _click.ClickPower * _click.ClickMultiplier);
    }
}
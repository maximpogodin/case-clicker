using UnityEngine;
using UnityEngine.EventSystems;

public class ClickerObject : MonoBehaviour, IPointerClickHandler
{
    private Click _click;
    [Header("Stats values")]
    [SerializeField]
    private float _clickPower;

    [Header("Other")]
    public GameObject ui;
    private ClickProgression _clickProgression;
    private GameObject particlePrefab;
    private GameObject textClickDamagePrefab;
    public float textClickDropForce;
    public float particleDropForce;
    public float Z;
    public float rotation;

    private GameManager _gameManager;

    private void Awake() 
    {
        _click = new Click(_clickPower);

        _gameManager = FindObjectOfType<GameManager>();
        _clickProgression = FindObjectOfType<ClickProgression>();
        particlePrefab = Resources.Load<GameObject>("Prefabs/particlePrefab");
        textClickDamagePrefab = Resources.Load<GameObject>("Prefabs/textClickDamagePrefab");
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

        var textClickDamageClone = Instantiate(textClickDamagePrefab, ui.transform);
        textClickDamageClone.transform.position = eventData.position;
        textClickDamageClone.GetComponent<Rigidbody2D>().AddForce(randomPosition * textClickDropForce);
        rotation = randomPosition.x <= 0f ? rotation : -rotation;
        textClickDamageClone.GetComponent<Rigidbody2D>().AddTorque(rotation);
        textClickDamageClone.transform.SetAsFirstSibling();
        textClickDamageClone.transform.localScale = randomScale;
        Destroy(textClickDamageClone, 1f);

        _clickProgression.IncreaseSlider(_click.ClickPower);
        _gameManager.IncreaseResourceValue(ResourceType.Stone, _click.ClickPower);
    }
}
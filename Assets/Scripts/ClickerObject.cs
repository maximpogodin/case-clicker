using UnityEngine;
using UnityEngine.EventSystems;

public class ClickerObject : MonoBehaviour, IPointerClickHandler
{
    public GameObject ui;
    private ClickProgression clickProgression;
    private GameObject particlePrefab;
    private GameObject textClickDamagePrefab;
    public float textClickDropForce;
    public float particleDropForce;
    public float clickPower = 1f;
    public float Z;
    public float rotation;

    private void Awake() 
    {
        clickProgression = FindObjectOfType<ClickProgression>();
        particlePrefab = Resources.Load<GameObject>("Prefabs/particlePrefab");
        textClickDamagePrefab = Resources.Load<GameObject>("Prefabs/textClickDamagePrefab");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 particlePosition = Input.mousePosition;
        particlePosition.z = Z;
        particlePosition = Camera.main.ScreenToWorldPoint(particlePosition);

        Vector3 randomPosition = new Vector3(Random.RandomRange(-10f, 10f), Random.RandomRange(5f, 10f), Random.RandomRange(-10f, 10f));
        var particleClone = Instantiate(particlePrefab, particlePosition, Quaternion.identity);
        particleClone.GetComponent<Rigidbody>().AddForce(randomPosition * particleDropForce);
        Destroy(particleClone, 1f);

        var textClickDamageClone = Instantiate(textClickDamagePrefab, ui.transform);
        textClickDamageClone.transform.position = eventData.position;
        textClickDamageClone.GetComponent<Rigidbody2D>().AddForce(randomPosition * textClickDropForce);
        rotation = randomPosition.x <= 0f ? rotation : -rotation;
        textClickDamageClone.GetComponent<Rigidbody2D>().AddTorque(rotation);
        textClickDamageClone.transform.SetAsFirstSibling();
        Destroy(textClickDamageClone, 1f);

        clickProgression.IncreaseSlider(clickPower);
    }
}
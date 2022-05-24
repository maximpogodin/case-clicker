using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickerObject : MonoBehaviour, IPointerClickHandler
{
    private ClickProgression clickProgression;
    private GameObject particlePrefab;
    public float particleDropForce;
    public float clickPower = 1f;
    public Vector3 particlePosition; 
    public float Z;

    private void Awake() 
    {
        clickProgression = GameObject.FindObjectOfType<ClickProgression>();
        particlePrefab = Resources.Load<GameObject>("Prefabs/particlePrefab");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        particlePosition = Input.mousePosition;
        particlePosition.z = Z;
        particlePosition = Camera.main.ScreenToWorldPoint(particlePosition);

        Vector3 randomPosition = new Vector3(Random.RandomRange(-10f, 10f), Random.RandomRange(5f, 10f), Random.RandomRange(-10f, 10f));
        var particleClone = Instantiate(particlePrefab, particlePosition, Quaternion.identity);
        particleClone.GetComponent<Rigidbody>().AddForce(randomPosition * particleDropForce);

        Destroy(particleClone, 1f);

        clickProgression.IncreaseSlider(clickPower);
    }
}
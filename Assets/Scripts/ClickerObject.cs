using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickerObject : MonoBehaviour, IPointerClickHandler
{
    public ClickProgression clickProgression;
    public GameObject particlePrefab;
    public float textClickDropSpeed;
    public float clickPower = 1f;

    private void Awake() 
    {
        clickProgression = GameObject.FindObjectOfType<ClickProgression>();
        particlePrefab = Resources.Load<GameObject>("Prefabs/particlePrefab");

        if (GetComponent<BoxCollider>() == null)
            this.AddComponent<BoxCollider>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 randomPosition = new Vector3(Random.RandomRange(-10f, 10f), Random.RandomRange(5f, 10f), Random.RandomRange(-10f, 10f));
        var textClickClone = Instantiate(particlePrefab, eventData.pointerCurrentRaycast.worldPosition, Quaternion.identity);
        textClickClone.GetComponent<Rigidbody>().AddForce(randomPosition * textClickDropSpeed);

        Destroy(textClickClone, 1f);

        clickProgression.IncreaseSlider(clickPower);
    }
}
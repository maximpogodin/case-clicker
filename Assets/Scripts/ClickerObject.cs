using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickerObject : MonoBehaviour, IPointerClickHandler
{
    private ClickProgression clickProgression;
    private GameObject particlePrefab;
    public float particleDropForce;
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
        var particleClone = Instantiate(particlePrefab, eventData.pointerCurrentRaycast.worldPosition, Quaternion.identity);
        particleClone.GetComponent<Rigidbody>().AddForce(randomPosition * particleDropForce);

        Destroy(particleClone, 1f);

        clickProgression.IncreaseSlider(clickPower);
    }
}
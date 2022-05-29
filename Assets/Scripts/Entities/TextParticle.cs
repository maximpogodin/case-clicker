using UnityEngine;
using UnityEngine.UI;

public class TextParticle : MonoBehaviour
{
    [SerializeField]
    private Text _text;
    private Rigidbody2D rigidbody;
    private Animator animator;
    [SerializeField]
    private float dropForce;
    [SerializeField]
    private float dropRotation;
    
    private float[] randomDirs = new float[] { -1, 1 };

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    public void UpdateText(string text)
    {
        _text.text = text;
    }

    public void AddForce()
    {
        Vector2 randomDirection = gameObject.transform.position;
        randomDirection.x *= randomDirs[Random.Range(0, 2)];

        rigidbody.AddForce(randomDirection * dropForce);
    }

    public void AddTorque()
    {
        rigidbody.AddTorque(dropRotation * randomDirs[Random.Range(0, 2)]);
    }

    public void ShowTextParticle()
    {
        gameObject.SetActive(true);
        transform.SetAsFirstSibling();
        animator.SetBool("Show", true);

        AddForce();
        AddTorque();
    }

    public void HideTextParticle()
    {
        animator.SetBool("Show", false);
        gameObject.SetActive(false);
    }
}
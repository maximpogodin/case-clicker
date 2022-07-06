using UnityEngine;

public class Particle : MonoBehaviour
{
    public void HideParticleObject()
    {
        gameObject.SetActive(false);
    }

    public void SetAsFirst()
    {
        transform.SetAsFirstSibling();
    }
}
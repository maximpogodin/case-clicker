using System.Collections.Generic;
using UnityEngine;

public class TextParticlePool : MonoBehaviour
{
    public static TextParticlePool SharedInstance;
    public List<TextParticle> pooledObjects;
    public TextParticle objectToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<TextParticle>();
        TextParticle tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.gameObject.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public TextParticle GetPooledObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].gameObject.activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
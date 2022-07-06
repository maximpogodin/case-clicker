using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ParticlePool : MonoBehaviour
{
    public List<Particle> pooledObjects;
    public Particle objectToPool;
    public int amountToPool;

    void Start()
    {
        pooledObjects = new List<Particle>();
        Particle tmp;

        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.gameObject.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public Particle GetPooledObject()
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
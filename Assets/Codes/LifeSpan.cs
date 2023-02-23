using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSpan : MonoBehaviour
{
    public float lifeTime = 2;
    void Start()
    {
        // Destroy's gameobject with a delay
        Destroy(gameObject, lifeTime);
    }
}

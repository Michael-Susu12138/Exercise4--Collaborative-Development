using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartReward : MonoBehaviour
{
    int speed;
    Rigidbody2D _rigidbody2D;
    void Start()
    {
        speed = Random.Range(40,100); 
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(-speed,0));
    }
}

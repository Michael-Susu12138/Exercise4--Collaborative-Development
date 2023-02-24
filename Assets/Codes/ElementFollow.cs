using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementFollow : MonoBehaviour
{
    // Start is called before the first frame update
    int speed = 10;
    Rigidbody2D _rigidbody2D;


    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        float ySpeed = Input.GetAxis("Vertical") * speed;
        _rigidbody2D.velocity = new Vector2(xSpeed, ySpeed);
    }
}

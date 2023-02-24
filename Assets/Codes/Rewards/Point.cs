using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    int speed;
    int pointValue = 10; // point collect for hitting coins
    // public GameObject pointSound;
    Rigidbody2D _rigidbody2D;
    GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(40,100);
        gameObject.transform.localScale = new Vector2(0.5f,0.5f);
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(-speed, 0));
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Trigger is on and both rigidbody
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            // When the player hits the coin - add the score and make point collect sound
            // Instantiate(pointSound, transform.position, Quaternion.identity);
            _gameManager.AddScore(pointValue);
            Destroy(gameObject);
        }

        if(other.CompareTag("kill"))
        {
            Destroy(gameObject);
        }
    }
}

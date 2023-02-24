using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spritePlayer;
    public int speed;
    public int pointValue;
    public int health;
    bool turnTime;
    // public Transform spawnPoint;
    // public Animator explosionAnimation;
    GameManager _gameManager;
    GameObject player;

    
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(-speed,0));
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _spritePlayer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    
    }

    void Update() {
            if (player.transform.position.x + 10 > transform.position.x) {
                // _rigidbody2D.AddForce(new Vector2(-speed,0));
                // _rigidbody2D.velocity = new Vector2(0,0);
                // _rigidbody2D.velocity = new Vector2(0,0);
                StartCoroutine(Flip(speed, true));
                // }
            }
            else if (player.transform.position.x + 10 < transform.position.x) {
                // _rigidbody2D.AddForce(new Vector2(speed,0));
                // _rigidbody2D.velocity = new Vector2(0,0);
                // _rigidbody2D.velocity = new Vector2(0,0);
                StartCoroutine(Flip(-speed, false));
                // if (_spritePlayer.flipX != true) {
                // }
            }
        }

    IEnumerator Flip(int velocity, bool turn) {
        _rigidbody2D.velocity = new Vector2(0,0);
        yield return new WaitForSeconds(1);
        _rigidbody2D.AddForce(new Vector2(velocity,0));
        _spritePlayer.flipX = turn;
    }

    
}

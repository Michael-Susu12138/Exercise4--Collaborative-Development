using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    int speed;
    public int pointValue;
    public int health;
    // public Transform spawnPoint;
    // public Animator explosionAnimation;
    GameManager _gameManager;

    
    void Start()
    {
        speed = Random.Range(40,100); 
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.AddForce(new Vector2(-speed,0));
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    
    }

    private void UpdateEnemy(int dmg,Collider2D other){
        health -= dmg;
        if(health <= 0){
            Destroy(gameObject);
            Destroy(other.gameObject);  
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Bullet")){
            // _label.text = "+"+pointValue;
            // Instantiate(_label,spawnPoint.position,Quaternion.identity);
            _gameManager.AddScore(pointValue);   
            UpdateEnemy(50,other);
            // _gameManager.AddExplosionEffects(explosionAnimation,spawnPoint);
        }
        if (other.CompareTag("Grenade")){
            UpdateEnemy(150,other);
        }
        if(other.CompareTag("kill")){
            Destroy(gameObject);
            // Destroy(other.gameObject); 
        }
    }

    
}

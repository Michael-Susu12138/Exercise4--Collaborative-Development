using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    Rigidbody2D _rigidbody2D;
    int speed;
    public int pointValue;
    private int totalPoint = 0;
    public int health;
    private float SplashRange = 3;
    // public Transform Grenade;
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
    private void BombZombie(){
        var hitColliders = Physics2D.OverlapCircleAll(transform.position,SplashRange);
        foreach (var Zombie in hitColliders) {
            if (Zombie.gameObject.CompareTag("Enemy")){
                var script = Zombie.gameObject.GetComponent<Enemy>();
                script.health -= 150;
                if(script.health <= 0){
                    // Destroy(Zombie.GetComponent<GameObject>);
                    totalPoint += script.pointValue;
                    Destroy(Zombie.gameObject);
                }

            }
            
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
            BombZombie();
            _gameManager.AddScore(totalPoint); 
            Destroy(other.gameObject);
            totalPoint = 0;
        }
        if(other.CompareTag("kill")){
            Destroy(gameObject);
            // Destroy(other.gameObject); 
        }
    }

    
}

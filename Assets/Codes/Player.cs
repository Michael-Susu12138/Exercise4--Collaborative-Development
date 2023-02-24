using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    int speed = 10;
    int bulletSpeed = 400;
    int grenadeSpeed = 600;
    
    public AudioClip shootSound;
    public Transform spawnPoint;
    public GameObject bulletPrefab;
   
    public Transform grenadeIconStatus;
    public GameObject grenadePrefab;
    // public GameObject grenadeIcon;
    public List<GameObject> totalGrenades = new List<GameObject>();
    int grenadeCounter;
    
    int lifeCounter; // player gets total 3 life
    public GameObject heartIcon;
    private List<GameObject> totalLife = new List<GameObject>(); // array to hold heart images
    // public GameObject deadSound;
    public string endGame = "GameOver";
    
    Rigidbody2D _rigidbody2D;
    AudioSource _audioSource;
    GameManager _gameManager;
    void Start()
    {
        lifeCounter = 3;
        grenadeCounter = 3;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        // GameObject firstGrenade = Instantiate(grenadeSticker, grenadeIconStatus.position, Quaternion.identity);
        // totalGrenades.Add(firstGrenade);
        for(int i = 0; i<3; i++){
            float gap = i*0.7f;
            totalLife.Add(Instantiate(heartIcon, new Vector2(-5.37f+gap,4.3f), Quaternion.identity));
        }
    }

    // Update is called once per frame
    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal") * speed;
        float ySpeed = Input.GetAxis("Vertical") * speed;
        _rigidbody2D.velocity = new Vector2(xSpeed, ySpeed);


        
        if(Input.GetButtonDown("Jump")){
            _audioSource.PlayOneShot(shootSound);
            GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed, 0));
        }
        if(Input.GetButtonDown("Grenade")){
            int grenadesCount = totalGrenades.Count;
            // _audioSource.PlayOneShot(shootSound); // grenade sound
            if(grenadeCounter > 0){
                GameObject newGrenade = Instantiate(grenadePrefab, spawnPoint.position, Quaternion.identity);
                newGrenade.GetComponent<Rigidbody2D>().AddForce(new Vector2(grenadeSpeed, 0));
                Destroy(totalGrenades[grenadeCounter-1]);
                totalGrenades.RemoveAt(grenadeCounter-1);
                --grenadeCounter;
            } 
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // if(other.CompareTag("Enemy") || other.CompareTag("Enemy2") || other.CompareTag("Enemy2V2") || other.CompareTag("Enemy3"))
        if(other.CompareTag("Enemy"))
        {
            // If no more heart left, then the player is dead.
            if (lifeCounter == 1) {
                _gameManager.resetScore();
               SceneManager.LoadScene(endGame);
            } else {
                // Instantiate(deadSound, transform.position, Quaternion.identity); // dead sound per collision
                lifeCounter = lifeCounter - 1; // when a zombie hits, lose 1 life
                Destroy(other.gameObject); // Destroy the zombie
                foreach(var item in totalLife){
                    Destroy(item);
                }
                totalLife.Clear();
                for(int i = 0; i<lifeCounter; i++){
                    float gap = i*0.7f;
                    totalLife.Add(Instantiate(heartIcon, new Vector2(-5.37f+gap,4.3f), Quaternion.identity));
                }
            }
        }
        else if(other.CompareTag("heart")){
            if(lifeCounter<3){
                lifeCounter += 1;
                foreach(var item in totalLife){
                    Destroy(item);
                }
                totalLife.Clear();
                for(int i = 0; i<lifeCounter; i++){
                    float gap = i*0.7f;
                    totalLife.Add(Instantiate(heartIcon, new Vector2(-5.37f+gap,4.3f), Quaternion.identity));
                }
                Destroy(other.gameObject);
            }
            else{
                Destroy(other.gameObject);
            }
            
        }
        
    }
}

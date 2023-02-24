using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    int speed = 10;
    int bulletSpeed = 400;

    int grenadeSpeed = 600;
    int lifeCounter; // player gets total 3 life

    public AudioClip shootSound;
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public GameObject grenadePrefab;
    public GameObject[] totalLife; // array to hold heart images
    // public GameObject deadSound;
    public string endGame = "GameOver";

    Rigidbody2D _rigidbody2D;
    AudioSource _audioSource;

    void Start()
    {
        lifeCounter = 3;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
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
            // _audioSource.PlayOneShot(shootSound); // grenade sound
            GameObject newGrenade = Instantiate(grenadePrefab, spawnPoint.position, Quaternion.identity);
            newGrenade.GetComponent<Rigidbody2D>().AddForce(new Vector2(grenadeSpeed, 0));
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.CompareTag("Enemy") || other.CompareTag("Enemy2") || other.CompareTag("Enemy2V2") || other.CompareTag("Enemy3"))
        {
            // If no more heart left, then the player is dead.
            if (lifeCounter == 1) {
               SceneManager.LoadScene(endGame);
            } else {
               // Instantiate(deadSound, transform.position, Quaternion.identity); // dead sound per collision
               lifeCounter = lifeCounter - 1; // when a zombie hits, lose 1 life
               Destroy(other.gameObject); // Destroy the zombie
               Destroy(totalLife[lifeCounter].gameObject); // Destroy's heart image per collision with zombie
            }
        }

    }
}

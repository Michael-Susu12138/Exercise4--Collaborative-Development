using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BB_bullet : MonoBehaviour
{
    int bulletSpeed = 300;

    public Transform spawnPoint;

    public GameObject bullet;

    IEnumerator Start()
    {
        while(true){
            GameObject newBullet = Instantiate(bullet, spawnPoint.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-bulletSpeed, 0));
            yield return new WaitForSeconds(5f);
        }
    }
}

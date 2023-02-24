using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickShoot : MonoBehaviour
{
    private int bulletSpeed = 200;
    public GameObject EnemyBullet;
    IEnumerator Start()
    {
        while(true){
            Instantiate(EnemyBullet, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(new Vector2(-bulletSpeed,0));
            yield return new WaitForSeconds(4f);
        }
        
    }
}

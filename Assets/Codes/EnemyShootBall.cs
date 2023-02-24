using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootBall : MonoBehaviour
{
    private int bulletSpeed = 300;
    public GameObject EnemyBullet;
    IEnumerator Start()
    {

        while(true){
            Instantiate(EnemyBullet, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>().AddForce(new Vector2(-bulletSpeed,0));
            yield return new WaitForSeconds(2f);
        }
        
    }
}

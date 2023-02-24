using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRespawn : MonoBehaviour
{
    public GameObject Heart;
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        
        while(true){
            Vector2 spawnPos = new Vector2(Random.Range(9,14),Random.Range(-5f, 5f) );
            Instantiate(Heart, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(10f);
        }
    }
}

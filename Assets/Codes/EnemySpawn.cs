using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
        // Start is called before the first frame update
    IEnumerator Start()
    {
        while(true){
            Vector2 spawnPos = new Vector2(Random.Range(35, 42),Random.Range(-19f, 19f) );
            Instantiate(Enemy, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(8f);
        }
        // for(int i = 0; i<30;i++){
        //     Vector2 spawnPos = new Vector2(Random.Range(-8.5f, 8.5f), Random.Range(10,20));
        //     Instantiate(week_enermy_red, spawnPos, Quaternion.identity);
        //     yield return new WaitForSeconds(.2f);
        // }
    }
}

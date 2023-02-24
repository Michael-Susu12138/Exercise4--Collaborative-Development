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
            Vector2 spawnPos = new Vector2(Random.Range(9,14),Random.Range(-5f, 5f) );
            Instantiate(Enemy, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(.7f);
        }
        // for(int i = 0; i<30;i++){
        //     Vector2 spawnPos = new Vector2(Random.Range(-8.5f, 8.5f), Random.Range(10,20));
        //     Instantiate(week_enermy_red, spawnPos, Quaternion.identity);
        //     yield return new WaitForSeconds(.2f);
        // }
    }
}

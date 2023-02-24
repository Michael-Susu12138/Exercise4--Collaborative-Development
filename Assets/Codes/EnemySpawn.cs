using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject RangeEnemy;
    public GameObject ChickEnemy;
    public string gameLevel;
        // Start is called before the first frame update
    IEnumerator Start()
    {
        if(gameLevel == "level1"){
            var count = 0;
            while(true){
                Vector2 spawnPos = new Vector2(Random.Range(9,14),Random.Range(-5f, 5f) );
                Instantiate(Enemy, spawnPos, Quaternion.identity);
                yield return new WaitForSeconds(.7f);
                count++;
                if(count == 10){
                    Instantiate(RangeEnemy, spawnPos, Quaternion.identity);
                    count = 0;
                }

            }
        } 
        else if (gameLevel == "level2"){
            var count = 0;
            while(true){
                Vector2 spawnPos = new Vector2(Random.Range(9,14),Random.Range(-5f, 5f) );
                Instantiate(Enemy, spawnPos, Quaternion.identity);
                yield return new WaitForSeconds(2f);
                count++;
                if(count == 10){
                    Instantiate(RangeEnemy, spawnPos, Quaternion.identity);
                    Instantiate(ChickEnemy, spawnPos, Quaternion.identity);
                    count = 0;
                }

            }
        }
        
    }
}

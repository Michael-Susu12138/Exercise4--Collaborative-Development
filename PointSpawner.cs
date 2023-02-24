using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawner : MonoBehaviour
{
    public GameObject pointPrefab;

    IEnumerator Start() {
        // Spawns point coins at a random order (after some time delay).
        for(int i = 0; i < 300; i ++){
            Vector2 spawnPos = new Vector2(Random.Range(7, 20), Random.Range(-4.30f,4.30f));
            pointPrefab.transform.localScale = new Vector3(0.12f,0.12f,1);
            Instantiate(pointPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(20f);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour
{
    public GameObject asteroidPrefab;
    
    private float spawnNext = 0;
    private float spawnRatePerMinute = 30;
    private float spawnRateIncrement = 1;

    void Start(){
        //float myTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnNext){
            spawnNext = Time.time + 60 / spawnRatePerMinute;
            spawnRatePerMinute += spawnRateIncrement;

            
            var rand = Random.Range(-Player2.xBorderLimit, Player2.xBorderLimit); // obtain dinamically the width of the camera

            var spawnPosition = new Vector2(rand, 10);

            Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
            
        }

    }
}
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject fallingBlockPrefab;
    Vector2 screenHalfSizeWorldUnits;
    public Vector2 secondsBetweenSpawnsMinMax;

    float nextSpawnTime;
    public float spawnAngleMax;



    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);   
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficufly.GetDifficultyPercent());

            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            fallingBlockPrefab.transform.localScale = new Vector2(Random.Range(1, 3), Random.Range(1, 3));
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y);
            
            
            Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
        }

        
        
    }
}

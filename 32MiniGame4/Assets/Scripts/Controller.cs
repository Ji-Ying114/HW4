using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{   
    [SerializeField] private GameObject upperObstaclePrefab;
    [SerializeField] private GameObject lowerObstaclePrefab;
    [SerializeField] private float spawnXPosition = 10f;
    [SerializeField] private float spawnYPositionMin = -3f;
    [SerializeField] private float spawnYPositionMax = 3f;
    [SerializeField] private float spawnInterval = 2f;
    //[SerializeField] private float obstacleMoveSpeed = 5f;
    [SerializeField] private float spawnTimerMin = 2f;
    [SerializeField] private float spawnTimerMax = 4f;

    private float spawnTimer;


    //subscribes to bird collision event
    private void OnEnable()
    {
        Bird bird = Locator.instance.bird;
        bird.OnBirdCollision += HandleBirdCollision;
    }

    //obstacle spawner
    void Start()
    {
        ResetSpawnTimer();
    }
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnObstacles();
            ResetSpawnTimer();
        }
    }

    private void ResetSpawnTimer()
    {
        spawnTimer = Random.Range(spawnTimerMin, spawnTimerMax);
    }

    private void SpawnObstacles()
    {
        float spawnYPosition = Random.Range(spawnYPositionMin, spawnYPositionMax);
        Instantiate(upperObstaclePrefab, new Vector3(spawnXPosition, spawnYPosition + spawnInterval, 0), Quaternion.identity);
        Instantiate(lowerObstaclePrefab, new Vector3(spawnXPosition, spawnYPosition - spawnInterval, 0), Quaternion.identity);
    }
    //handles bird collision event
    private void HandleBirdCollision()
    {   
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        //stops obstacle movement
        foreach (Obstacle obstacle in obstacles)
        {
            obstacle.StopMovement();
        }
        //stops spawning new obstacles
        enabled = false;
    }
}
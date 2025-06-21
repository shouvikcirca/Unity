using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;

    [SerializeField] float appleSpawnChance = 0.3f;
    [SerializeField] float coinSpawnChance = 0.5f;

    [SerializeField] float coinSeparationLength = 2;
    // [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f };
    [SerializeField] float[] lanes = { -94.06f, -90.09f };

    LevelGenerator levelGenerator;
    ScoreManager scoreManager;
    List<int> availableLanes = new List<int> { 0, 1 };

    

    void Start()
    {
        SpawnFences();
        SpawnApple();
        SpawnCoins();
    }


    public void Init(LevelGenerator levelGenerator, ScoreManager scoreManager)
    {
        this.levelGenerator = levelGenerator;
        this.scoreManager = scoreManager;
    }

    void SpawnFences()
    {
        int fencesToSpawn = Random.Range(0, 2); 

        for (int i = 0; i < fencesToSpawn; i++)
        {

            if (availableLanes.Count <= 0) break;

            int selectedLane = SelectLane();

            Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPosition, Quaternion.identity, this.transform);
        }


    }

    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }

    void SpawnApple()
    {

        if (Random.value > appleSpawnChance || availableLanes.Count <= 0) return;

        // if (availableLanes.Count <= 0) return;
        int selectedLane = SelectLane();

        // Vector3 spawnPosition = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Vector3 spawnPosition = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        Apple newApple = Instantiate(applePrefab, spawnPosition, Quaternion.identity, this.transform).GetComponent<Apple>();
        newApple.Init(levelGenerator);
    }

    void SpawnCoins()
    {

        if (Random.value > coinSpawnChance || availableLanes.Count <= 0 ) return;
        
        // if (availableLanes.Count <= 0) return;
        int selectedLane = SelectLane();

        int maxCoinsToSpawn = 4;
        int coinsToSpawn = Random.Range(1, maxCoinsToSpawn);

        float topOfChunkZPos = transform.position.z + (coinSeparationLength * 2f);

        for (int i = 0; i < coinsToSpawn; i++)
        {
            float spawnPositionZ = topOfChunkZPos - (i * coinSeparationLength);
            Vector3 spawnPosition = new Vector3(this.transform.position.x, this.transform.position.y, spawnPositionZ);
            Coin newCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity, this.transform).GetComponent<Coin>();
            newCoin.Init(scoreManager);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

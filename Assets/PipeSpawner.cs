using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 5f;
    public float minY = -2f;
    public float maxY = 2f;

    public GameManager gameManager;

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnRate;
    }

    void Update()
    {
        if (gameManager != null && gameManager.isGameOver)
        {
            return;
        }
        
        float adjustedSpawnRate = Mathf.Clamp(spawnRate - gameManager.elapsedTime * 0.02f, 0.8f, spawnRate);

        if (Time.time >= nextSpawnTime)
        {
            SpawnPipe();
            nextSpawnTime = Time.time + adjustedSpawnRate;
        }
    }

    void SpawnPipe()
    {
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(transform.position.x, randomY, 0);
        Instantiate(pipePrefab, spawnPos, Quaternion.identity);
    }
}

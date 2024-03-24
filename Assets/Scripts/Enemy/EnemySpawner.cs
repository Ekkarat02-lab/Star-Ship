using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private GameObject enemyPrefab; // กำหนด gameobject ที่ต้องการสร้าง
    public int numberOfEnemies; // จำนวน gameobject ที่ต้องการสร้าง

    public float spawnRadius = 10f; // รัศมีสุ่มตำแหน่ง

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Vector3 randomPosition = GetRandomPosition();
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPosition()
    {
        float randomX = Random.Range(-spawnRadius, spawnRadius);
        float randomY = Random.Range(-spawnRadius, spawnRadius);
        float randomZ = Random.Range(-spawnRadius, spawnRadius);
        Vector3 randomPosition = transform.position + new Vector3(randomX, randomY, randomZ);
        return randomPosition;
    }
}
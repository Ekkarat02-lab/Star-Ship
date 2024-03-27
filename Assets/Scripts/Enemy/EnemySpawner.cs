using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab; // กำหนด gameobject ที่ต้องการสร้าง
    public float spawnRadius = 10f; // รัศมีสุ่มตำแหน่ง
    public float spawnInterval = 10f; // ช่วงเวลาการสร้างศัตรูใหม่

    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval); // รอเวลาตามช่วงเวลาที่กำหนด
        }
    }

    void SpawnEnemy()
    {
        Vector3 randomPosition = GetRandomPosition();
        Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
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
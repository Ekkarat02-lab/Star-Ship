using System.Collections.Generic;
using UnityEngine;

public class Asteroidmanager : MonoBehaviour
{
    [SerializeField] private List<Asteroid> asteroids = new List<Asteroid>();
    [SerializeField] private int numberOfAsteroidsOnAnAxis = 10;
    [SerializeField] private int gridSpacing = 100;
    [SerializeField] private Vector3 maxScale = new Vector3(5f, 5f, 5f); // ขนาดสูงสุดของ Asteroid ในแต่ละแกน
    [SerializeField] private Vector3 minScale = new Vector3(1f, 1f, 1f); // ขนาดต่ำสุดของ Asteroid ในแต่ละแกน

    private void Start()
    {
        PlaceAsteroids();
    }

    private void PlaceAsteroids()
    {
        for (int x = 0; x < numberOfAsteroidsOnAnAxis; x++)
        for (int y = 0; y < numberOfAsteroidsOnAnAxis; y++)
        for (int z = 0; z < numberOfAsteroidsOnAnAxis; z++)
            InstantiateAsteroid(x, y, z);
    }

    private void InstantiateAsteroid(int x, int y, int z)
    {
        Vector3 position = new Vector3(transform.position.x + (x * gridSpacing) + AsteroidOffset(), 
            transform.position.y + (y * gridSpacing) + AsteroidOffset(),
            transform.position.z + (z * gridSpacing) + AsteroidOffset()); 

        Vector3 scale = new Vector3(Random.Range(minScale.x, maxScale.x),
            Random.Range(minScale.y, maxScale.y),
            Random.Range(minScale.z, maxScale.z));

        Asteroid newAsteroid = Instantiate(asteroids[Random.Range(0, asteroids.Count)], position, Quaternion.identity, transform);
        newAsteroid.transform.localScale = scale; // กำหนดขนาดของ Asteroid จากการสุ่ม
    }

    private float AsteroidOffset()
    {
        return Random.Range(-gridSpacing / 2f, gridSpacing / 2f);
    }
}
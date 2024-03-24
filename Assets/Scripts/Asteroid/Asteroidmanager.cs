using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroidmanager : MonoBehaviour
{
    [SerializeField] private List<Asteroid> asteroids = new List<Asteroid>();
    [SerializeField] private int numberOfAsteroidsOnAnAxis = 10;
    [SerializeField] private int gridSpacing = 100;

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
        Asteroid newAsteroid = Instantiate(asteroids[Random.Range(0, asteroids.Count)], position, Quaternion.identity, transform);
        // สุ่ม Asteroid จาก List และสร้างใหม่
    }

    private float AsteroidOffset()
    {
        return Random.Range(-gridSpacing / 2f, gridSpacing / 2f);
    }
}
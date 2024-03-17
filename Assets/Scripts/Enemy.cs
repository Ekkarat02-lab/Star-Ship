using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float objectSpeed = 0.5f;
    public float SecondsUntilDestroy = 2.5f;
    float startTime;
    GameSystem gameSystem;

    void Start()
    {
        startTime = Time.time;
        if (gameSystem == null)
        {
            GameObject _gameSystem = GameObject.FindGameObjectWithTag("GameController") as GameObject;
            gameSystem = _gameSystem.GetComponent<GameSystem>();
        }
    }

    void Update()
    {
        transform.Translate(0, 0, objectSpeed);
        if (Time.time - startTime >= SecondsUntilDestroy)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "bullet(Clone)")
        {
            gameSystem.getPoint();
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            gameSystem.getEnemy();
            Destroy(this.gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float minMoveSpeed = 1f;
    [SerializeField] private float maxMoveSpeed = 3f;
    [SerializeField] private float minMoveDistance = 5f;
    [SerializeField] private float maxMoveDistance = 10f;
    [SerializeField] private float minRotationSpeed = 30f;
    [SerializeField] private float maxRotationSpeed = 100f;
    [SerializeField] private float minScale = .8f;
    [SerializeField] private float maxScale = 1.2f;

    private Transform myT;
    private Vector3 moveDirection;
    private float moveSpeed;
    private Vector3 rotationAxis;
    private float rotationSpeed;

    private void Awake()
    {
        myT = transform;
    }

    private void Start()
    {
        // Randomize movement direction
        moveDirection = Random.insideUnitSphere.normalized;

        // Randomize movement speed
        moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);

        // Randomize movement distance
        float moveDistance = Random.Range(minMoveDistance, maxMoveDistance);

        // Set initial position
        myT.position += moveDirection * moveDistance;

        // Randomize rotation axis
        rotationAxis = Random.insideUnitSphere.normalized;

        // Randomize rotation speed
        rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);

        // Randomize scale
        Vector3 scale = Vector3.one;
        scale.x = Random.Range(minScale, maxScale);
        scale.y = Random.Range(minScale, maxScale);
        scale.z = Random.Range(minScale, maxScale);
        myT.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the asteroid
        myT.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // Rotate the asteroid
        myT.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
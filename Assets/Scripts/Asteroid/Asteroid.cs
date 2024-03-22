using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private float minScale = .8f;

    [SerializeField] private float maxScale = 1.2f;
    
    [SerializeField] private float RotationOffset = 100f;
    
    private Transform myT;

    private Vector3 randomRotation; 

    private void Awake()
    {
        myT = transform;
    }

    private void Start()
    {
        //random size
        Vector3 scale = Vector3.one;
        scale.x = Random.Range(minScale, maxScale);
        scale.y = Random.Range(minScale, maxScale);
        scale.z = Random.Range(minScale, maxScale);
        
        myT.localScale = scale;
        
        //random rotation
        randomRotation.x = Random.Range(-RotationOffset, RotationOffset);
        randomRotation.y = Random.Range(-RotationOffset, RotationOffset);
        randomRotation.z = Random.Range(-RotationOffset, RotationOffset);
        
        Debug.Log(randomRotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        myT.Rotate(randomRotation * Time.deltaTime);
    }

}

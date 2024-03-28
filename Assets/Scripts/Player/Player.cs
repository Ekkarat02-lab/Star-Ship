using System;
using Unity.VisualScripting;
using UnityEngine;

[DisallowMultipleComponent]
public class Player : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 50f;
    [SerializeField] private float turnSpeed = 60f;

    private Transform myT;

    private void Awake()
    {
        myT = transform;
        Debug.Log("We spin around");
    }

    private void Update()
    {
        Thrust();
        Turn();
    }

    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll");
        
        myT.Rotate(-pitch, yaw,-roll);
        
    }

    void Thrust()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            myT.position += myT.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        }

    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            gameObject.active = false;
        }
    }*/
    
    
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform Firepoint;
    
    public float fireRate;

    private float nextFire = 0.0f;
    
    public GameObject bullet;
    
    
    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
        Shooting();
    }

    void Shooting()
    {
        RaycastHit hit;

        if (Physics.Raycast(Firepoint.position, transform.TransformDirection(Vector3.forward), out hit, 100))
        {
            Debug.DrawRay(Firepoint.position , transform.TransformDirection(Vector3.forward) * hit.distance , Color.yellow);
        }
        
    }
    public void Fire()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}

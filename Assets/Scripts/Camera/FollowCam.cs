using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] private Transform target;
    
    [SerializeField] private Vector3 defaultDistance = new Vector3(0f, 2f, -10f);

    [SerializeField] private float distanceDamp = 10;

    [SerializeField] private float rotationalDamp = 10f;
    
    private Transform myT;

    public Vector3 velocity = Vector3.one;

    private void Awake()
    {
        myT = transform;
    }

    private void LateUpdate()
    {
        SmootFollow();
        
        //Vector3 toPos = target.position + (target.rotation * defaultDistance);
        //Vector3 curPos = Vector3.Lerp(myT.position, toPos, distanceDamp * Time.deltaTime);
        //myT.position = curPos;

        //Quaternion toRot = Quaternion.LookRotation(target.position - myT.position, target.up);
        //Quaternion curRot = Quaternion.Slerp(myT.rotation, toRot, rotationalDamp * Time.deltaTime);
        //myT.rotation = curRot;
    }

    void SmootFollow()
    {
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 curPos = Vector3.SmoothDamp(myT.position, toPos, ref velocity, distanceDamp);
        myT.position = curPos;
        
        myT.LookAt(target, target.up);
    }
    
}

using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Light))]
[RequireComponent(typeof(LineRenderer))]
public class laser : MonoBehaviour
{
   [SerializeField] float laserOffTime = .5f;
   
   [SerializeField] float maxDirtance = 300f;

   [SerializeField] private float fireDelay = 2f; 
   
   private LineRenderer lr;
   
   private Light laserLight;
   
   private bool canFire;

   
   
   private void Awake()
   {
      lr = GetComponent<LineRenderer>();
      laserLight = GetComponent<Light>();
   }

   private void Start()
   {
      lr.enabled = false;
      laserLight.enabled = false;
      canFire = true;
   }

   /*private void Update()
   {
      Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward) * maxDirtance, Color.green);
   }*/

   Vector3 CastRay()
   {
      RaycastHit hit;
      Vector3 fwb = transform.TransformDirection(Vector3.forward) * maxDirtance;

      if (Physics.Raycast(transform.position, fwb, out hit))
      {
         Debug.Log("We hit : "+ hit.transform.name);
         
         Explosion temp = hit.transform.GetComponent<Explosion>();
         if(temp != null)
            temp.IveBeenHit(hit.point);
         
         return hit.point;
      }
      
      Debug.Log("We missed...");
      return transform.position + (transform.forward * maxDirtance);
   }
   public void FireLaser()
   {
      if (canFire)
      {
         lr.SetPosition(0, transform.position);
         lr.SetPosition(1, CastRay());
         lr.enabled = true;
         laserLight.enabled = true;
         canFire = false;
         Invoke("TurnOffLaser", laserOffTime);
         Invoke("CanFire", fireDelay);
      }
      
   }

   void TurnOffLaser()
   {
      lr.enabled = false;
      laserLight.enabled = false;
   }

   public float Distance
   {
      get { return maxDirtance; }
   }

   void CanFire()
   {
      canFire = true;
   }
}

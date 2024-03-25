using UnityEngine;
using UnityEngine.UI;

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
   
   [SerializeField] private Text scoreText;
   private int points = 0;
   
   private void Awake()
   {
      lr = GetComponent<LineRenderer>();
      laserLight = GetComponent<Light>();
   }

   void Start()
   {
      lr.enabled = false;
      laserLight.enabled = false;
      canFire = true;
    
      // Call UpdateScoreText to initialize the score text
      UpdateScoreText();
   }

   
   Vector3 CastRay()
   {
      RaycastHit hit;
      Vector3 fwb = transform.TransformDirection(Vector3.forward) * maxDirtance;

      if (Physics.Raycast(transform.position, fwb, out hit))
      {
         Debug.Log("We hit : "+ hit.transform.name);
         
         SpawnExplosion(hit.point, hit.transform);
         
         return hit.point;
      }
      Debug.Log("We missed...");
      
      return transform.position + (transform.forward * maxDirtance);
   }

   void SpawnExplosion(Vector3 hitPosition, Transform target)
   {
      // Check if the target has the Enemy tag
      if (target.CompareTag("Enemy"))
      {
         // Destroy the enemy game object
         Destroy(target.gameObject);
        
         // Increase points by 1
         points++;
         // Update the score text
         UpdateScoreText();
      }
    
      Explosion temp = target.GetComponent<Explosion>();
      if (temp != null)
         temp.AddForce(hitPosition, transform);

   }
   
   public void FireLaser()
   {
      Vector3 pos = CastRay();
      FireLaser(pos);

   }

   public void FireLaser(Vector3 targetPosition, Transform target = null)
   {
      if (canFire)
      {
         if (target != null)
         {
            SpawnExplosion(targetPosition, target);
            
         }
         lr.SetPosition(0, transform.position);
         lr.SetPosition(1, targetPosition);
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
   
   void UpdateScoreText()
   {
      scoreText.text = "point : " + points.ToString();

      // Check if points equal to 10
      if (points == 10)
      {
         // Display "Winner" on the scene
         Debug.Log("Winner");
      }
   }


}
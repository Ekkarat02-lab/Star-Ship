using System;
using UnityEngine;

[DisallowMultipleComponent]
public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    [SerializeField] private Rigidbody rigidbody;

    [SerializeField] private float laserHitModifier = 100f;
    
    void IveBeenHit(Vector3 pos)
    {
        GameObject go = Instantiate(explosion, pos, Quaternion.identity, transform)as GameObject;
        Destroy(go,6f);
        //Debug.Log("We spin around");
        
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            IveBeenHit(contact.point);
        }
        
    }
    
    public void AddForce(Vector3 hitPosition, Transform hitSource)
    {
        IveBeenHit(hitPosition);
        
        if(rigidbody == null)
            return;

        Vector3 forceVector3 = (hitSource.position - hitPosition).normalized;
        rigidbody.AddForceAtPosition(forceVector3 * laserHitModifier, hitPosition, ForceMode.Impulse);
        
    }
}

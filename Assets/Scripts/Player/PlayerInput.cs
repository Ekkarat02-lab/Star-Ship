using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private laser[] _laser;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (laser l in _laser)
            {
                //Vector3 pos = transform.position + (transform.forward * l.Distance);
                l.FireLaser();   
            }
        }
    }
}

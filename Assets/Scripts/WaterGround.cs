using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGround : MonoBehaviour
{
    public float Speed = 0.5f;
    void Update()
    {
        float offset = Time.time;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -offset);
    }
}

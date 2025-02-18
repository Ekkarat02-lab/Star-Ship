using System;
using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private Canvas winnerCanvas;
    [SerializeField] private Player player;
    [SerializeField] private float countdownTime = 10f; // เวลานับถอยหลัง
    [SerializeField] private Text timerText;
    private float remainingTime;
    private bool isCountingDown = false;
    private List<int> shotPoints = new List<int>(); // บันทึกคะแนนในแต่ละครั้งที่ยิงได้

    
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
        remainingTime = countdownTime;
        isCountingDown = true;

        UpdateScoreText();
        UpdateTimerText();
    }
    
    void Update()
    {
        if (isCountingDown)
        {
            remainingTime -= Time.deltaTime;
            UpdateTimerText();

            if (remainingTime <= 0)
            {
                isCountingDown = false;
                player.enabled = false;
                Debug.Log("หมดเวลา!");
                winnerCanvas.gameObject.SetActive(true);
            }
        }
    }
    
    Vector3 CastRay()
    {
        RaycastHit hit;
        Vector3 fwb = transform.TransformDirection(Vector3.forward) * maxDirtance;

        if (Physics.Raycast(transform.position, fwb, out hit))
        {
            Debug.Log("We hit : " + hit.transform.name);
            SpawnExplosion(hit.point, hit.transform);
            return hit.point;
        }
        //Debug.Log("We missed...");

        return transform.position + (transform.forward * maxDirtance);
    }

    void SpawnExplosion(Vector3 hitPosition, Transform target)
    {
        if (target.CompareTag("Enemy"))
        {
            Destroy(target.gameObject);
            points++;
            shotPoints.Add(points); // เก็บคะแนนที่ยิงได้ในแต่ละครั้ง
            UpdateScoreText();
        }
    }

    void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.Max(0, Mathf.CeilToInt(remainingTime)).ToString();
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
    }
}

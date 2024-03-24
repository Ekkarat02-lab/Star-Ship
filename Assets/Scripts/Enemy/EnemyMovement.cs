using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementRange = 5f; // ระยะที่ศัตรูสามารถเคลื่อนที่ได้
    public float movementSpeed = 2f; // ความเร็วในการเคลื่อนที่ของศัตรู

    private Vector3 initialPosition; // ตำแหน่งเริ่มต้นของศัตรู
    private Vector3 targetPosition; // ตำแหน่งที่ศัตรูจะเคลื่อนที่ไป

    void Start()
    {
        initialPosition = transform.position; // เก็บตำแหน่งเริ่มต้น
        CalculateNewTargetPosition(); // คำนวณตำแหน่งที่จะเคลื่อนที่ไปเมื่อเริ่มเกม
    }

    void Update()
    {
        // เคลื่อนที่ศัตรูไปยังตำแหน่งเป้าหมาย
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        // เมื่อศัตรูเคลื่อนที่ถึงตำแหน่งเป้าหมาย
        if (transform.position == targetPosition)
        {
            CalculateNewTargetPosition(); // คำนวณตำแหน่งเป้าหมายใหม่
        }
    }

    // คำนวณตำแหน่งที่ศัตรูจะเคลื่อนที่ไป
    void CalculateNewTargetPosition()
    {
        float randomX = Random.Range(-movementRange, movementRange); // สุ่มตำแหน่ง X ใหม่
        float randomZ = Random.Range(-movementRange, movementRange); // สุ่มตำแหน่ง Z ใหม่

        targetPosition = initialPosition + new Vector3(randomX, 0f, randomZ); // ตำแหน่งเป้าหมายใหม่
        
        // ป้องกันไม่ให้ศัตรูเกินขอบเขตการเคลื่อนที่
        targetPosition.x = Mathf.Clamp(targetPosition.x, initialPosition.x - movementRange, initialPosition.x + movementRange);
        targetPosition.z = Mathf.Clamp(targetPosition.z, initialPosition.z - movementRange, initialPosition.z + movementRange);
    }
}
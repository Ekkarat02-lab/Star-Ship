using UnityEngine;

public class Shield : MonoBehaviour
{
    // ประกาศตัวแปร Health และกำหนดค่าเริ่มต้นเป็น 10
    [SerializeField]private int health = 10;

    // เมื่อเกิดการชนกับออบเจ็กต์ชื่อ "Asteroid"
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            // ลดค่า Health ลงทีล่ะ 1 หน่วย
            health -= 1;
            Debug.Log("Health: " + health);

            // ตรวจสอบว่า Health เป็น 0 หรือน้อยกว่าหรือไม่
            if (health <= 0)
            {
                // กระทำเมื่อ Health เป็น 0 หรือน้อยกว่า
                // เช่น ทำให้วัตถุถูกทำลาย หรืออื่นๆ
                Debug.Log("Shield depleted!");
            }
        }
    }
}
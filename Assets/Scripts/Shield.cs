using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    // ประกาศตัวแปร Health และกำหนดค่าเริ่มต้นเป็น 10
    [SerializeField] private int health = 10;
    public Text healthText; // ประกาศ Text สำหรับแสดง Health บน Canvas

    private void Start()
    {
        // ให้แสดงค่า Health เมื่อเริ่มเกม
        UpdateHealthText();
    }

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

            // ปรับปรุง Canvas Text
            UpdateHealthText();
        }
    }

    // อัปเดต Canvas Text ด้วยค่า Health ปัจจุบัน
    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health : " + health.ToString(); // กำหนดข้อความให้กับ Text
        }
    }
}
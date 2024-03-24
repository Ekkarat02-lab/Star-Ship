using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]private int health = 5; // Example starting health

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        
        if (health <= 0)
        {
            Die(); // You may want to implement a method to handle enemy death
        }
    }
    void Die()
    {
        // Handle enemy death, e.g., play death animation, give player points, etc.
        Destroy(gameObject); // Example: Destroy the enemy object
    }
}
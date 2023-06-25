using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLifetime = 3f;
    public float bulletDamage = 10f;

    private void Start()
    {
        Destroy(gameObject, bulletLifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check collision with objects you want to interact with
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Apply damage to the enemy
            // You can replace this code with your desired behavior
            collision.gameObject.SetActive(false); // Disabling the enemy for simplicity
        }

        // Destroy the bullet
        Destroy(gameObject);
    }
}

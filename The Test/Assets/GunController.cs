using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour
{
    public float damage = 10f;
    public float fireRate = 0.2f;
    public float bulletSpeed = 20f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public int maxAmmo = 30;
    public int currentAmmo;
    public float reloadTime = 2f;
    private bool isReloading = false;
    private float nextFireTime;

    private void Start()
    {
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        if (isReloading)
            return;

        if (Input.GetButton("Fire1") && Time.time >= nextFireTime && currentAmmo > 0)
        {
            nextFireTime = Time.time + fireRate;
            Fire();
            currentAmmo--;
        }
        else if (Input.GetButtonDown("Reload") && currentAmmo < maxAmmo)
        {
            StartCoroutine(Reload());
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, transform.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = bullet.transform.forward * bulletSpeed;
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        // Play reload animation or show UI progress bar

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
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
    }
}

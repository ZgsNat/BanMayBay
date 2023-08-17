using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float timestartshoot;
    public float timedelay;
    private void Start()
    {
        // Call the ShootBullet method after 1 second and then repeatedly every 0.1 seconds
        InvokeRepeating("ShootBullet", timestartshoot, timedelay);
    }

    private void ShootBullet()
    {
        // Instantiate a bullet at the player's position
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 25);

    }
}

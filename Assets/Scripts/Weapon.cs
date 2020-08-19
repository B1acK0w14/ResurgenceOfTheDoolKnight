using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shooter;
    private Transform _firePoint;

    private void Awake()
    {
        _firePoint = transform.Find("FirePoint");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Call Start!");
        Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        Debug.Log("Work Shoot!");
        if (bulletPrefab != null && _firePoint != null && shooter != null)
        {
            Debug.Log("Enter if!");
            GameObject myBullet = Instantiate(bulletPrefab, _firePoint.position, Quaternion.identity) as GameObject;
            Bullet bulletComponent = myBullet.GetComponent<Bullet>();

            // If shooter is looking right or left
            if (shooter.transform.localScale.x < 0f) {
                // Left
                bulletComponent.direction = Vector2.left;
            } else {
                // Right
                bulletComponent.direction = Vector2.right;
            }
        }
    }
}

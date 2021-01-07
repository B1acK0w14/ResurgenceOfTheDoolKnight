using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shooter;
    private Transform _firePoint;

    //Example of TestingRaycast2D
    //public GameObject explosionEffect;
    //public LineRenderer lineRenderer;

    private void Awake()
    {
        _firePoint = transform.Find("FirePoint");
    }

    // Start is called before the first frame update
    void Start()
    {
        //Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        if (bulletPrefab != null && _firePoint != null && shooter != null)
        {
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


    //Example of TestingRaycast2D
    //public IEnumerator ShootwithRaycast()
    //{
    //    if (explosionEffect != null && lineRenderer != null)
    //    {
    //        RaycastHit2D hitInfo = Physics2D.Raycast(_firePoint.position, _firePoint.right);
    //        if (hitInfo)
    //        {
    //            //Example code
    //            //if (hitInfo.collider.tag == "Player")
    //            //{
    //            //    Transform player = hitInfo.transform;
    //            //    player.GetComponent<PlayerHealth>().ApplyDamage(5);
    //            //}

    //            //Instantiate explosion on hit point
    //            Instantiate(explosionEffect, hitInfo.point, Quaternion.identity);

    //            //Set line renderer
    //            lineRenderer.SetPosition(0, _firePoint.position);
    //            lineRenderer.SetPosition(1, hitInfo.point);
    //        } else {
    //            lineRenderer.SetPosition(0, _firePoint.position);
    //            lineRenderer.SetPosition(1, hitInfo.point + Vector2.right * 100);
    //        }

    //        lineRenderer.enabled = true;

    //        yield return null;

    //        lineRenderer.enabled = false;
    //    }
    //}
}

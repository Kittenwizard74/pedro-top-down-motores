using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerBalas : MonoBehaviour
{
    //enum SpawnerType { Straight, Spin}

    //[Header("atributos bala")]
    //public GameObject bullet;
    //public float bulletlife = 1f;
    //public float speed = 1f;

    //[Header("atributos spawner")]
    //[SerializeField] private SpawnerType spawnerType;
    //[SerializeField] private float firerate = 1f;

    //private GameObject spawnedBullet;
    //public float timer = 0f;


    //void Update()
    //{
    //    timer += Time.deltaTime;
    //    if (spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f, 0f, transform.eulerAngles.y + 1f);
    //    if(timer >= firerate)
    //    {
    //        Fire();
    //        timer = 0f;
    //    }
    //}

    //private void Fire()
    //{
    //    if (bullet)
    //    {
    //        spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
    //        spawnedBullet.GetComponent<bala>().speed = speed;
    //        spawnedBullet.GetComponent<bala>().bulletLife = bulletlife;
    //        spawnedBullet.transform.rotation = transform.rotation;
    //    }
    //}

    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float fireRate = 1f; 
    private float fireTimer = 0f; 
    public float bulletSpeed = 1f;
    private void Update()
    {
        
        fireTimer += Time.deltaTime;

        
        if (fireTimer >= 1f / fireRate)
        {
            Fire();
            fireTimer = 0f; 
        }
    }

    private void Fire()
    {
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, bulletPrefab.transform.rotation);

        
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = firePoint.forward * bulletSpeed;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPos;
    [SerializeField] private float fireRate;
    [SerializeField] private float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            InvokeRepeating("spawnBullet", 0f, fireRate);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            CancelInvoke("spawnBullet");
        }
    }

    void spawnBullet()
    {
        GameObject bulletTemp = Instantiate(bullet, bulletPos.position, transform.rotation);
        bulletTemp.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }
}

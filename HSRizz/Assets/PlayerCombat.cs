using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{


    public GameObject bulletPrefab;

    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10;

    private Bullet.bulletType currentBullet = Bullet.bulletType.Flattery;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            currentBullet = Bullet.bulletType.Flattery;
        }
        if(Input.GetKeyDown(KeyCode.E)){
            currentBullet = Bullet.bulletType.Humor;
        }
        if(Input.GetKeyDown(KeyCode.R)){
            currentBullet = Bullet.bulletType.Intelligence;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Bullet>().type = currentBullet;
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
        }
    }
}

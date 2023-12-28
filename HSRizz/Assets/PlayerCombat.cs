using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public enum bulletType {
        Flattery,
        Humor,
        Intelligence
    }

    public GameObject bulletPrefab;

    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10;

    private bulletType currentBullet = bulletType.Flattery;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            currentBullet = bulletType.Flattery;
        }
        if(Input.GetKeyDown(KeyCode.E)){
            currentBullet = bulletType.Humor;
        }
        if(Input.GetKeyDown(KeyCode.R)){
            currentBullet = bulletType.Intelligence;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<SpriteRenderer>().color = currentBullet == bulletType.Flattery ? Color.magenta : currentBullet == bulletType.Humor ? Color.yellow : Color.blue;
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
        }
    }
}

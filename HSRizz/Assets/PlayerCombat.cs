using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{


    public GameObject bulletPrefab;

    public AudioSource audioSource;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10;

    public Animator animator;

    private Bullet.bulletType currentBullet = Bullet.bulletType.Flattery;

    public float intervalForSpam = 0.5f; // Time interval to consider for spamming
    private int clickCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
            audioSource.Play();
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Bullet>().type = currentBullet;
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
            clickCount++;
        }
        if (!IsInvoking("CheckSpamming"))
        {
            Invoke("CheckSpamming", intervalForSpam);
        }
    }

    void CheckSpamming()
    {
        if (clickCount > 0) // Define how many clicks you consider as spamming
        {
            animator.SetBool("Click", true);
            // Handle spamming action here
        }
        else
        {
            animator.SetBool("Click", false);
        }

        clickCount = 0; // Reset click count after checking
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteract : MonoBehaviour
{
    public AudioSource audioSource;

    private EnemySpawning enemySpawner;
    public float health = 20;
    public float damage = 10;
    public Bullet.bulletType type = Bullet.bulletType.Flattery;
    private bool isDead = false;

    public int rizzAmt = 1;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = GameObject.Find("GameManager").GetComponent<EnemySpawning>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0 && !isDead){
            audioSource.Play();
            enemySpawner.dead++;
            Destroy(gameObject, .1f);
            RizzCoins.increaseRizz(rizzAmt);
            isDead = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bullet") && other.GetComponent<Bullet>().type == this.type){
            audioSource.Play();
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(Damaged());
            health -= other.gameObject.GetComponent<Bullet>().damage;
            other.gameObject.GetComponent<Bullet>().playAnimation();
            Destroy(other.gameObject, 2f);
        }
        else if(other.CompareTag("Bullet")){
            audioSource.Play();
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(Damaged());
            health -= other.gameObject.GetComponent<Bullet>().damage * .1f;
            other.gameObject.GetComponent<Bullet>().playAnimation();
            Destroy(other.gameObject, 2f);
        }
    }

    IEnumerator Damaged()
    {
        yield return new WaitForSeconds(.1f);
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}

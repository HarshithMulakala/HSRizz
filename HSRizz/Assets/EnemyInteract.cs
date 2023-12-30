using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteract : MonoBehaviour
{
    public float health = 20;
    public float damage = 10;
    public Bullet.bulletType type = Bullet.bulletType.Flattery;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            Destroy(gameObject);
            RizzCoins.increaseRizz(1);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bullet") && other.GetComponent<Bullet>().type == this.type){
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine(Damaged());
            health -= other.gameObject.GetComponent<Bullet>().damage;
            other.gameObject.GetComponent<Bullet>().playAnimation();
            Destroy(other.gameObject, 2f);
        }
        else if(other.CompareTag("Bullet")){
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

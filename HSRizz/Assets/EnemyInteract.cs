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
        GetComponent<SpriteRenderer>().color = type == Bullet.bulletType.Flattery ? Color.magenta : type == Bullet.bulletType.Humor ? Color.yellow : Color.blue;
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
            health -= other.gameObject.GetComponent<Bullet>().damage;
            Destroy(other.gameObject);
        }
        else if(other.CompareTag("Bullet")){
            health -= other.gameObject.GetComponent<Bullet>().damage * .1f;
            Destroy(other.gameObject);
        }
    }
}

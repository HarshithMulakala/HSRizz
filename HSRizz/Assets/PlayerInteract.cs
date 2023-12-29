using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float health = 100;

    private Dictionary<Collision2D, float?> collisions = new Dictionary<Collision2D, float?>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {    
        if(!collisions.TryGetValue(collision, out float? value) && collision.gameObject.tag == "Enemy"){
            health -= collision.gameObject.GetComponent<EnemyInteract>().damage;
            collisions[collision] = 0;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collisions.TryGetValue(collision, out float? value) && collision.gameObject.tag == "Enemy"){
            collisions[collision] += Time.deltaTime;
        }
        if(collisions.TryGetValue(collision, out float? thing) && collision.gameObject.tag == "Enemy" && collisions[collision] >= 1.5){
            health -= collision.gameObject.GetComponent<EnemyInteract>().damage;
            collisions[collision] = 0;
        }
    }

    void OnCollisionExit2D(Collision2D collision) 
    {
        if(collisions.TryGetValue(collision, out float? value) && collision.gameObject.tag == "Enemy"){
            collisions.Remove(collision);
        }
    }
}

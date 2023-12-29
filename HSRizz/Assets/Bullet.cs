using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum bulletType {
        Flattery,
        Humor,
        Intelligence
    }

    public int damage = 10;
    public bulletType type = bulletType.Flattery; 
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = type == bulletType.Flattery ? Color.magenta : type == bulletType.Humor ? Color.yellow : Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}

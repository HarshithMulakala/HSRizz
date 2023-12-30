using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{
    public float health = 100;
    public float maxHealth = 100;

    private Dictionary<Collision2D, float?> collisions = new Dictionary<Collision2D, float?>();

    private bool shopActive = false; 
    public GameObject panel;

    public HealthBar healthBar;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0){
            animator.SetBool("Death", true);
            Destroy(gameObject, .5f);
            SceneManager.LoadScene(0);
        }
        if(!shopActive && Input.GetKeyDown(KeyCode.Escape)){
            shopActive = true;
            panel.SetActive(true);   
        }
        else if(shopActive && Input.GetKeyDown(KeyCode.Escape)){
            shopActive = false;
            panel.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {    
        if(!collisions.TryGetValue(collision, out float? value) && collision.gameObject.tag == "Enemy"){
            health -= collision.gameObject.GetComponent<EnemyInteract>().damage;
            healthBar.SetHealth(health/maxHealth);
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
            healthBar.SetHealth(health/maxHealth);
            collisions[collision] = 0;
        }
    }

    void OnCollisionExit2D(Collision2D collision) 
    {
        if(collisions.TryGetValue(collision, out float? value) && collision.gameObject.tag == "Enemy"){
            collisions.Remove(collision);
        }
    }

    public void SetMaxHealth(float max){
        maxHealth = max;
    }
}

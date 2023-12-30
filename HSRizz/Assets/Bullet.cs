using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Sprite arrow;
    public Sprite book;
    public Sprite laugh;
    public enum bulletType {
        Flattery,
        Humor,
        Intelligence
    }

    public int damage = 10;
    public Animator animator;
    public bulletType type = bulletType.Flattery; 
    // Start is called before the first frame update
    public void playAnimation(){
        animator.SetBool("hit", true);
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        if(type == bulletType.Flattery){
            animator.SetBool("F", true);
            animator.SetBool("I", false);
            animator.SetBool("H", false);
        }
        else if(type == bulletType.Humor){
           animator.SetBool("H", true);
            animator.SetBool("F", false);
             animator.SetBool("I", false);
        }
        else{
            animator.SetBool("I", true);
            animator.SetBool("H", false);
            animator.SetBool("F", false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}

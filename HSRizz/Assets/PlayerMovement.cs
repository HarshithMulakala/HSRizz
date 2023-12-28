using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed;
    private Rigidbody2D rb;

    public GameObject center;
    public Animator animator;
    private SpriteRenderer sr;
    public Sprite DR;
    public Sprite D;
    public Sprite DL;
    public Sprite L;
    public Sprite UL;
    public Sprite U;
    public Sprite UR;
    public Sprite R;
    private Vector2 playerDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector2(directionX, directionY).normalized;
        animator.SetFloat("X", directionX);
        animator.SetFloat("Y", directionY);
        animator.SetFloat("Speed", playerDirection.sqrMagnitude);
/**
        if(playerDirection.y == 1){
            sr.sprite = DR;
        }
        else if(playerDirection.y == -1){
            sr.sprite = U;
        }
        else if(playerDirection.x == 1){
            sr.sprite = R;
        }
        else if(playerDirection.x == -1){
            sr.sprite = L;
        }
        else if(playerDirection.x > 0 && playerDirection.y > 0){
            sr.sprite = UR;
        }
        else if(playerDirection.x < 0 && playerDirection.y > 0){
            sr.sprite = UL;
        }
        else if(playerDirection.x < 0 && playerDirection.y < 0){
            sr.sprite = DL;
        }
        else{
            sr.sprite = DR;
        }
**/
        
        //Debug.Log("y " + playerDirection.y);
        //Debug.Log("m " + playerDirection.magnitude);

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);
    }
}

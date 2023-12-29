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

        if(directionX != 0 || directionY != 0){
            animator.SetFloat("LastX", directionX);
            animator.SetFloat("LastY", directionY);
        }

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);
    }
}

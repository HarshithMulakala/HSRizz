using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private GameObject player;
    private Animator myAnim;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 2 * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed);
        Vector2 movement = (player.transform.position - transform.position).normalized;
        myAnim.SetFloat("Horizontal", movement.x);
        myAnim.SetFloat("Vertical", movement.y);
        myAnim.SetFloat("Magnitude", movement.magnitude);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 moveDirection;
    Rigidbody2D rb;
    CollisionState collisionState;
    Transform tr;
    Animator an;

    public float speed, jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collisionState = GetComponent<CollisionState>();
        tr = GetComponent<Transform>();
        an = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Always call move function, pass move direction from OnMove
        Move(moveDirection);

        if(collisionState.standing){
            an.SetBool("isJumping", false);
        }else{
            an.SetBool("isJumping", true);
        }
    }

    // Handles movement of player
    void Move(Vector2 direction){
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }

    // Called whenever move action is executed
    public void OnMove(InputAction.CallbackContext context){
        // Updates move direction with input direction
        moveDirection =  context.ReadValue<Vector2>();

        // Pass move direction to animator, will play walking animation if player is moving
        an.SetFloat("speed", Mathf.Abs(moveDirection.x));

        // Flip sprite based on movement direction by setting localScale
        tr.localScale = moveDirection.x < 0f ? new Vector3 (-3, 3, 1) : new Vector3 (3, 3, 1);

    }

    // Called whenever jump action is executed
    public void OnJump(InputAction.CallbackContext context){
        // Check if touching ground before jumping
        if(collisionState.standing){
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            an.SetBool("isJumping", true);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
      if (other.gameObject.tag == "DeathZone"){
        tr.position = Vector3.zero;
      }
    }

}

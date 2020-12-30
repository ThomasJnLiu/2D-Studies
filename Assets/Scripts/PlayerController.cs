using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    Transform tr;
    Animator an;

    public float moveSpeed, jumpForce;
    private Vector2 moveDirection;
    public Color debugColor = Color.red;
    private CollisionState collisionState;



    // Start is called before the first frame update
    void Start()
    {
        collisionState = GetComponent<CollisionState>();
        an = GetComponent<Animator>();
        tr = GetComponent<Transform>();
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
      rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }

    // Called whenever move action is executed
    public void OnMove(InputAction.CallbackContext context){
      // Updates move direction with input direction
      moveDirection = context.ReadValue<Vector2>();

      // Pass move direction to animator, will play walking animation if player is moving
      an.SetFloat("speed", Mathf.Abs(moveDirection.x));

      // Flip sprite based on movement direction by setting localScale
      tr.localScale = moveDirection.x < 0f ? new Vector3 (-1, 1, 1) : new Vector3 (1, 1, 1);
    }

    // Called whenever jump action is executed
    public void OnJump(){
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

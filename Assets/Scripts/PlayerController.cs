using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    public float moveSpeed, jumpForce;
    private Vector2 moveDirection;
    public Color debugColor = Color.red;
    private CollisionState collisionState;



    // Start is called before the first frame update
    void Start()
    {
        collisionState = GetComponent<CollisionState>();
    }

    // Update is called once per frame
    void Update()
    {
      // Always call move function, pass move direction from OnMove
      Move(moveDirection);
    }

    // Handles movement of player
    void Move(Vector2 direction){
      rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }

    // Called whenever move action is executed
    public void OnMove(InputAction.CallbackContext context){
      // Updates move direction with input direction
      moveDirection = context.ReadValue<Vector2>();
    }

    // Called whenever jump action is executed
    public void OnJump(){
      // Check if touching ground before jumping
      if(collisionState.standing){
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
      }
    
    }

}

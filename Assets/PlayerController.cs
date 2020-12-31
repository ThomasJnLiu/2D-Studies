using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 moveDirection;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(moveDirection);
    }

    public void OnMove(InputAction.CallbackContext context){
        moveDirection =  context.ReadValue<Vector2>();
    }

    void Move(Vector2 direction){
        rb.velocity = new Vector2(direction.x * 10, rb.velocity.y);
    }

}

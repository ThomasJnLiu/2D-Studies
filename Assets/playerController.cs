using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
    }
}

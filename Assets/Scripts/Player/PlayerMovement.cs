using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{    
    [SerializeField] private float speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    private void Move()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
     //   anim.SetFloat("Speed", rb.velocity.magnitude);
        rb.velocity = new Vector2(inputX, inputY) * speed;
    }

    void Update()
    {
        Move();
    }
}
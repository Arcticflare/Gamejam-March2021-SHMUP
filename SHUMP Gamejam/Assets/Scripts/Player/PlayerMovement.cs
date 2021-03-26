using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    

    public float speed = 10;
    public float dashDistance = 2;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        Dash();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float HorizonalMove = x * speed;
        rb.velocity = new Vector2(HorizonalMove , rb.velocity.y);

        float y = Input.GetAxisRaw("Vertical");
        float VerticalMove = y * speed / 2;
        rb.velocity = new Vector2(rb.velocity.x, VerticalMove);
    }

    void Dash()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 currentPos = transform.position;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += new Vector3(dashDistance * x, 0f, 0f);

            if ( (transform.position.x > 3.3f) || (transform.position.x < -3.3f) )
            {
                transform.position = currentPos;
            }
        }

        
        
    }
}

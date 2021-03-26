using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    
    float left; 
    float right; 
    float down; 
    float up; 

    [SerializeField]
    float dashSpeed = 100;
    
    [SerializeField]
    float speed = 10;

    [SerializeField]
    float dashDistance = 3;
    
    bool dashing;
    Vector2 dashStart;
    Vector2 dashDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Get the in-game coordinates for the edge of the screen
        right = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        left = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        up = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        down = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
    }

    private void Update()
    {
        // Make sure player can't go outside screen
        if (transform.position.x > right) {
            transform.position = new Vector3(right, transform.position.y, transform.position.z);
        }
        if (transform.position.x < left) {
            transform.position = new Vector3(left, transform.position.y, transform.position.z);
        }
        if (transform.position.y > up) {
            transform.position = new Vector3(transform.position.x, up, transform.position.z);
        }
        if (transform.position.y < down) {
            transform.position = new Vector3(transform.position.x, down, transform.position.z);
        }

        // var x = Input.GetAxisRaw("Horizontal");
        // var y = Input.GetAxisRaw("Vertical");

        // if (Input.GetKeyDown(KeyCode.Space) && (x >= 0 || y >= 0)) {
        //     if (!dashing) {
        //         dashing = true;
        //         dashStart = (Vector2)transform.position;
        //         dashDirection.x = x;
        //         dashDirection.y = y;
        //     }
        // }

        // Move(x, y);
        
        // if (dashing) {
        //     Dash(x, y);
        // }
    }

    void Move(float x, float y)
    {
        if (dashing) {
            return;
        }
        // Makes a vector length of 1.
        // If moving diagonally and input is 1, 1, then vector length will be 1.4142135623730951
        // Which means we'll be moving 41% faster than usual if multiplied with speed
        // So, we use the normalized vector which will make sure the vector length is always 1
        var norm = new Vector2(x, y).normalized;

        rb.velocity = norm * speed;
    }

    void Dash(float x, float y)
    {
        var norm = new Vector2(x, y).normalized;

        rb.velocity = norm * dashSpeed;
        
        if (Vector3.Distance(transform.position, dashStart) >= dashDistance) {
            dashing = false;
        }
    }
    
    public void MoveInput(InputAction.CallbackContext context) {
        Debug.Log("Move! " + context);
    }
}

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
    public InputAction input;
    bool dashing;
    Vector2 dashStart;
    Vector2 dashDirection;

    [SerializeField]
    float dashSpeed = 100;
    
    [SerializeField]
    float speed = 10;

    [SerializeField]
    float dashDistance = 3;
    

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable() 
    {
        input.Disable();    
    }
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
        // No longer needs to be normalized, Input does this from gui.
        // Causes error when anything other than wasd (bound) are pressed,
        // Consider instead finding inputType.
        Vector2 inputVector = input.ReadValue<Vector2>();

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

        Move(inputVector);
    }

    void Move(Vector2 vector)
    {
        if (dashing) {
            return;
        }

        rb.velocity = vector * speed;
    }

    void Dash(Vector2 vector)
    {
        rb.velocity = vector * dashSpeed;
        
        if (Vector3.Distance(transform.position, dashStart) >= dashDistance) {
            dashing = false;
        }
    }
    
    public void MoveInput(InputAction.CallbackContext context) {
        Debug.Log("Move! " + context);
    }
}

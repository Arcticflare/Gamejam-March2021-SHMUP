using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 inputDirection;
    [SerializeField] float speed = 10;

    [SerializeField] float dashForce = 20;
    bool dashing;
    float dashStartTimer = .25f;
    float dashTimer;
    Vector2 dashDirection;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(inputDirection.x, inputDirection.y) * speed;

        if (dashing)
        {
            //what info is in transform.right - convert for x and y consecutively.
            rb.velocity = transform.right * inputDirection * dashForce;

            dashTimer -= Time.deltaTime;

            if (dashTimer <= 0)
            {
                dashing = false;
            }
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        inputDirection = context.ReadValue<Vector2>();
    }

    public void Dash(InputAction.CallbackContext context)
    {
        dashing = context.performed;
        dashTimer = dashStartTimer;

        Debug.Log("Dashing");
    }

    public void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Pew Pew");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 inputDirection;
    Vector2 currentVelocity;
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
        currentVelocity = new Vector2(inputDirection.x, inputDirection.y);

        rb.velocity = currentVelocity * speed;

        if (dashing)
        {
            rb.velocity = currentVelocity * dashForce;

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
    }

    public void Fire(InputAction.CallbackContext context)
    {
        Debug.Log("Pew Pew");
    }
}

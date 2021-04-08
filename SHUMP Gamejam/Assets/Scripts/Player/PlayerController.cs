using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 10;
    Vector2 input;

    void Update()
    {
        rb.velocity = new Vector2(input.x * speed, input.y * speed);
    }

    public void Move(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }

    public void Dash(InputAction.CallbackContext context)
    {
        Debug.Log("Dashing!");
    }
}

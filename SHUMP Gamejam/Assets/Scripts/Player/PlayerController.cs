using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 10;
    float inputValueX;
    float inputValueY;

    void Update()
    {
        rb.velocity = new Vector2(inputValueX * speed, inputValueY * speed);
    }

    public void Move(InputAction.CallbackContext context)
    {
        inputValueX = context.ReadValue<Vector2>().x;
        inputValueY = context.ReadValue<Vector2>().y;
    }

    public void Dash(InputAction.CallbackContext context)
    {
        Debug.Log("Dashing!");
    }
}

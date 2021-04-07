using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    Rigidbody2D rb;
    [SerializeField]float speed = 10;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 moveVector = playerInput.Player.Movement.ReadValue<Vector2>();
        rb.velocity = moveVector * speed;
    }
}

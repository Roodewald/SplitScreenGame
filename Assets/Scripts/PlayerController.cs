using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRb;

    private float moveSpeed = 5f;
    private Vector2 moveInput;

    public bool inSafeZone;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moveInput * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SafeZone"))
        {
            inSafeZone = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("SafeZone"))
        {
            inSafeZone = false;
        }
    }
}
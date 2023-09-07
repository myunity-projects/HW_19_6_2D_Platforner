using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void OnMove(InputValue inputValue)
    {
        GlobalVariables.moveInput = inputValue.Get<Vector2>();
    }

    void OnJump(InputValue inputValue)
    {
        playerMovement.Jump();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput input;
    public PlayerInput.OnGroundActions onGround;

    private PlayerMovement playerMovement;
    private PlayerLook playerLook;
    void Awake()
    {
        input = new PlayerInput();
        onGround = input.OnGround;
        playerMovement = GetComponent<PlayerMovement>();
        playerLook = GetComponent<PlayerLook>();
        onGround.Jump.performed += ctx => playerMovement.jump();
        onGround.Sprint.performed += ctx => playerMovement.Sprint();
        onGround.Crouch.performed += ctx => playerMovement.Crouch();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerMovement.Movement(onGround.Movement.ReadValue<Vector2>());
        playerLook.Look(onGround.Look.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
    }

    private void OnEnable()
    {
        onGround.Enable();
    }

    private void OnDisable()
    {
        onGround.Disable();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    // Create singleton for easy reference in other scripts.
    public static UserInput instance;

    public Vector2 moveInput {  get; private set; }
    public bool attackInput { get; private set; }
    public bool pauseInput { get; private set; }

    private PlayerInput playerInput;

    private InputAction moveAction;
    private InputAction attackAction;
    private InputAction pauseAction;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        playerInput = GetComponent<PlayerInput>();

        SetupInputActions();
    }

    private void Update()
    {
        UpdateInputs();
    }

    private void SetupInputActions()
    {
        moveAction = playerInput.actions["Move"];
        attackAction = playerInput.actions["Attack"];
        pauseAction = playerInput.actions["Pause"];
    }

    private void UpdateInputs()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        attackInput = attackAction.WasPressedThisFrame();
        pauseInput = pauseAction.WasPressedThisFrame();
    }
}

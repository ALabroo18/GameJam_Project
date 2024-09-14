using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    // Create singleton for easy reference in other scripts.
    public static UserInput instance;

    public static PlayerInput playerInput;

    public Vector2 moveInput {  get; private set; }
    public bool attackInput { get; private set; }
    public bool pauseInput { get; private set; }

    public bool resumeInputUI { get; private set; }

    // Player action map input actions.
    private InputAction moveAction;
    private InputAction attackAction;
    private InputAction pauseAction;
    
    // UI action map input actions.
    private InputAction resumeAction;

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
        // Player action map
        moveAction = playerInput.actions["Move"];
        attackAction = playerInput.actions["Attack"];
        pauseAction = playerInput.actions["Pause"];

        // UI action map
        resumeAction = playerInput.actions["Resume"];
    }

    private void UpdateInputs()
    {
        // Player action map inputs. 
        moveInput = moveAction.ReadValue<Vector2>();
        attackInput = attackAction.WasPressedThisFrame();
        pauseInput = pauseAction.WasPressedThisFrame();

        // UI action map inputs.
        resumeInputUI = resumeAction.WasPressedThisFrame();
    }
}

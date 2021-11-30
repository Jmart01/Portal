using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private MovementComp _movementComp;
    private InputActions _inputActions;


    private void Awake()
    {
        _inputActions = new InputActions();
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Disable();
    }

    void Start()
    {
        _movementComp = GetComponent<MovementComp>();

        _inputActions.Gameplay.Movement.performed += MovementOnPerformed;
        _inputActions.Gameplay.Movement.canceled += MovementOnCanceled;
        _inputActions.Gameplay.CursorPosition.performed += CursorPostionOnPerformed;
        _inputActions.Gameplay.SpawnPortalA.performed += SpawnPortalA;
        _inputActions.Gameplay.SpawnPortalB.performed += SpawnPortalB;
    }

    private void SpawnPortalA(InputAction.CallbackContext obj)
    {
        //raycast the portal where the player is looking
    }
    private void SpawnPortalB(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }
    
    private void CursorPostionOnPerformed(InputAction.CallbackContext obj)
    {
        _movementComp.SetCursorPosition(obj.ReadValue<Vector2>());
    }

    private void MovementOnCanceled(InputAction.CallbackContext obj)
    {
        _movementComp.SetMovementInput(obj.ReadValue<Vector2>());
    }

    private void MovementOnPerformed(InputAction.CallbackContext obj)
    {
        _movementComp.SetMovementInput(obj.ReadValue<Vector2>());
    }
}

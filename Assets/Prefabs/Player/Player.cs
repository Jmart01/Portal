using System;
using System.Collections;
using System.Collections.Generic;
using DarkDemon;
using UnityEngine;
using UnityEngine.InputSystem;
using Object = System.Object;

public class Player : MonoBehaviour
{
    private MovementComp _movementComp;
    private InputActions _inputActions;
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject portalA;
    [SerializeField] GameObject portalB;
    private GameObject _activePortalA;
    private GameObject _activePortalB;
    Portal _portal;


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
        _portal = FindObjectOfType<Portal>();
        _inputActions.Gameplay.Movement.performed += MovementOnPerformed;
        _inputActions.Gameplay.Movement.canceled += MovementOnCanceled;
        _inputActions.Gameplay.CursorPosition.performed += CursorPostionOnPerformed;
        _inputActions.Gameplay.SpawnPortalA.performed += SpawnPortalA;
        _inputActions.Gameplay.SpawnPortalB.performed += SpawnPortalB;
        Cursor.visible = false;
    }

    private void SpawnPortalA(InputAction.CallbackContext obj)
    {
        //raycast the portal where the player is looking
        //GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
        FireTowards(portalA,"portalA");
    }
    private void SpawnPortalB(InputAction.CallbackContext obj)
    {
        FireTowards(portalB,"portalB");
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

    private void FireTowards(GameObject thingToSpawn, string colliderToPop)
    {
        Vector3 rayOrigin = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, mainCamera.transform.forward, out hit))
        {
            if(hit.collider.gameObject.CompareTag("portalableSurface"))
            {
                GameObject newPortal = Instantiate(thingToSpawn, hit.point,Quaternion.LookRotation(hit.normal));
                newPortal.transform.parent = FindObjectOfType<Portal>().gameObject.transform;
                switch (colliderToPop)
                {
                    case "portalA":
                        if (_activePortalA != null)
                        {
                            Destroy(_activePortalA);
                        }
                        /*_portal.ColliderA = newPortal.GetComponentInChildren<Collider>();
                        _portal.CameraA = newPortal.GetComponentInChildren<Camera>();
                        _portal.ScreenA = newPortal.GetComponentInChildren<Transform>();*/
                        _portal.InitialSetUp();
                        _activePortalA = newPortal;
                        break;
                    case "portalB":
                        if (_activePortalB != null)
                        {
                            Destroy(_activePortalB);
                            _portal.SetIsMaterialsCreated = false;
                        }
                        /*_portal.ColliderB = newPortal.GetComponentInChildren<Collider>();
                        _portal.CameraB = newPortal.GetComponentInChildren<Camera>();
                        _portal.ScreenB = newPortal.GetComponentInChildren<Transform>();*/
                        _portal.InitialSetUp();
                        _activePortalB = newPortal;
                        break;
                    }
            }
        }
    }
}

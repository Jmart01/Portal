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
    private InteractComponent _interactComp;
    
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject portalA;
    [SerializeField] GameObject portalB;
    [SerializeField] LayerMask InteractLayerMask;
    private GameObject _activePortalA;
    private GameObject _activePortalB;
    Portal _portal;
    
    [SerializeField] Transform PickUpSocketTrans;
    [SerializeField] float InteractRadius = 2.4f;

    public Transform GetPickUpSocketTransform()
    {
        return PickUpSocketTrans;
    }

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
        _interactComp = GetComponent<InteractComponent>();
        _inputActions.Gameplay.Movement.performed += MovementOnPerformed;
        _inputActions.Gameplay.Movement.canceled += MovementOnCanceled;
        _inputActions.Gameplay.CursorPosition.performed += CursorPostionOnPerformed;
        _inputActions.Gameplay.SpawnPortalA.performed += SpawnPortalA;
        _inputActions.Gameplay.SpawnPortalB.performed += SpawnPortalB;
        _inputActions.Gameplay.Interact.performed += Interact;
        Cursor.visible = false;
        Cursor.lockState =  CursorLockMode.Locked;
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
            Debug.Log(hit.collider.gameObject.name);
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

    void Interact(InputAction.CallbackContext ctx)
    {
        if (_interactComp != null)
        {
            Debug.Log("I'm interacting");
            Vector3 rayOrigin = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
            Ray castRay = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(castRay, out RaycastHit hit, float.MaxValue, InteractLayerMask,
                QueryTriggerInteraction.Collide))
            {
                Interactable otherAsInteractable = hit.rigidbody.gameObject.GetComponent<Interactable>();
                if (otherAsInteractable)
                {
                    float DistanceToInteractable = Vector3.Distance(hit.point, this.transform.position);
                    if (DistanceToInteractable < InteractRadius)
                    {
                        Debug.Log("Firing Interact");
                        otherAsInteractable.Interact(gameObject);
                        
                    }
                }
            }
        }
    }
}

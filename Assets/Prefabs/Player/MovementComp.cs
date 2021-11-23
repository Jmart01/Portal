using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class MovementComp : MonoBehaviour
{
    [Header("Walking")]
    [SerializeField] float WalkingSpeed = 5f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] float EdgeCheckTracingDistance = 0.8f;
    [SerializeField] float EdgeCheckTracingDepth = 1f;
    
    [Header("Ground Check")]
    [SerializeField] Transform GroundCheck;
    [SerializeField] float GroundCheckRadius = 0.1f;
    [SerializeField] LayerMask GroundLayerMask;
    [SerializeField] private Transform CameraPitch;
    bool isClimbing;
    Vector3 LadderDir;
    Vector2 MoveInput;
    private Vector2 CursorPosition;
    Vector3 Velocity;
    float Gravity = -9.8f;
    CharacterController characterController;

    Transform currentFloor;
    Vector3 PreviousWorldPos;
    Vector3 PreviousFloorLocalPos;
    Quaternion PreviousWorldRot;
    Quaternion PreviousFloorLocalRot;

    private float mouseX;
    private float mouseY;
    [SerializeField] float sensitivityX = 0.01f;
    [SerializeField] float sensitivityY = 0.01f;
    private float xRotation = 0;
    [SerializeField] float xClamp = 85f;

    private float pitch = 0.0f;
    public void SetMovementInput(Vector2 inputVal)
    {
        Debug.Log(inputVal);
        MoveInput = inputVal;
    }
    public void ClearVerticalVelocity()
    {
        Velocity.y = 0;
    }
    public void SetClimbingInfo(Vector3 ladderDir, bool climbing)
    {
        LadderDir = ladderDir;
        isClimbing = climbing;
    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void CheckFloor()
    {
        Collider[] cols = Physics.OverlapSphere(GroundCheck.position, GroundCheckRadius, GroundLayerMask);
        if (cols.Length != 0)
        {
            if (currentFloor != cols[0].transform)
            {
                currentFloor = cols[0].transform;
                SnapShotPostionAndRotation();
            }
        }
    }
    void SnapShotPostionAndRotation()
    {
        PreviousWorldPos = transform.position;
        PreviousWorldRot = transform.rotation;
        if (currentFloor != null)
        {
            PreviousFloorLocalPos = currentFloor.InverseTransformPoint(transform.position);
            PreviousFloorLocalRot = Quaternion.Inverse(currentFloor.rotation) * transform.rotation;
            //to add 2 rotation you do QuaternionA * QuaternionB
            //to subtract you do Quaternion.Inverse(QuaternionA) * QuaternionB
        }
    }

    bool IsOnGround()
    {
        return Physics.CheckSphere(GroundCheck.position, GroundCheckRadius, GroundLayerMask);
    }

    public IEnumerator MoveToTransform(Transform Destination, float transformTime)
    {
        Vector3 StartPos = transform.position;
        Vector3 EndPos = Destination.position;
        Quaternion StartRot = transform.rotation;
        Quaternion EndRot = Destination.rotation;

        float timmer = 0f;
        while (timmer < transformTime)
        {
            timmer += Time.deltaTime;
            Vector3 DeltaMove = Vector3.Lerp(StartPos, EndPos, timmer / transformTime) - transform.position;
            characterController.Move(DeltaMove);
            transform.rotation = Quaternion.Lerp(StartRot, EndRot, timmer / transformTime);
            yield return new WaitForEndOfFrame();
        }
    }
    void FollowFloor()
    {
        if (currentFloor)
        {
            Vector3 DeltaMove = currentFloor.TransformPoint(PreviousFloorLocalPos) - PreviousWorldPos;
            Velocity += DeltaMove / Time.deltaTime;

            Quaternion DestinationRot = currentFloor.rotation * PreviousFloorLocalRot;
            Quaternion DeltaRot = Quaternion.Inverse(PreviousWorldRot) * DestinationRot;
            transform.rotation = transform.rotation * DeltaRot;
        }
    }

    private void Update()
    {
        if (isClimbing)
        {
            CalculateClimbingVelocity();
        }
        else
        {
            CaculateWalkingVelocity();
        }

        CheckFloor();
        FollowFloor();
        characterController.Move(Velocity * Time.deltaTime);
        UpdateRotation();

        SnapShotPostionAndRotation();
    }

    void CalculateClimbingVelocity()
    {
        if (MoveInput.magnitude == 0)
        {
            Velocity = Vector3.zero;
            return;
        }

        Vector3 PlayerDesiredMoveDir = GetPlayerDesiredMoveDir();

        float Dot = Vector3.Dot(LadderDir, PlayerDesiredMoveDir);

        Velocity = Vector3.zero;
        if (Dot < 0)
        {
            Velocity = GetPlayerDesiredMoveDir() * WalkingSpeed;
            Velocity.y = WalkingSpeed;
        }
        else
        {
            if (IsOnGround())
            {
                Velocity = GetPlayerDesiredMoveDir() * WalkingSpeed;
            }
            Velocity.y = -WalkingSpeed;
        }
    }

    private void CaculateWalkingVelocity()
    {
        Velocity =(-MoveInput.y * transform.right + MoveInput.x * transform.forward).normalized * WalkingSpeed;
    }

    public Vector3 GetPlayerDesiredMoveDir()
    {
        return new Vector3(-MoveInput.y, 0f, MoveInput.x).normalized;
    }
    
   public void RecieveInput(Vector2 mouseInput)
   {
       mouseX = mouseInput.x * sensitivityX;
       mouseY = -mouseInput.y * sensitivityY;
       transform.Rotate(Vector3.up, mouseX * Time.deltaTime);

       pitch = Mathf.Clamp(pitch + mouseY * Time.deltaTime, -80f, 80f);
       CameraPitch.transform.localEulerAngles = new Vector3(0,0,pitch);

   }

    void UpdateRotation()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(CameraPitch.position, transform.forward*1000);
    }

    public void SetCursorPosition(Vector2 readValue)
    {
        CursorPosition = readValue;
        RecieveInput(CursorPosition);
    }
}

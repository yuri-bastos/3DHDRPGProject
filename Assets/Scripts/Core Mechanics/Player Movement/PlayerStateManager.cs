using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerStateManager : MonoBehaviour
{
    private void Awake()
    {
        Controller = GetComponent<CharacterController>();
        Input = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;
        PlayerSpeed = 10f;
        PlayerRotateSpeed = 180;

        _gravityVector = new Vector3(0f, -9.81f, 0f);
    }

    void Start()
    {
        CurrentState = IdlingState;
        CurrentState.EnterState(this);
    }

    void Update()
    {
        cameraTransform = Camera.main.transform;
        if (CurrentState != FallingState && !Controller.isGrounded)
        {
            SwitchState(FallingState);
        }

        CurrentState.UpdateState(this);
        ApplyGravity();
    }

    public void SwitchState(PlayerBaseState state)
    {
        CurrentState.ExitState(this);
        CurrentState = state;
        state.EnterState(this);
    }

    #region Movement
    public void ApplyGravity()
    {
        Controller.Move(_gravityVector * Time.deltaTime);
    }

    public void Move()
    {
        Controller.Move(PlayerSpeed * MoveVector * Time.deltaTime);
        RotateTowardsVector();
    }

    public void RotateTowardsVector()
    {
        /*var xzDirection = new Vector3(MoveVector.x, 0, MoveVector.z);
        if (xzDirection.magnitude == 0) return;

        var rotation = Quaternion.LookRotation(xzDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, PlayerRotateSpeed);*/

        Quaternion targetRotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, PlayerRotateSpeed);
    }
    #endregion
}

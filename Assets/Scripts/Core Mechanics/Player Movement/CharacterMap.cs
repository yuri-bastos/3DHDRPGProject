using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerStateManager
{
    private void OnMovement(InputValue value)
    {
        InputVector = value.Get<Vector2>();
        MoveVector = new Vector3(InputVector.x, 0f, InputVector.y);
        MoveVector = MoveVector.x * cameraTransform.right.normalized + MoveVector.z * cameraTransform.forward.normalized;
        MoveVector.y = 0f;
    }
}

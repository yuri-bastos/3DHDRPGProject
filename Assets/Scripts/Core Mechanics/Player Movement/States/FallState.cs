using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("Entering FALL");
    }

    public override void ExitState(PlayerStateManager player)
    {
        Debug.Log("Exiting FALL");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if(player.Controller.isGrounded)
        {
            player.SwitchState(player.IdlingState);
        }
    }
}

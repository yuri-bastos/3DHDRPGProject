﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        
    }
    
    public override void ExitState(PlayerStateManager player)
    {
        
    }

    public override void UpdateState(PlayerStateManager player)
    {
        if(player.MoveVector.magnitude != 0)
        {
            player.SwitchState(player.WalkingState);
        }
    }
}

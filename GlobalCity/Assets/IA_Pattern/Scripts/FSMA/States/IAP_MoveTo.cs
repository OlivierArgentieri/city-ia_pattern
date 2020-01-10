using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAP_MoveTo : IAP_State
{
    public override IAP_Brain Brain { get; set; }

    public override void Init(IAP_Brain _brain) => Brain = _brain;
    void SetMovement()
    {
        if (Brain && Brain.Movement && Brain.Behaviour && Brain.Behaviour.Target)
        {
            if (Brain.Behaviour.Stats.IsDead)
            {
                Brain.Movement.Stop();
                return;
            }
            Brain.Movement.MoveTo(Brain.Behaviour.Target.position);
        }
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        OnStateUpdateEvent += SetMovement;
        OnStateExitEvent += Brain.Movement.Stop;
    }
}

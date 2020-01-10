using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAP_MoveToBase : IAP_State
{
    public override IAP_Brain Brain { get; set; }

    public override void Init(IAP_Brain _brain) => Brain = _brain;
    void SetMovement()
    {
        if (Brain.IsValid)
            Brain.Movement.MoveTo(Brain.Behaviour.StartPos);
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        OnStateUpdateEvent += SetMovement;
    }
}

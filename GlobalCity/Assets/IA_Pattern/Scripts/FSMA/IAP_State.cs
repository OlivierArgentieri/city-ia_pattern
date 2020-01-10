using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class IAP_State : StateMachineBehaviour
{
    public abstract IAP_Brain Brain { get; set; }

    public event Action OnStateEnterEvent = null;
    public event Action OnStateUpdateEvent = null;
    public event Action OnStateExitEvent = null;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) => OnStateEnterEvent?.Invoke();
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) => OnStateUpdateEvent?.Invoke();
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        OnStateExitEvent?.Invoke();
        OnDestroy();
    }
    public abstract void Init(IAP_Brain _brain);

    protected void OnDestroy()
    {
        OnStateEnterEvent = null;
        OnStateUpdateEvent = null;
        OnStateExitEvent = null;
    }
}

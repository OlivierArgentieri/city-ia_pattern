using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAP_Brain : StateMachineBehaviour
{
    bool isInit = false;

    [SerializeField] string attackParam = "canAttack";
    [SerializeField] string moveParam = "canMove";
    [SerializeField] string goBackParam = "canGoBack";
    [SerializeField] string healParam = "canHeal";
    [SerializeField] string deadParam = "isDead";

    public IAP_IABehaviour Behaviour { get; private set; }
    public IAP_Movement Movement { get; private set; }
    public IAP_Animator Animation { get; private set; }

    ICharacterBehaviour targetData = null;
    public bool IsValid => Behaviour && Movement && Animation && targetData!=null;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        InitBrain(animator);
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!IsValid) return;
        animator.SetBool(deadParam, Behaviour.Stats.IsDead);
        Animation.SetBool(deadParam, Behaviour.Stats.IsDead);
        if(EndBrainBehaviour(animator))return;
        GlobalBrainBehaviour(animator);
    }
   void GlobalBrainBehaviour(Animator animator)
    {
        if (!Behaviour.IsOutOfStartPos && !Behaviour.IsGoingBack && Behaviour.IsAtAggroRange)
        {
            animator.SetBool(attackParam, Behaviour.CanAttack);
            animator.SetBool(moveParam, !Behaviour.CanAttack);
            Animation.SetBool(moveParam, !Behaviour.CanAttack);
            Animation.SetBool(attackParam, Behaviour.CanAttack);
        }
        else
        {
            Behaviour.IsGoingBack = !Behaviour.IsAtBase;
            Animation.SetBool(moveParam, Behaviour.IsGoingBack);
            animator.SetBool(moveParam, false);
            animator.SetBool(goBackParam, Behaviour.IsGoingBack);
        }
        Animation.SetBool(healParam, Behaviour.Stats.NeedHeal);
        animator.SetBool(healParam, Behaviour.Stats.NeedHeal);
    }
    bool EndBrainBehaviour(Animator animator)
    {
        if (Behaviour.Stats.IsDead || targetData.Stats.IsDead)
        {
            animator.SetBool(attackParam, false);
            animator.SetBool(moveParam, false);
            animator.SetBool(healParam, false);
            Animation.SetBool(attackParam, false);
            Animation.SetBool(moveParam, false);
            Animation.SetBool(healParam, false);
            return true;
        }
        return false;
    }
    void InitBrain(Animator animator)
    {
        if (isInit) return;
        if (!Movement) Movement = animator.GetComponent<IAP_Movement>();
        if (!Behaviour)
        {
            Behaviour = animator.GetComponent<IAP_IABehaviour>();
            if(Behaviour)
                targetData = Behaviour.Target.GetComponent<ICharacterBehaviour>();
        }
        if (!Animation) Animation = animator.GetComponent<IAP_Animator>();
        if (!IsValid) return;
        IAP_State[] _states = animator.GetBehaviours<IAP_State>();
        for (int i = 0; i < _states.Length; i++)
            _states[i].Init(this);
        isInit = true;
    }
}

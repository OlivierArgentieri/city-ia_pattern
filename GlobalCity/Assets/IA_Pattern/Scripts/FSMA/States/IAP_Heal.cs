using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAP_Heal : IAP_State
{
    public override IAP_Brain Brain { get ; set ; }

    public override void Init(IAP_Brain _brain)
    {
        Brain = _brain;
        StopHeal();
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        OnStateUpdateEvent += UseHeal;
        OnStateExitEvent += StopHeal;
    }

    void UseHeal()
    {
        if (!Brain.Behaviour|| !Brain.Behaviour.Stats.ParticleHeal) return;
        Brain.Behaviour.Stats.FillLife();
        if(!Brain.Behaviour.Stats.ParticleHeal.isPlaying)
            Brain.Behaviour.Stats.ParticleHeal.Play();
    }
    void StopHeal()
    {
        if (!Brain.Behaviour || !Brain.Behaviour.Stats.ParticleHeal) return;
        Brain.Behaviour.Stats.ParticleHeal.Stop();
    }
}

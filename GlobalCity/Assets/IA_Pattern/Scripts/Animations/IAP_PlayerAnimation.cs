using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAP_PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator anim = null;
    [SerializeField] string runParam = "run";
    [SerializeField] string atkParm = "atk";
    [SerializeField] string dieParam = "die";

    public bool IsValid => anim;
    public void SetMovementData(IAP_Player _player)
    {
        if (!IsValid) return;
        anim.SetBool(runParam, _player.Movement.Agent.velocity.magnitude > 0);
    }
    public void AttackAnimation()
    {
        if (!IsValid) return;
        anim.SetTrigger(atkParm);
    }
    public void SetDie()
    {
        if (!IsValid) return;
        anim.SetBool(dieParam, true);
    }
}

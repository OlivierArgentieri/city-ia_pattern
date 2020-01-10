using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAP_Attack : IAP_State
{
    public override IAP_Brain Brain { get; set; }
    float attackTimer = 0;
    [SerializeField, Range(1, 10)] float attackRate = 1;
    public override void Init(IAP_Brain _brain)
    {
        Brain = _brain;
        OnStateUpdateEvent += RotateToTarget;
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        OnStateUpdateEvent += RotateToTarget;
        OnStateUpdateEvent += AttackTarget;
    }
    void RotateToTarget()
    {
        if (!Brain.Behaviour.Target) return;
        Vector3 _look = Brain.Behaviour.Target.transform.position - Brain.Behaviour.transform.position;
        Brain.Behaviour.transform.rotation = Quaternion.RotateTowards(Brain.Behaviour.transform.rotation, Quaternion.LookRotation(new Vector3(_look.x, 0, _look.z)), Time.deltaTime * 500);
    }
    void AttackTarget()
    {
        if (!Brain.Behaviour.Target) return;
        ICharacterBehaviour _behaviour = Brain.Behaviour.Target.gameObject.GetComponent<ICharacterBehaviour>();
        if (_behaviour == null || _behaviour.Stats.IsDead) return;
        attackTimer += Time.deltaTime;
        if(attackTimer > attackRate)
        {
            Brain.Behaviour.Stats.ShowDamageFx(Brain.Behaviour.Target.position);
            _behaviour.Stats.SetDamage(Brain.Behaviour.Stats.Damage);
            attackTimer = 0;
        }
    }
}

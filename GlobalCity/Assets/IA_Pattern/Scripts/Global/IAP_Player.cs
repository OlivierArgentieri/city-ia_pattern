using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAP_Player : MonoBehaviour, ICharacterBehaviour
{
    public IAP_Movement Movement { get; private set; }
    IAP_PlayerAnimation animator = null;

    [SerializeField, Range(0, 10)] float attackRange = 2;
    public float AttackRange => attackRange;
    [SerializeField] GameObject currentTarget = null;
    public bool CanAttack => IsAtRange(currentTarget);
    [SerializeField] IAP_Stats stats = new IAP_Stats();
    public IAP_Stats Stats => stats;
    public bool IsValid => Movement && animator;
    private void Awake()
    {
        IAP_GamePointer.OnTargetSelect += AttackTarget;
        IAP_GamePointer.OnMoveInput += SetDestination;
    }
    void Start() => Init();
    void Init()
    {
        if (!Movement)
            Movement = GetComponent<IAP_Movement>();
        if (!animator)
            animator = GetComponent<IAP_PlayerAnimation>();
        stats.Init();
        stats.OnDie += OnDieBehaviour;
    }
    private void Update()
    {
        if (!IsValid||stats.IsDead) return;
        RotateToTarget();
        animator.SetMovementData(this);
    }
    void SetDestination(Vector3 _target,bool _action)
    {
        if (!IsValid||!_action) return;
        Movement.MoveTo(_target);
    }
    void AttackTarget(GameObject _target, bool _action)
    {
        currentTarget = _target;
        if (!_target||!_action || !IsAtRange(currentTarget)) return;
        IAP_IABehaviour _targetBehaviour = _target.GetComponent<IAP_IABehaviour>();
        if (_targetBehaviour)
        {
            _targetBehaviour.Stats.SetDamage(stats.Damage);
            animator.AttackAnimation();
        }
    }
    bool IsAtRange(GameObject _target)
    {
        if (!_target) return false;
        return Vector3.Distance(_target.transform.position, transform.position) < attackRange;
    }
    void RotateToTarget()
    {
        if (!currentTarget) return;
        Vector3 _look = currentTarget.transform.position - transform.position;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(new Vector3(_look.x, 0, _look.z)), Time.deltaTime * 500);
    }
    void OnDieBehaviour()
    {
        animator.SetDie();
        IAP_GamePointer.OnTargetSelect -= AttackTarget;
        IAP_GamePointer.OnMoveInput -= SetDestination;
    }
}

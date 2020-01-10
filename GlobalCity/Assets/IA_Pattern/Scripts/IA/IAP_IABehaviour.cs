using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAP_IABehaviour : MonoBehaviour ,ICharacterBehaviour
{
    [SerializeField] Transform target = null;
    public Transform Target => target;
    [SerializeField, Range(0, 10)] float aggroRange = 3;
    public float AggroRange => aggroRange;
    public bool IsAtAggroRange => target && (Vector3.Distance(transform.position, target.position) < aggroRange);

    [SerializeField, Range(0, 10)] float attackRange = 2;
    public float AttackRange => attackRange;
    public bool IsAtAttackRange => target && (Vector3.Distance(transform.position, target.position) < attackRange);
    public bool CanAttack => IsAtAttackRange;
    public Vector3 StartPos { get; private set; }
    [SerializeField, Range(0, 10)] float startPosRange = 5;
    public float StartPosRange => startPosRange;
    public bool IsOutOfStartPos => (Vector3.Distance(transform.position, StartPos) > startPosRange);
    public bool IsAtBase => (Vector3.Distance(transform.position, StartPos) < 2.2f);
    public bool IsGoingBack { get; set; } = false;

    [SerializeField] IAP_Stats stats = new IAP_Stats();
    public IAP_Stats Stats => stats;
    void Awake() => StartPos = transform.position;
    private void Start()
    {
        Stats.ParticleHeal = GetComponent<ParticleSystem>();
        Stats.Init();
    }
}

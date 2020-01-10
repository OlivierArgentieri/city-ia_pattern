using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class IAP_Movement : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent = null;
    public NavMeshAgent Agent => agent;
    void Start() => Init();
    void Init()
    {
        if (!agent)
            agent = GetComponent<NavMeshAgent>();
    }
    public void MoveTo(Vector3 _target)
    {
        if (!agent) return;
        if(agent.isStopped)
            agent.isStopped = false;
        agent.SetDestination(_target);
    }
    public void Stop()
    {
        if (!agent) return;
        agent.isStopped = true;
    }
}

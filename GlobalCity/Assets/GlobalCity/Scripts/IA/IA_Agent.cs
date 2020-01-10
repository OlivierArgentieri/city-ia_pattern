using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class IA_Agent : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent agent = null;
    float initSpeed = 0;
    Material agentMaterial = null;
    [SerializeField]
    List<IA_Schedule> agentSchedule = new List<IA_Schedule>();
    public List<IA_Schedule> AgentSchedule => agentSchedule;
    public bool IsValid => agent;
    void Awake()
    {
        IA_DayTime.OnUpdateTime += CheckSchedule;
    }
    private void Start()
    {
        if (agent)
        {
            initSpeed = agent.speed;
            agentMaterial = agent.GetComponent<Renderer>().material;
        }
    }
    public void AddSchedule()
    {
        agentSchedule.Add(new IA_Schedule());
    }
    public void Init()
    {
        if (!agent)
            agent = GetComponent<NavMeshAgent>();
    }
    void CheckSchedule(int _time)
    {
        for (int i = 0; agent &&  i < agentSchedule.Count; i++)
        {
            if(agentSchedule[i].StartTime == _time)
            {
                agent.SetDestination(agentSchedule[i].SchedulePlace.Position);
                agent.speed = initSpeed * IA_DayTime.Instance.DaySpeed;
                agentMaterial.color = agentSchedule[i].SchedulePlace.BuildingColor;
                break;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if(agent)
        {
            for (int i = 0; i < agent.path.corners.Length; i++)
            {
                if(i< agent.path.corners.Length -1)
                Gizmos.DrawLine(agent.path.corners[i], agent.path.corners[i+1]);
                Gizmos.DrawSphere(agent.path.corners[i], 1f);
            }
        }
    }
}

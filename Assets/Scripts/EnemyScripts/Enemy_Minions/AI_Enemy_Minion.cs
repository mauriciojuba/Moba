using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LivingEntity))]
public class AI_Enemy_Minion : MonoBehaviour {

    NavMeshAgent navAgent;
    GameObject Target;
    AI_Enemy_Minion_Range Range;
    public GameObject Attack;
    private delegate void AIDelegate();
    private AIDelegate state;
    public int way;

    public Transform[] waypointsA, waypointsB, waypointsC;

    void Start()
    {
        Range = GetComponentInChildren<AI_Enemy_Minion_Range>();
        navAgent = GetComponent<NavMeshAgent>();
        state = new AIDelegate(Progress);
        Attack.SetActive(false);
    }

    void Update()
    {
        state();
    }

    int currentWaypoint = 0;
    public float distanceToChangeWaypoint;
    void Progress()
    {
        if (Range.playerNear)
        {
            Target = Range.player;
            navAgent.ResetPath();
            state = new AIDelegate(Chasing);
        }
        else if (way == 0)
        {
            Attack.SetActive(false);
            if (navAgent.remainingDistance <= distanceToChangeWaypoint)
            {
                if (currentWaypoint < waypointsA.Length - 1)
                {
                    navAgent.ResetPath();
                    currentWaypoint++;
                }
                else
                {
                    navAgent.ResetPath();
                    currentWaypoint = 0;
                }
                navAgent.SetDestination(waypointsA[currentWaypoint].position);
            }
        }
        else if (way == 1)
        {
            Attack.SetActive(false);
            if (navAgent.remainingDistance <= distanceToChangeWaypoint)
            {
                if (currentWaypoint < waypointsB.Length - 1)
                {
                    navAgent.ResetPath();
                    currentWaypoint++;
                }
                else
                {
                    navAgent.ResetPath();
                    currentWaypoint = 0;
                }
                navAgent.SetDestination(waypointsB[currentWaypoint].position);
            }
        }
        else if (way == 2)
        {
            Attack.SetActive(false);
            if (navAgent.remainingDistance <= distanceToChangeWaypoint)
            {
                if (currentWaypoint < waypointsC.Length - 1)
                {
                    navAgent.ResetPath();
                    currentWaypoint++;
                }
                else
                {
                    navAgent.ResetPath();
                    currentWaypoint = 0;
                }
                navAgent.SetDestination(waypointsC[currentWaypoint].position);
            }
        }
    }
    public float attackDelay;
    float countToAttack;
    public float distanceToStopCombat = 3;
    void Attacking()
    {
        navAgent.Stop();
        //se estiver com problemas de colisão lembre de ver a stoppingDistance do navmesh
        if (countToAttack >= attackDelay)
        {
            Attack.SetActive(true);
            countToAttack = 0;
            if (Vector3.Distance(transform.position, Target.transform.position) >= distanceToStopCombat || Target == null)
            {
                state = new AIDelegate(Progress);
            }
        }
        else
        {
            countToAttack += Time.deltaTime;
            Attack.SetActive(false);
        }
    }
    float distanceToTarget;
    public float distanceToStartCombat;
    void Chasing()
    {
        if (navAgent.remainingDistance <= distanceToStartCombat)
        {
            navAgent.ResetPath();
            state = new AIDelegate(Attacking);
        }
        else
        {
            navAgent.SetDestination(Target.transform.position);
        }
    }

}

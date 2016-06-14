using UnityEngine;
using System.Collections;

public class AI_Enemy_Minion : MonoBehaviour {

    NavMeshAgent navAgent;
    GameObject Target, Player;
    Enemy_Hero_01_Eye Eye;
    public float Life;
    public GameObject attack;




    private delegate void AIDelegate();
    private AIDelegate state;

    void Start()
    {
        //trocar para nome do player na cena original
        Player = GameObject.Find("Player");
        Eye = GetComponentInChildren<Enemy_Hero_01_Eye>();
        navAgent = GetComponent<NavMeshAgent>();
        state = new AIDelegate(Progress);
        attack.SetActive(false);
    }
    
    void Update()
    {
        state();
    }

    public Transform[] Waypoints;
    int currentWaypoint = 0;
    public float distanceToChangeWaypoint;
    void Progress()
    {
        if (Eye.playerNear)
        {
            Target = Player;
            navAgent.ResetPath();
            state = new AIDelegate(Chasing);
        }
        //esta patrulhando e a TORRE entra no raio de alcance
        else if (Eye.towerNear)
        {
            Target = Eye.closestTower;
            navAgent.ResetPath();
            state = new AIDelegate(Chasing);
        }
        //esta patrulhando e um MINION entra no raio de alcance
        else if (Eye.minionNear)
        {
            Target = Eye.closestMinion;
            navAgent.ResetPath();
            state = new AIDelegate(Chasing);
        }

        //patrulhando
        attack.SetActive(false);
        if (navAgent.remainingDistance <= distanceToChangeWaypoint)
        {
            if (currentWaypoint < Waypoints.Length - 1)
            {
                navAgent.ResetPath();
                currentWaypoint++;
            }
            else
            {
                navAgent.ResetPath();
                currentWaypoint = 0;
            }
            navAgent.SetDestination(Waypoints[currentWaypoint].position);
        }
    }

    float distanceToTarget;
    public float distanceToStartCombat;
    void Chasing()
    {
        //enquanto não entra no alcance, continua tentando chegar perto
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
    public float attackDelay;
    float countToAttack;
    public float distanceToStopCombat = 3;
    void Attacking()
    {
        navAgent.Stop();
        //se estiver com problemas de colisão lembre de ver a stoppingDistance do navmesh
        if (countToAttack >= attackDelay)
        {
            attack.SetActive(true);
            if (Vector3.Distance(transform.position, Target.transform.position) >= distanceToStopCombat || Target == null)
            {
                state = new AIDelegate(Progress);
            }
            else
            {
                attack.SetActive(false);
                countToAttack = 0;
            }
        }
        else
        {
            countToAttack += Time.deltaTime;
        }
    }
    void GetHit()
    {

    }
    void Die()
    {

    }

}

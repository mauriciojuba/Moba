using UnityEngine;
using System.Collections;

public class AI_Enemy_Hero_01 : MonoBehaviour {

    NavMeshAgent navAgent;
    GameObject Target, Player;
    Enemy_Hero_01_Eye Eye;
    LivingEntity life;




    private delegate void AIDelegate();
    private AIDelegate state;

    void Start()
    {
        //trocar para nome do player na cena original
        Player = GameObject.Find("Player");
        Eye = GetComponentInChildren<Enemy_Hero_01_Eye>();
        navAgent = GetComponent<NavMeshAgent>();
        state = new AIDelegate(Patroling);
        attack.SetActive(false);
        life = GetComponent<LivingEntity>();
    }

    void Update()
    {
        state();
    }

    #region Patrol
    public Transform[] Waypoints;
    int currentWaypoint = 0;
    public float distanceToChangeWaypoint;

    void Patroling()
    {
        //esta patrulhando e o PLAYER entra no raio de alcance
        if (Eye.playerNear)
        {
            Target = Player;
			if (life.life >= 30)
            {
                navAgent.ResetPath();
                state = new AIDelegate(Chasing);
            }
            else
            {
                navAgent.ResetPath();
                state = new AIDelegate(RunningAway);
            }
        }
        //esta patrulhando e a TORRE entra no raio de alcance
        else if (Eye.towerNear)
        {
            if (life.life <= 30)
            {
                navAgent.ResetPath();
                state = new AIDelegate(RunningAway);
            }
        }
        //esta patrulhando e um MINION entra no raio de alcance
        else if (Eye.minionNear)
        {
            Target = Eye.closestMinion;
			if (life.life >= 10)
            {
                navAgent.ResetPath();
                state = new AIDelegate(Chasing);
            }
            else
            {
                navAgent.ResetPath();
                state = new AIDelegate(RunningAway);
            }
        }

        //patrulhando
        attack.SetActive(false);
        if (navAgent.remainingDistance <= distanceToChangeWaypoint)
        {
            navAgent.Resume();
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
    #endregion
    #region Attack
    public GameObject attack;
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
            countToAttack = 0;
            if (Vector3.Distance(transform.position, Target.transform.position) >= distanceToStopCombat || Target == null)
            {
                state = new AIDelegate(Patroling);
            }
        }
        else
        {
            countToAttack += Time.deltaTime;
            attack.SetActive(false);
        }
    }
    #endregion
    #region Chase
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
    #endregion
    #region TakeHit
    void TakingHit()
    {

    }
    #endregion
    #region Recovery
    void Recovering()
    {
		if (life.life >= 100)
        {
            state = new AIDelegate(Patroling);
        }
    }
    #endregion
    #region RunAway
    public Transform recoveryPoint;
    float distanceToRecovery = 0.5f;
    void RunningAway()
    {
        navAgent.ResetPath();
        navAgent.SetDestination(recoveryPoint.position);
        if (navAgent.remainingDistance <= distanceToRecovery)
        {
            state = new AIDelegate(Recovering);
        }
        else if (!Eye.towerNear)
        {
            state = new AIDelegate(Patroling);
        }
    }
    #endregion
    #region Die
    void Dying()
    {

    }
    #endregion
}

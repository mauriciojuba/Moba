using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	private NavMeshAgent agent;
	private Vector3 targetDestination;
	private Animator animator;
    public LayerMask floor,enemy;
    float countAttack;
    bool canAttack, inBattle;
    public GameObject Attack;

	// Use this for initialization
	void Start () {
		agent = this.GetComponent<NavMeshAgent>();
		animator = this.GetComponentInChildren<Animator>();
		targetDestination = transform.position;
        Attack.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,200,floor))
            {
                animator.SetBool("isMoving", true);
                agent.Resume();
                targetDestination = hit.point;
                agent.SetDestination(targetDestination);
                this.transform.LookAt(new Vector3(hit.transform.position.x, this.transform.position.y, hit.transform.position.z));
            }
        }

        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit2;
            if (Physics.Raycast(ray, out hit2, 200,enemy))
            {
                Debug.Log(hit2.collider.gameObject.name);
                if(hit2.collider.gameObject.layer == 9 && canAttack)
                {
                    if (inBattle)
                    {
                        Attack.SetActive(true);
                        animator.SetBool("isMoving", false);
                        this.transform.LookAt(new Vector3(hit2.transform.position.x, this.transform.position.y, hit2.transform.position.z));
                        animator.SetBool("Attack", true);
                        countAttack = 0;
                    }
                    else
                    {
                        agent.Resume();
                        targetDestination = hit2.point;
                        agent.SetDestination(targetDestination);
                        this.transform.LookAt(new Vector3(hit2.transform.position.x, this.transform.position.y, hit2.transform.position.z));
                    }
                }
            }
        }
        if (Vector3.Distance(transform.position, targetDestination) < 1f) {
            animator.SetBool("isMoving", false);
        }

        //ataque
        countAttack += Time.deltaTime;
        if (countAttack >= 2)
        {
            canAttack = true;
            animator.SetBool("Attack", false);
            Attack.SetActive(false);
        }
        else
        {
            canAttack = false;
        }
    }
    void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.layer == 9)
        {
            inBattle = true;
        }
    }
    void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.layer == 9)
        {
            inBattle = false;
        }
    }
}
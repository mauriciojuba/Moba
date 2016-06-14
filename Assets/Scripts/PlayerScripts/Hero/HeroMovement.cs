using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour {

	private NavMeshAgent agent;
	private Vector3 targetDestination;
	private Animator animator;
    public LayerMask floor;

	// Use this for initialization
	void Start () {
		agent = this.GetComponent<NavMeshAgent>();
		animator = this.GetComponentInChildren<Animator>();
		targetDestination = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit,floor))
            {
                agent.Resume();
                targetDestination = hit.point;
                agent.SetDestination(targetDestination);
                this.transform.LookAt(new Vector3(hit.transform.position.x, this.transform.position.y, hit.transform.position.z));
            }
        }
        if (Vector3.Distance(transform.position, targetDestination) > 1f)
        {
            animator.SetBool("isMoving", true);
        }
        else {
            animator.SetBool("isMoving", false);
        }
    }

	public void Follow(GameObject target) {
		agent.Resume();
		agent.SetDestination(target.transform.position);
		animator.SetBool("isMoving", true);               
	}
	public void Stop() {
		agent.Stop();
		animator.SetBool("isMoving", false);

	}
}
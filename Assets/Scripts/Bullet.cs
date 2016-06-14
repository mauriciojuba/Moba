using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 50.0f;
	public float damage = 1.0f;
	public float timeUntilDeath = 2.0f;
	Rigidbody rb;
    public string destroiATag;

	void Start(){
		rb = gameObject.GetComponent<Rigidbody>();
		rb.AddForce(transform.forward*speed,ForceMode.VelocityChange);
        Destroy(gameObject, timeUntilDeath);
	}
    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag(destroiATag)){
            hit.gameObject.GetComponent<LivingEntity>().Hit(damage);
            Destroy(gameObject);
        }
    }
    
}

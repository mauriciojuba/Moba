using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 100.0f;
	public float damage = 1.0f;
	public float timeUntilDeath = 1.0f;
	public LayerMask layers;
	Rigidbody rb;

	void Start(){
		rb = gameObject.GetComponent<Rigidbody>();
		rb.AddForce(transform.forward*speed,ForceMode.VelocityChange);
	}

	public void OnTriggerEnter(Collider c){
		if(layers == (layers | (1 << c.gameObject.layer))){
			IDamageable damageable = c.GetComponent<IDamageable>();
			if(damageable!=null){
				damageable.dealDamage(damage);
				GameObject.Destroy(gameObject);
			}
		}

	}

	IEnumerator countdown(){
		while(timeUntilDeath>0){
			timeUntilDeath-=Time.deltaTime;
			yield return null;
		}
		GameObject.Destroy(gameObject);
	}

}

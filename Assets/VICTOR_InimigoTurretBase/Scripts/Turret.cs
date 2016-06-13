using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class Turret : MonoBehaviour {

	public float range = 900.0f;
	public float angularVelocity = 45.0f;
	public Rigidbody bullet;
	public LayerMask layers;
	public string targetTag;
	Transform target;
	public Transform rootBone, muzzle;
	public float cooldown;
	float currentCd;

	public void OnTriggerEnter(Collider c){
		if(layers == (layers | (1 << c.gameObject.layer))){
			target = c.transform;
		}
	}

	public void OnTriggerExit(Collider c){
		if(layers == (layers | (1 << c.gameObject.layer))){
			target = null;
		}
	}

	void Update () {
		if (target!=null){
			aimAt();
		}
	}
		
	void aimAt(){
		Quaternion targetRot = Quaternion.LookRotation (target.position - rootBone.position);
		rootBone.transform.rotation = Quaternion.RotateTowards (rootBone.rotation, targetRot, angularVelocity * Time.deltaTime);
		if(currentCd==0){
			shoot();
		}
	}

	void shoot(){
		GameObject bul = Instantiate(bullet, muzzle.position, muzzle.rotation) as GameObject;
		currentCd = cooldown;
		StartCoroutine(coolDown());
	}

	void OnDrawGizmosSelected(){
		Gizmos.DrawWireSphere(transform.position,range);
	}

	IEnumerator coolDown(){
		while(currentCd>0){
			currentCd-=Time.deltaTime;
			yield return null;
		}
		if(currentCd<0){
			currentCd = 0;
		}
	}
		
}

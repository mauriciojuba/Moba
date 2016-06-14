using UnityEngine;
using System.Collections;

public class Enemy_RecoveryPoint : MonoBehaviour {

	public LayerMask layers;
	public float heal;
	GameObject target;
	IDamageable targetEntity;

	public void OnTriggerEnter(Collider c){
		if(layers == (layers | (1 << c.gameObject.layer))){
			target = c.gameObject;
			targetEntity = target.GetComponent<IDamageable>();
			StartCoroutine(healTarget());
		}
	}

	public void OnTriggerExit(Collider c){
		if(layers == (layers | (1 << c.gameObject.layer))){
			target = null;
			targetEntity = null;
			StopAllCoroutines();
		}
	}

	IEnumerator healTarget(){
		float targetHealth = targetEntity.getCurrHealth();
		float targetMaxHealth = targetEntity.getMaxHealth();
		while(targetHealth<targetMaxHealth){
			targetEntity.healDamage(heal);
			targetHealth = targetEntity.getCurrHealth();
			yield return new WaitForEndOfFrame();
		}
		yield return null;
	}
}

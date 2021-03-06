﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class Turret : MonoBehaviour {

	public float range = 900.0f;
	public float angularVelocity = 45.0f;
	public Rigidbody bullet;
	public LayerMask layers;
	Transform target;
	public Transform rootBone, muzzle;
	public float cooldown;
	float currentCd;

	public void OnTriggerEnter(Collider c){
        Debug.Log("OK");
		if(layers == (layers | (1 << c.gameObject.layer))){ //operacao bitwise pra descobrir se o collider c é da mesma layer da layermask
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
		
	void aimAt(){ // mira no alvo

        rootBone.transform.LookAt(target);
		if(currentCd==0){
			shoot();
		}
	}

	void shoot(){ // dispara se cooldown <= 0;
		GameObject bul = Instantiate(bullet, muzzle.position, muzzle.rotation) as GameObject;
		currentCd = cooldown;
		StartCoroutine(coolDown());
	}

	//realiza o cooldown da turret
	IEnumerator coolDown(){
		while(currentCd>0){
			currentCd-=Time.deltaTime; //abaixo o cooldown atual
			yield return null; //força a coroutine a reiniciar do começo, mas mantêm os valores alterados (funciona como um nextStep)
		} 
		if(currentCd<0){ //se o cooldown atual for menor que zero, zerá-lo
			currentCd = 0;
		}
	}
		
}

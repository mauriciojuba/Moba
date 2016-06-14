using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inhibitor : MonoBehaviour {

	public LayerMask layers;
	public float buff = 10.0f;
	GameObject[] gameObjs;
	List<GameObject> targets = new List<GameObject>();

	void Start(){
		//this.GetComponent<LivingEntity>().onDeath += inhibitorBuff;
	}

	void inhibitorBuff(){
		gameObjs = FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[]; 
		foreach(GameObject go in gameObjs){
			if(layers == (layers | (1 << go.layer))){
				targets.Add(go);
			}
		}
		Buffs.maxHealthBuff(targets, buff);
		Buffs.damageBuff(targets, buff);
	}
}

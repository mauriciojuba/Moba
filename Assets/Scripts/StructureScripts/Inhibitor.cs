using UnityEngine;
using System.Collections;

public class Inhibitor : MonoBehaviour {

	void Start(){
		this.GetComponent<LivingEntity>().onDeath += inhibitorBuff;
	}

	void inhibitorBuff(){
		Buffs.buffTroops();
	}
}

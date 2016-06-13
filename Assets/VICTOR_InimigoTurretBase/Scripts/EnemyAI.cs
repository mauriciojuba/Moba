using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public enum State { Idle, Moving, Melee, Shooting, Stopped};
	State currentState = State.Idle;
	public Attack[] attacks;

	float cooldown;
	LivingEntity thisEntity;

	public Transform muzzle;

	void Awake(){
		thisEntity = this.GetComponent<LivingEntity>();

	}

	[System.Serializable]
	public class Attack{
		public enum attackType {meleeAttack,rangedAttack};
		public attackType thisAttack = attackType.meleeAttack;
		public float maxRange;
		public float coolDown;
		public float damage;
	}




}

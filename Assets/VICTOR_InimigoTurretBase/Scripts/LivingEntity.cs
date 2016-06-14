using UnityEngine;
using System.Collections;

public class LivingEntity : MonoBehaviour, IDamageable {

	float currentHealth;
	public float maxHealth = 10.0f;
	public event System.Action onDeath;

	void Awake(){
		currentHealth = maxHealth;
	}

	public void dealDamage (float dmg){
		currentHealth -= dmg;
		if(currentHealth<=0){
			if(onDeath!=null){
				this.onDeath();
			}
			GameObject.Destroy(gameObject);
		}
	}

	public void healDamage (float dmg){
		currentHealth += dmg;
	}

	public float getCurrHealth(){
		return currentHealth;
	}

	public float getMaxHealth(){
		return maxHealth;
	}

}

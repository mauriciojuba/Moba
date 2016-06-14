using UnityEngine;
using System.Collections;

public interface IDamageable{

	void dealDamage (float dmg);

	void healDamage (float dmg);

	float getCurrHealth();

	float getMaxHealth();

}

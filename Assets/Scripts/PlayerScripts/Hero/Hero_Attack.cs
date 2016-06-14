using UnityEngine;
using System.Collections;

public class Hero_Attack : MonoBehaviour {
    public float damange = 10f;

    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Enemy") || hit.CompareTag("EnemyMinion") || hit.CompareTag("EnemyTower"))
        {
            hit.gameObject.GetComponent<LivingEntity>().Hit(damange);
        }
    }
}

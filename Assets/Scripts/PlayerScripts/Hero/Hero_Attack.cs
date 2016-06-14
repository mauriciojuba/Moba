using UnityEngine;
using System.Collections;

public class Hero_Attack : MonoBehaviour {

    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Enemy") || hit.CompareTag("EnemyMinion") || hit.CompareTag("EnemyTower"))
        {
            hit.gameObject.GetComponent<LivingEntity>().Hit(10f);
        }
    }
}

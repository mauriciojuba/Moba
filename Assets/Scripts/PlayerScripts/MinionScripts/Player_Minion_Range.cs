using UnityEngine;
using System.Collections;

public class Player_Minion_Range : MonoBehaviour {

    public bool enemyNear;
    public GameObject enemy;

	void OnTriggerEnter(Collider hit)
    {
        if(hit.CompareTag("Enemy")|| hit.CompareTag("EnemyMinion") || hit.CompareTag("EnemyTower"))
        {
            enemyNear = true;
            enemy = hit.gameObject;
        }
    }
    void OnTriggerExit(Collider hit)
    {
        if (hit.CompareTag("Enemy") || hit.CompareTag("EnemyMinion") || hit.CompareTag("EnemyTower"))
        {
            enemyNear = false;
        }
    }
}

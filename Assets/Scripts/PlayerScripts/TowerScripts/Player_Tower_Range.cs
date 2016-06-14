using UnityEngine;
using System.Collections;

public class Player_Tower_Range : MonoBehaviour {

    public bool enemyNear;
    public GameObject closestEnemy;

    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Enemy"))
        {
            enemyNear = true;
            closestEnemy = hit.gameObject;
        }
    }
    void OnTriggerExit(Collider hit)
    {
        if (hit.CompareTag("Enemy"))
        {
            enemyNear = false;
        }
    }
}
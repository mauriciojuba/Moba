using UnityEngine;
using System.Collections;

public class Enemy_Hero_01_Eye : MonoBehaviour {

    public bool playerNear, minionNear, towerNear;
    public GameObject closestMinion;

    //trocar para as tags usadas na cena original
	void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            playerNear = true;
        }
        if (hit.CompareTag("PlayerMinion") && !playerNear && !towerNear)
        {
            minionNear = true;
            closestMinion = hit.gameObject;

        }
        if (hit.CompareTag("PlayerTower")&& !playerNear)
        {
            towerNear = true;
        }
    }
    void OnTriggerExit(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            playerNear = false;
        }
        if (hit.CompareTag("PlayerMinion"))
        {
            minionNear = false;
        }
        if (hit.CompareTag("PlayerTower"))
        {
            towerNear = false;
        }
    }
}

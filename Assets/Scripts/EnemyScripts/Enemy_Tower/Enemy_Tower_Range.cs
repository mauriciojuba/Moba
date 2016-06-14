using UnityEngine;
using System.Collections;

public class Enemy_Tower_Range : MonoBehaviour {
    public bool playerNear, minionNear;
    public GameObject closestMinion;

    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            playerNear = true;
        }
        if (hit.CompareTag("PlayerMinion") && !playerNear)
        {
            minionNear = true;
            closestMinion = hit.gameObject;

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
    }
}

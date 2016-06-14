using UnityEngine;
using System.Collections;

public class AI_Enemy_Minion_Range : MonoBehaviour {

    public bool playerNear;
    public GameObject player;

    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player") || hit.CompareTag("PlayerMinion") || hit.CompareTag("PlayerTower"))
        {
            playerNear = true;
            player = hit.gameObject;
        }
    }
    void OnTriggerExit(Collider hit)
    {
        if (hit.CompareTag("Player") || hit.CompareTag("PlayerMinion") || hit.CompareTag("PlayerTower"))
        {
            playerNear = false;
        }
    }
}

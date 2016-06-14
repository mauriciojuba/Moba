﻿using UnityEngine;
using System.Collections;

public class Enemy_Hero_01_Attack : MonoBehaviour {

    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player")|| hit.CompareTag("PlayerMinion") || hit.CompareTag("PlayerTower"))
        {
            hit.gameObject.GetComponent<LivingEntity>().Hit(10f);
        }
    }
}

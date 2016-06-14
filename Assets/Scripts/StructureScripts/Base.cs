using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Base : MonoBehaviour {

	public enum baseTeam{ally,enemy};
	public baseTeam team;
	public GameObject[] enemies;
	public Transform spawnPoint;
	public float minSpawnTime = 1f;
	public float maxSpawnTime = 10f;
	public int squadronSize = 1;
	GameObject enMaster;

	void Start () 
	{
		this.GetComponent<LivingEntity>().onDeath+=baseDestroyed;
		Invoke ("SpawnEnemy",Random.Range (minSpawnTime,maxSpawnTime));
		enMaster = new GameObject();
		enMaster.name = "enemies";
	}

	void SpawnEnemy () 
	{
		for (int i = 0; i < squadronSize-1; i++) {
			GameObject newEnemy = Instantiate (enemies [Random.Range (0, enemies.Length)], spawnPoint.position, spawnPoint.rotation) as GameObject;
			newEnemy.transform.parent = enMaster.transform;
			newEnemy.GetComponent<LivingEntity>().onDeath+=enemyDead;
		}

		Invoke ("SpawnEnemy",Random.Range (minSpawnTime,maxSpawnTime)); 
	}

	void enemyDead(){
		//do something;
	}

	void baseDestroyed(){
		switch(team){
		case(baseTeam.ally):break;
		case(baseTeam.enemy):break;
		}
	}
}

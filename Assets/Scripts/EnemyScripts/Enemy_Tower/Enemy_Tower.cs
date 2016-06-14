using UnityEngine;
using System.Collections;

public class Enemy_Tower : MonoBehaviour {

    public float Life;
    public Transform muzzle,top;
    public Enemy_Tower_Range range;
    GameObject Player;
    public GameObject bullet;
    bool canShoot;
    public float cooldown;
    float count;

    void Start()
    {
        Player = GameObject.Find("Player");
    }

    void Update()
    {
        if (range.playerNear)
        {
            top.LookAt(new Vector3(Player.transform.position.x, this.transform.position.y, Player.transform.position.z));
            if (count >= cooldown) {
                Shoot();
            }
        }
        else if (range.minionNear)
        {
            top.LookAt(new Vector3(range.closestMinion.transform.position.x, this.transform.position.y, range.closestMinion.transform.position.z));
            if (count >= cooldown)
            {
                Shoot();
            }
        }
        count += Time.deltaTime;
    }
    void Shoot()
    {
        Instantiate(bullet, muzzle.position, muzzle.rotation);
        count = 0;
    }
}

using UnityEngine;
using System.Collections;

public class Player_Tower : MonoBehaviour {

    public float Life;
    public Transform muzzle, top;
    public Player_Tower_Range range;
    public GameObject bullet;
    bool canShoot;
    public float cooldown;
    float count;

    void Update()
    {
        if (range.enemyNear)
        {
            top.LookAt(new Vector3(range.closestEnemy.transform.position.x, this.transform.position.y, range.closestEnemy.transform.position.z));
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

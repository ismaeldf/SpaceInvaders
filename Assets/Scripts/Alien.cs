using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Alien : MonoBehaviour, IShootable
{
    public Team team;
    [HideInInspector]
    public Weapon weapon;

    private void Awake()
    {
        weapon = GetComponentInChildren<Weapon>();
    }

    private void Start() => StartCoroutine(AlienShooting());

    public void OnShot(Bullet bullet)
    {
        bullet.speed = 0;
        Destroy(this.gameObject);
    }

    public Team GetTeam()
    {
        return team;
    }

    IEnumerator AlienShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 15));
            Shoot();
        }
    }

    void Shoot()
    {
        weapon.ShootBullet();
    }
}

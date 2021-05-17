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

    private Animator animator;

    private void Awake()
    {
        weapon = GetComponentInChildren<Weapon>();
        animator = GetComponent<Animator>();
    }

    private void Start() => StartCoroutine(AlienShooting());

    public void OnShot(Bullet bullet)
    {
        bullet.speed = 0;
        animator.SetTrigger("Death");
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

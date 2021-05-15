using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   public Bullet bullet;
   public Vector2 bulletDirection;
   public float bulletSpeed;
   private GameObject bulletHolder;
   private IShootable ishootable;

   private void Awake()
   {
      bulletHolder = GameObject.Find("BulletHolder");
      ishootable = GetComponentInParent<IShootable>();

   }

   public void ShootBullet()
   {
      Bullet instantiated = Instantiate(bullet, transform.position, Quaternion.identity, bulletHolder.transform);
      instantiated.speed = bulletSpeed;
      instantiated.direction = bulletDirection;
      instantiated.team = ishootable.GetTeam();
      instantiated.enabled = true;
   }
}

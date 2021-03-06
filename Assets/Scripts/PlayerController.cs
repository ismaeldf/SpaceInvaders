using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, IShootable
{
    public Team team;
    
    public float speed = 10;
    
    private Vector2 movement;
    
    private Rigidbody2D rb;
    
    private Weapon weapon;

    public int lives = 3;

    private Animator animator;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        weapon = GetComponentInChildren<Weapon>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * (Time.fixedDeltaTime * speed));
    }

    public void Movement(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            movement = context.ReadValue<Vector2>();
        }else if (context.canceled)
        {
            movement = Vector2.zero;
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            weapon.ShootBullet();
        }
    }

    public void OnShot(Bullet bullet)
    {
        bullet.speed = 0;
        lives--;
        animator.SetTrigger("Death");
        animator.SetInteger("Lives", lives);
    }

    public Team GetTeam()
    {
        return team;
    }
}
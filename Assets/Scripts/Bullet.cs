using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    Player,
    Aliens,
}

public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public Team team;
    
    public Vector2 direction;
    public float speed;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
       rb.MovePosition(rb.position + direction * (speed * Time.fixedDeltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IShootable shootable = other.GetComponent<IShootable>();
        if (shootable!=null)
        {
            shootable.OnShot(this);
            return;
        }
        Destroy(this.gameObject);
    }
}

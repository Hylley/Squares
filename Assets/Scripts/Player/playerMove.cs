using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : Entity
{
    [HideInInspector] public static playerMove instance;
    [SerializeField] int speed;
    Rigidbody2D rb;
    public delegate void callback();
    public callback deathCallback = () => { };


    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);
    }

    public new void TakeDamage(int damage)
    {
        if (health - damage > 0)
        {
            health -= damage;
            playerView._camera.Shake(.3f, .6f);
            return;
        }

        health = 0;
        Die();
    }

    public new void Die()
    {
        Debug.Log("Player die!");
        deathCallback();
    }
}

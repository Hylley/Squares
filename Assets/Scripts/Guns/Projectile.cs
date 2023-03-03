using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectile
{
    void OnTriggerEnter2D(Collider2D hit);
    IEnumerator Countdown(int seconds);
}

public class Projectile : MonoBehaviour, IProjectile
{
    public int speed = 10;
    public int damage;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        StartCoroutine(Countdown(10));
    }


    public void OnTriggerEnter2D(Collider2D hit)
    {
        Destroy(gameObject);
    }

    public IEnumerator Countdown(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }
}
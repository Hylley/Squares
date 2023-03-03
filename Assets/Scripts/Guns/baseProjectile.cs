using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseProjectile : Projectile
{
    public float knockback;
    public ParticleSystem particles;

    public new void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            return;
        }

        hit.gameObject.GetComponent<Entity>()?.TakeDamage(damage);
        Knockback(hit.gameObject.GetComponent<Rigidbody2D>());

        particles.transform.position = hit.transform.position;
        particles.Play();
        particles.transform.parent = null;

        Destroy(gameObject);
    }

    public void Knockback(Rigidbody2D rb)
    {
        rb.AddForce(transform.right * knockback, ForceMode2D.Impulse);
    }
}

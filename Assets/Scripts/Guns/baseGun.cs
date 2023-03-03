using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baseGun : Gun
{
    public GameObject projectile;
    public ParticleSystem particles;

    void Update()
    {
        if (!active || Time.timeScale == 0)
        {
            return;
        }

        Face();

        if (Input.GetMouseButton(0))
        {
            Shoot(baseDamage);
        }
    }

    public new void Shoot(int damage)
    {
        GameObject newProjectile = Instantiate(projectile, tip.position, transform.rotation);
        newProjectile.GetComponent<Projectile>().damage = damage;
        particles.Play();

        playerView._camera.Shake(.3f, .3f);

        active = false;
        StartCoroutine(Cooldown());
    }
}

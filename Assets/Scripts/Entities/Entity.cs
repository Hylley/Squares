using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    void TakeDamage(int damage);
    void Die();
}

public class Entity : MonoBehaviour, IEntity
{
    public bool active = true;
    public int health;

    public void TakeDamage(int damage)
    {
        if (health - damage > 0)
        {
            health -= damage;
            return;
        }

        health = 0;
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
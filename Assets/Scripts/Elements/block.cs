using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : Entity
{
    public float mtSpeed;
    public int baseDamage;
    public float cooldown;
    bool canAttack = true;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!active)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, playerMove.instance.transform.position, mtSpeed * Time.deltaTime);
    }

    void OnTriggerStay2D(Collider2D hit)
    {
        if (!canAttack || !hit.CompareTag("Player"))
        {
            return;
        }

        hit.gameObject.GetComponent<playerMove>().TakeDamage(baseDamage);
        canAttack = false;
        StartCoroutine(waitCooldown());
    }

    IEnumerator waitCooldown()
    {
        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }
}

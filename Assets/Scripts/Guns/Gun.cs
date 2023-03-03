using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGun
{
    void Face();
    void Shoot(int damage);
    IEnumerator Cooldown();
}

public class Gun : MonoBehaviour, IGun
{
    public Transform tip;
    [Space(7)]
    public bool active = true;
    public int baseDamage = 10;
    public float cooldown = 1;

    void Update()
    {
        Face();
        if (!active)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Shoot(baseDamage);
        }
    }

    public void Face()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(mouse.y - transform.position.y, mouse.x - transform.position.x) * Mathf.Rad2Deg);
    }

    public void Shoot(int damage)
    {
        Debug.Log("Shoot!");

        active = false;
        StartCoroutine(Cooldown());
    }

    public IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldown);
        active = true;
    }
}
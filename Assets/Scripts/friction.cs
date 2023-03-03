using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friction : MonoBehaviour
{
    public float frictionCoefficient = 0.2f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude != 0)
        {
            Vector2 frictionForce = -rb.velocity.normalized * frictionCoefficient;
            rb.AddForce(frictionForce, ForceMode2D.Impulse);
        }
    }
}

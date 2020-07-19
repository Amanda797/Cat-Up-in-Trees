using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hedgehogcontroller : MonoBehaviour
{
    public Pawn pawn;
    float direction = 1;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pawn.move(direction);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Waypoint"))
        {
            direction *= -1;
        }
        
        if (collision.gameObject.GetComponent<Player>())
        {
            Health health = collision.gameObject.GetComponent<Health>();
            health.TakeDamage(damage);

            pawn.health.TakeDamage(50);
        }
    }
}

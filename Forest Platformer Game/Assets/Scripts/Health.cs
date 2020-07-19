using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Pawn pawn;

    public float health;
    public float maxHealth;

    private void Start()
    {
        pawn = GetComponent<Pawn>();
    }
    public void TakeDamage(float damage)
    {
        //subtract damage from health here
        health -= damage;

        //play hit audio
        pawn.audioSource.clip = pawn.hitSFX;
        pawn.audioSource.Play();
    }
    private void Update()
    {
        if(health <= 0)
        {
            pawn.audioSource.clip = pawn.deathSFX;
            pawn.audioSource.Play();

            if (pawn.gameObject.GetComponent<Hedgehogcontroller>())
            {
                GameManager.instance.enemiesInScene.Remove(this.gameObject);
                Destroy(this.gameObject);
            }

            if (pawn.gameObject.GetComponent<Player>())
            {
                GameManager.instance.isAlive = false;
            }
        }
    }
}

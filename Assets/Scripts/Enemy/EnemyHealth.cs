using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    public float health;

    public GameObject dyingEffect;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            GetComponent<EnemyDrops>().DropXp();
            Instantiate(dyingEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

using System;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Rigidbody2D rb;

    public float bulletSpeed;

    public float bulletLifeTime;

    public float damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = transform.right * bulletSpeed;
        
        Destroy(gameObject, bulletLifeTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemyScript))
        {
            enemyScript.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}

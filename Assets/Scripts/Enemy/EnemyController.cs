using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float rotateSpeed = 15;

    public Transform playerPos;

    private Rigidbody2D rb;

    private bool isAttacking = false;
    public float enemyDamage;
    public float enemySpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindObjectOfType<PlayerControl>().transform;
    }

    private void Update()
    {
        Vector2 direction = playerPos.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);

        if (!isAttacking)
        {
            rb.linearVelocity = transform.right * enemySpeed;
        }

        if (isAttacking)
        {
            playerPos.GetComponent<PlayerControl>().TakeDamage(enemyDamage);
        }
    }
}

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
        if (GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>().playerAlive)
        {
            playerPos = GameObject.FindObjectOfType<PlayerControl>().transform;
        }
    }

    private void Update()
    {
        if (GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>().playerAlive)
        {
            Vector2 direction = playerPos.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);

            rb.velocity = transform.right * enemySpeed;

            if (isAttacking)
            {
                playerPos.GetComponent<PlayerControl>().TakeDamage(enemyDamage);
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent<PlayerControl>(out PlayerControl playerScript))
        {
            isAttacking = true;
        }
    }
    
    public void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent<PlayerControl>(out PlayerControl playerScript))
        {
            isAttacking = false;
        }
    }
}

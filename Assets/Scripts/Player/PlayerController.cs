using UnityEngine;
public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerStats playerStats;

    public Transform firePoint;
    public Transform bulletPrefab;

    public float moveSpeed;
    public int maxHealth;
    public int health;

    public PlayerWeapons currentWeapons;

    private bool isFiring = false;
    private float fireTimer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerStats.GetComponent<PlayerStats>();
        RefreshStats();
        health = maxHealth;
    }

    public void RefreshStats()
    {
        moveSpeed = playerStats.moveSpeedStat;
        maxHealth = playerStats.maxHealthStat;
    }

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        rb.linearVelocity = new Vector2(moveX * moveSpeed, moveY * moveSpeed);

        if (Input.GetMouseButtonDown(0))
        {
            isFiring = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isFiring = false;
        }

        if (isFiring)
        {
            if (fireTimer > 1 / currentWeapons.weaponFireRate)
            {
                fireTimer = 0;
                Shoot();
            }   
        }

        fireTimer += Time.deltaTime;
    }

    public void Shoot()
    {
        for (int i = 0; i < currentWeapons.weaponBulletAmount; i++)
        {
            Transform spawnBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            PlayerBullet bullet = spawnBullet.GetComponent<PlayerBullet>();
            bullet.damage = currentWeapons.weaponDamage;
            bullet.bulletSpeed = currentWeapons.weaponBulletSpeed;
            spawnBullet.Rotate(0,0, Random.Range(-currentWeapons.weaponBulletSpread, currentWeapons.weaponBulletSpread));
        }
    }
}

using UnityEngine;

public class Fox : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float shootTimer = 0f;
    private float shootCooldown = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        HandleShooting();
    }

    void HandleShooting()
    {
        // Update shoot timer
        shootTimer += Time.deltaTime;

        // Handle shooting
        if (shootTimer >= shootCooldown)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    private void Shoot()
    {
        float bulletX = transform.position.x;
        float bulletY = transform.position.y;

        Vector2 bulletPosition = new Vector2(bulletX, bulletY);

        Instantiate(bulletPrefab, bulletPosition, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"[Fox] Collision detected with: {collision.gameObject.name}");

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}

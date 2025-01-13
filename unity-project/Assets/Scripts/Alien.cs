using UnityEngine;

public enum AlienAIBehaviour
{
    Shoot,
}

public class Alien : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public AlienAIBehaviour aiBehaviour = AlienAIBehaviour.Shoot;
    private float shootTimer = 0f;
    private float shootCooldown = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        switch (aiBehaviour)
        {
            case AlienAIBehaviour.Shoot:
                HandleShooting();
                break;
        }
    }

    void HandleShooting()
    {
        shootTimer += Time.deltaTime;

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
        Debug.Log($"[Alien] Collision detected with: {collision.gameObject.name}");

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}

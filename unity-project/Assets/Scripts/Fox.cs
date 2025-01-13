using UnityEngine;

public enum FoxAIBehaviour
{
    UpDownShoot,
}

public class Fox : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public FoxAIBehaviour aiBehaviour = FoxAIBehaviour.UpDownShoot;
    private float shootTimer = 0f;
    private float shootCooldown = 1f;
    public float range = 2f;
    private float speed = 1f;
    private float startY;
    private bool goingUp = true;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        switch (aiBehaviour)
        {
            case FoxAIBehaviour.UpDownShoot:
                MoveUpDown();
                HandleShooting();
                break;
        }
    }

    private void MoveUpDown()
    {
        if (goingUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        if (transform.position.y > startY + range)
        {
            goingUp = false;
        }
        else if (transform.position.y < startY - range)
        {
            goingUp = true;
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
        Debug.Log($"[Fox] Collision detected with: {collision.gameObject.name}");

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}

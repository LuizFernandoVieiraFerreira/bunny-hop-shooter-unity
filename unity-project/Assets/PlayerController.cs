using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 1f;
    // public float shootCooldown = 0.2f;
    // public float damageCooldown = 1f;
    // public int maxHealth = 3;
    // public int health = 3;
    public Sprite[] sprites; // 0 - normal, 1 - damaged (for flickering)
    public SpriteRenderer spriteRenderer;

    // private float shootTimer = 0;
    // private float damageTimer = 0;
    // private bool isDamaged = false;
    // private bool flickerTick = true;

    private Vector2 velocity;
    private Vector2 movement;

    // private float animationTimer = 0f;
    // private int currentSpriteIndex = 0;
    // private bool isAlive = true;

    // public LayerMask collisionMask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // health = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();

        transform.position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // if (isAlive)
        // {
            HandleMovement();
            // HandleShooting();
            // HandleDamageFlicker();

            // Update timers
            // shootTimer += Time.deltaTime;
            // damageTimer += Time.deltaTime;
        // }
    }

    void HandleMovement()
    {
        // Basic movement using the arrow keys or WASD
        movement.x = Input.GetKey(KeyCode.LeftArrow) ? -1 : Input.GetKey(KeyCode.RightArrow) ? 1 : 0;
        movement.y = Input.GetKey(KeyCode.UpArrow) ? 1 : Input.GetKey(KeyCode.DownArrow) ? -1 : 0;

        // Use velocity in terms of pixels per second
        velocity = movement.normalized * speed;

        // Apply fixed time step for consistent movement (ensure the player moves the same amount per second)
        velocity *= Time.deltaTime; 

        // Update position with constraints to stay within bounds
        // float newPosX = Mathf.Clamp(transform.position.x + velocity.x, 0 + 8, Screen.width - 8); // 8 is the half width of the sprite
        // float newPosY = Mathf.Clamp(transform.position.y + velocity.y, 0 + 8, Screen.height - 8); // 8 is the half height of the sprite

        // Get the camera's world bounds (in units, not pixels)
        float halfWidth = spriteRenderer.bounds.size.x / 2;
        float halfHeight = spriteRenderer.bounds.size.y / 2;

        // Get the camera's orthographic size and aspect ratio to calculate the edges of the screen in world units
        float cameraHeight = Camera.main.orthographicSize * 2;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        // The 16px offset from the topmost point
        float topOffset = 16f / Screen.height * cameraHeight;

        // Update position with constraints to stay within bounds
        float newPosX = Mathf.Clamp(transform.position.x + velocity.x, -cameraWidth / 2 + halfWidth, cameraWidth / 2 - halfWidth);
        float newPosY = Mathf.Clamp(transform.position.y + velocity.y, -cameraHeight / 2 + halfHeight, cameraHeight / 2 - halfHeight);

        transform.position = new Vector2(newPosX, newPosY);
    }

    // void HandleShooting()
    // {
    //     if (shootTimer > shootCooldown && Input.GetKey(KeyCode.Space)) // Fire on Space key
    //     {
    //         // Create bullet (For now, you can just log the shot or instantiate a bullet object)
    //         Debug.Log("Shooting");
    //         shootTimer = 0;
    //     }
    // }

    // void HandleDamageFlicker()
    // {
    //     if (isDamaged)
    //     {
    //         // Flicker effect
    //         if (flickerTick)
    //         {
    //             flickerTick = false;
    //             spriteRenderer.enabled = false;
    //         }
    //         else
    //         {
    //             flickerTick = true;
    //             spriteRenderer.enabled = true;
    //         }

    //         if (damageTimer > damageCooldown)
    //         {
    //             isDamaged = false;
    //             damageTimer = 0;
    //         }
    //     }
    // }

    // public void TakeDamage()
    // {
    //     if (damageTimer > damageCooldown)
    //     {
    //         health--;
    //         isDamaged = true;
    //         damageTimer = 0;
    //     }
    // }

    // public void Heal()
    // {
    //     if (health < maxHealth)
    //     {
    //         health++;
    //     }
    // }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Enemy"))
    //     {
    //         TakeDamage();
    //     }
    // }

    void DrawSprite()
    {
        // Simple sprite switching logic (flickering or animation for movement)
        // if (isDamaged)
        // {
        //     spriteRenderer.sprite = sprites[1]; // Damaged sprite
        // }
        // else
        // {
            spriteRenderer.sprite = sprites[0]; // Normal sprite
        // }
    }
}

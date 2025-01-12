using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 3f;  // Bullet speed
    // public int life = 1;  // Bullet lifespan
    // public string direction;  // Direction of movement: "left", "right", "up", or "down"

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // // Set the bullet's velocity direction based on the initial direction (to move it in the desired direction)
        // if (direction == "left")
        // {
        //     // Move the bullet to the left
        //     GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        // }
        // else if (direction == "right")
        // {
        //     // Move the bullet to the right
        //     GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        // }
        // else if (direction == "up")
        // {
        //     // Move the bullet upwards
        //     GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        // }
        // else if (direction == "down")
        // {
        //     // Move the bullet downwards
        //     GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        // }
    }

    private void Update()
    {
        // Check if the bullet's life has expired
        // if (life <= 0)
        // {
        //     Destroy(gameObject);  // Destroy the bullet when it's no longer alive
        // }
        // Move the bullet to the right by setting its velocity
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y); // Keep the y-velocity the same and set x to speed
    }

    // Collision detection
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            // life -= 1;  // Decrease life if the bullet hits an enemy or boss
            Destroy(gameObject);  // Destroy the bullet upon collision
        }
    }
}

using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float SCREEN_BOUNDARY_X = 10f;

    public float speed = 3f;

    private void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;

        if (transform.position.x > SCREEN_BOUNDARY_X)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}

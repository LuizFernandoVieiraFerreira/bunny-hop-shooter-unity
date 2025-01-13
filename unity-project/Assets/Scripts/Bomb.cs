using UnityEngine;

public enum BombAIBehaviour
{
    Idle,
    UpDown,
}

public class Enemy : MonoBehaviour
{
    public GameObject explosionPrefab;

    public BombAIBehaviour aiBehaviour = BombAIBehaviour.Idle;
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
            case BombAIBehaviour.Idle:
                break;
            case BombAIBehaviour.UpDown:
                MoveUpDown();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"[Enemy] Collision detected with: {collision.gameObject.name}");

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}

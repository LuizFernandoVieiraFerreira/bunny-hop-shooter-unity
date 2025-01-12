using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject explosionPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        
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

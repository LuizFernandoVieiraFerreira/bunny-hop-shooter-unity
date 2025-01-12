using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject smMeteorPrefab;

    private int life = 2;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"[Meteor] Collision detected with: {collision.gameObject.name}");

        if (collision.gameObject.CompareTag("Bullet"))
        {
            life--;

            if (life <= 0)
            {
                Explode();
            }
        }
    }

    private void Explode()
    {
        if (smMeteorPrefab != null)
        {
            Instantiate(smMeteorPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
            Instantiate(smMeteorPrefab, transform.position + Vector3.down * 0.5f, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}

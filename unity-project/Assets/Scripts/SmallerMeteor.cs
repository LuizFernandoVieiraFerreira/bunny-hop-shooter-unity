using UnityEngine;

public class SmallerMeteor : MonoBehaviour
{
    public GameObject explosionPrefab;

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
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                
                Destroy(gameObject);
            }
        }
    }
}

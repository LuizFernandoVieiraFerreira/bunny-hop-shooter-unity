using System.Collections;
using UnityEngine;

public class SmokeEffect : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] smokeSprites; // Array to hold the smoke frames (two frames)
    private int currentFrame = 0;
    private float frameTime = 0.3f; // Time for each frame (300ms)
    private float lastFrameTime = 0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(AnimateSmoke());
    }

    IEnumerator AnimateSmoke()
    {
        while (currentFrame < 6)
        {
            // Check if the time passed since the last frame is greater than frameTime
            if (Time.time - lastFrameTime > frameTime)
            {
                currentFrame++;
                spriteRenderer.sprite = smokeSprites[currentFrame % smokeSprites.Length];
                lastFrameTime = Time.time;
            }
            yield return null;
        }
        
        Destroy(gameObject); // Destroy the smoke after 6 frames
    }
}

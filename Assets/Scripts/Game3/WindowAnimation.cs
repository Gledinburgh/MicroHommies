using UnityEngine;

public class WindowAnimation : MonoBehaviour
{
    public Sprite[] frames;
    public float frameDuration = 0.1f; // Adjust the duration between frames

    private SpriteRenderer spriteRenderer;
    private int currentFrame = 0;
    private float timer = 0f;

    public bool isActive = false;

    private bool isFirstRun = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (frames.Length > 0)
        {
            spriteRenderer.sprite = frames[0];
        }
    }

    void Update()
    {

        if (isActive)
        {
            
            
            // Check if there are frames to animate
            if (frames.Length > 1)
            {
                timer += Time.deltaTime;

                // Change frame when the frameDuration is reached
                if (timer >= frameDuration)
                {
                    timer = 0f;
                    currentFrame = (currentFrame + 1) % frames.Length;
                    if (!isFirstRun && currentFrame <= 1 )
                    {
                        currentFrame = 2;
                    }
                    spriteRenderer.sprite = frames[currentFrame];
                    isFirstRun = false;
                }
            }

        }
    }
}
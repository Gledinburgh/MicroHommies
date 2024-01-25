using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ACAnimation : MonoBehaviour

{
    public Sprite[] frames;
    public float frameDuration = 0.1f; // Adjust the duration between frames

    private SpriteRenderer spriteRenderer;
    private int currentFrame = 0;
    private float timer = 0f;

    public bool isActive = true;

    

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
                    
                    spriteRenderer.sprite = frames[currentFrame];
                    
                }
            }

        }
    }
}
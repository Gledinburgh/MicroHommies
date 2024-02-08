using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControllerCheerLeader : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite[] idleSprites;
    public Sprite[] winSprites;
    public Sprite[] loseSprites;
    private Sprite[] currentSprites;

    public bool isIdle = false;
    public bool isWin = false;
    public bool isLose = false;

    public float frameDuration = 0.3f; // Adjust the duration between frames
    private int currentFrame = 0;
    private float timer = 0f;

    void Start()
    {

        isIdle = true;
        currentSprites = idleSprites;
        spriteRenderer.sprite = currentSprites[0];

    }

    // Update is called once per frame
    void Update()
    {

        // if changing from isIdle state to isWin state,
        // turn of isIdle, and change to new sprite set.
        if(isIdle && isWin)
        {
            isIdle = false;
            currentSprites = winSprites;            
        }
        // if isLose, change sprite set to new sprite set

        // if neither winning or losing, then set to idle
        if (!isIdle && !isWin && !isLose)
        {
            isIdle = true;
            currentSprites = idleSprites;
        }

        if (isIdle && isLose)
        {
            isIdle = false;
            currentSprites = loseSprites;
        }

        // continue playing current sprite set

        ContinueAnimation();
    }

    private void ContinueAnimation()
    {
        timer += Time.deltaTime;

        // Change frame when the frameDuration is reached
        if (timer >= frameDuration)
        {
            timer = 0f;
            currentFrame = (currentFrame + 1) % currentSprites.Length;

            spriteRenderer.sprite = currentSprites[currentFrame];

        }
    }

}

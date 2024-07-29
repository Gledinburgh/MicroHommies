using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopperAnimation : MonoBehaviour
{ 

    public Transform finalPoint;
    public float moveSpeed = 2f;


    private Vector3 finalPosition;

    public Sprite[] copperSprites;
    public float frameDuration = 0.1f; // Adjust the duration between frames

    private SpriteRenderer spriteRenderer;
    private int currentFrame = 0;
    private float timer = 0f;

    public bool isActive = false;


    void Start()
    {

            spriteRenderer = GetComponent<SpriteRenderer>();

            finalPosition = finalPoint.position;

     
        


    }

    void Update()
    {
        if (isActive)
        {
                if (copperSprites.Length > 1)
                {
                    timer += Time.deltaTime;

                    // Change frame when the frameDuration is reached
                    if (timer >= frameDuration)
                    {
                        timer = 0f;
                        currentFrame = (currentFrame + 1) % copperSprites.Length;

                        spriteRenderer.sprite = copperSprites[currentFrame];

                    }
                }

                if (transform.position.y <= finalPosition.y)
                {
                    transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
                }
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortSceneManager : MonoBehaviour
{

    //have Shortscene sprites available
    //when button is pressed, move to next image sprite
    //when no more images, move to micro games.
   
    private GameManager gameManager;
    public bool isWin;
    public Sprite[] sprites;
    private SpriteRenderer SpriteRenderer;

    private int currentIndex = 0;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.sprite = sprites[0];
    }


    private void EndMicrogame()
    {
        gameManager.EndMicrogame(1);
        Debug.Log("Short Scene Intro ended");

    }

    
    public void Win()
    {
        if (isWin != true)
        {           
            Invoke("EndMicrogame", 3);
        }       
    }

    void Update()
    {
        // Check if the button is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Change the sprite
            ChangeSprite();
        }
    }

    public void ChangeSprite()
    {
        // Increment the index
        currentIndex++;

        // If index exceeds the number of sprites, reset it to 0
        if (currentIndex >= sprites.Length)
        {
            gameManager.StartMicrogame("Microgame0");
            return;
        }
        SpriteRenderer.sprite = sprites[currentIndex];
        
    }




    }

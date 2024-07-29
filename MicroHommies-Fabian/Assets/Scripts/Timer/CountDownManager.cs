using UnityEngine;

public class CountDownManager : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] currentSprites; // Assign the sprites representing each second in the Inspector
    public Sprite[] oneSprites;
    public Sprite[] twoSprites;
    public Sprite[] threeSprites;
    private TimerManager timerManager;

    public bool isActive = true;
    private int currentSecondRendered;
    int currentSecond;

    public float frameDuration = 0.2f; // Adjust the duration between frames
    private int currentFrame = 0;
    private float frameTimer = 0f;

    private void Start()
    {
        // Find the TimerManager in the scene
        timerManager = FindObjectOfType<TimerManager>();
        currentSprites = threeSprites;
    }

    private void Update()
    {
        if (isActive)
        {
        currentSecond = Mathf.CeilToInt(timerManager.GetCurrentTime());
        DetermineSpriteSet();
        ContinueAnimation();
        }
    }

    private void ContinueAnimation()
    {
        if (currentSecond <= 0 || currentSecond >= 4)
        {
            spriteRenderer.sprite = null;
        }

        else
        {

            frameTimer += Time.deltaTime;

            // Change frame when the frameDuration is reached
            if (frameTimer >= frameDuration)
            {
                frameTimer = 0f;
                currentFrame = (currentFrame + 1) % currentSprites.Length;

                spriteRenderer.sprite = currentSprites[currentFrame];

            }
        }

    }

    private void DetermineSpriteSet()
    {
        

        if (currentSecond == 1)
        {
            currentSprites = oneSprites;
            Debug.Log("one sprites set");
        }
        if (currentSecond == 2)
        {
            currentSprites = twoSprites;
            Debug.Log("two sprites set");
        }
        if (currentSecond == 3)
        {
            currentSprites = threeSprites;
            Debug.Log("three sprites set");
        }

    }
    
}
using UnityEngine;

public class CountDownManager : MonoBehaviour
{
    public SpriteRenderer counterSpriteRenderer;
    public Sprite[] secondSprites; // Assign the sprites representing each second in the Inspector
    private TimerManager timerManager;
    public bool isActive = true;
    public int currentSecondRendered;

    private void Start()
    {
        // Find the TimerManager in the scene
        timerManager = FindObjectOfType<TimerManager>();
    }

    private void Update()
    {
        // Update the counter sprite based on the current second from TimerManager
        if (timerManager != null && isActive == true)
        {
            int currentSecond = Mathf.CeilToInt(timerManager.GetCurrentTime());


            // Ensure the current second is within the range of available sprites
            if (currentSecond >= 0 && currentSecond < secondSprites.Length)
            {
                counterSpriteRenderer.sprite = secondSprites[currentSecond];
            }
        }

        else
        {
            counterSpriteRenderer.sprite = secondSprites[0];
        }
    }

    private void OnTimerExpired()
    {
        // Handle any additional logic when the timer expires
        Debug.Log("Timer expired! Do something here.");
    }
}
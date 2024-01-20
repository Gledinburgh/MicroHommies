using UnityEngine;
using UnityEngine.Events;

public class TimerManager : MonoBehaviour
{
    public float startingTime = 20f; // Adjust this value based on your requirements
    public float currentTime;

    public UnityEvent OnTimerExpired;

    private void Awake()
    {

    }

    private void Start()
    {
        currentTime = startingTime;
        StartTimer();
    }

    private void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            currentTime = 0f;
            OnTimerExpired.Invoke();
        }
    }

    public void StartTimer()
    {
        // You can add additional logic here if needed
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }

    public void SetTime(float seconds)
    {
        currentTime = seconds;
    }
}
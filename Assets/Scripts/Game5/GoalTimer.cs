using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTimer : MonoBehaviour
{   
    public float startTime = 0f;
    public float timeLimit = 0f;
    private float timer = 0f;
    private bool startTimer = false;
    public bool conditionsMet = false;
    private float conditionCheckTime = 0f;
    public float coolDownTimer = 3f;

    private MicrogameManager5 microgameManager5;

    private void Awake()
    {
        microgameManager5 = FindObjectOfType<MicrogameManager5>();
    }

    void Update()
    {

        if (conditionsMet)
        {
            timer += Time.deltaTime;            

            if (timer >= timeLimit)
            {
                microgameManager5.Win();
            }
            

        }
        // Check if conditions are not met for 3 seconds
        if (!conditionsMet)
        {
            conditionCheckTime += Time.deltaTime;
            if (conditionCheckTime >= coolDownTimer)
            {
                
                ResetTimer();
            }
        }
    }

    // Call this method to start the timer and set conditionsMet to true
    public void StartTimer()
    {
        startTimer = true;
        timer = startTime;
        conditionsMet = true;
        conditionCheckTime = 0f;
    }

    // Call this method to reset the timer and set conditionsMet to false
    public void ResetTimer()
    {
        startTimer = false;
        timer = 0f;
        conditionsMet = false;
        conditionCheckTime = 0f;
    }
}
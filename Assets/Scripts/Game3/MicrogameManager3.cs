using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrogameManager3 : MonoBehaviour
{
    private TimerManager timerManager;
    private GameManager gameManager;
    private AnimationControllerCheerLeader cheerLeader;
    private BorderManager borderManager;

    private CountDownManager countDownManager;
    private AngleControl angleControl;
    private RemoveLid removeLid;
    private CopperAnimation copperAnimation;

    private WindowAnimation windowAnimation;
    private WindowLights windowLights;
   

    public bool isWin;

    private void Awake()
    {
        gameManager = GameManager.Instance;
     
    }

    private void Start()
    {
        timerManager = FindObjectOfType<TimerManager>();
        countDownManager = FindObjectOfType<CountDownManager>();
        angleControl = FindObjectOfType<AngleControl>();
        removeLid = FindObjectOfType<RemoveLid>();
        copperAnimation = FindObjectOfType<CopperAnimation>();
        windowAnimation = FindObjectOfType<WindowAnimation>();
        windowLights = FindObjectOfType<WindowLights>();
        cheerLeader = FindObjectOfType<AnimationControllerCheerLeader>();
        borderManager = FindObjectOfType<BorderManager>();
        

        angleControl.isActive = true;
        countDownManager.isActive = true;
        copperAnimation.isActive = false;
        removeLid.isActive = false;
        windowAnimation.isActive = false;
        cheerLeader.isIdle = true;

        if (timerManager != null && !isWin)
        {
           timerManager.OnTimerExpired.AddListener(Lose);
        }
        else
        {
            Debug.LogError("TimerManager not found!");
        }
    }

    private void EndMicrogame()
    {
        gameManager.EndMicrogame(1);
        Debug.Log("Microgame ended. Score: " + CalculateScore());

    }

    private int CalculateScore()
    {
        // Add logic to calculate the microgame score based on player performance
        return 100;
    }

    public void Win()
    {
        if (isWin != true)
        {          
            isWin = true;
            
            //turn off micro game mechanics
            angleControl.isActive = false;
            countDownManager.isActive = false;
            cheerLeader.isWin = true;
            borderManager.isWin = true;
            

            // Activate Win animations
            removeLid.isActive = true;
            copperAnimation.isActive = true;
            Debug.Log("Game3 win");
            Invoke("EndMicrogame", 5f);
        }

        //End Game
    }

    private void Lose()
    {
        if (!isWin)
        {

        countDownManager.isActive = false;
        windowAnimation.isActive = true;
        angleControl.isActive = false;
        windowLights.isActive = true;
        cheerLeader.isLose = true;
        borderManager.isLose = true;

        Invoke("EndMicrogame", 3f);
        }
       
    }


}
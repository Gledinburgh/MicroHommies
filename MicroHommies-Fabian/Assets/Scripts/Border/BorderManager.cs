using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderManager : MonoBehaviour
{


    public Animator patternAnimation;
    public SpriteRenderer PatternSpriteRenderer;
    public AnimationControllerCheerLeader[] isWinListoners;
    public HueCycler[] hueCyclers;

    public bool isWin;
    public bool isLose;


    void Start()
    {
    }

    private void Win()
    {
        patternAnimation.SetBool("Happy", true);

        foreach (AnimationControllerCheerLeader isWinListoner in isWinListoners)
        {
            isWinListoner.isWin = true;            
        }
        foreach (HueCycler hueCycler in hueCyclers)
        {
            hueCycler.isActive = true;            
        }
    }

    private void Lose()
    {
        patternAnimation.SetBool("Sad", true);
        foreach (AnimationControllerCheerLeader isWinListoner in isWinListoners)
        {
            isWinListoner.isLose = true;
        }
    }
    void Update()
    { 
        if (isWin)
        {
            Win();
        }

        if (isLose)
        {
            Lose();
        }
        
    }
}

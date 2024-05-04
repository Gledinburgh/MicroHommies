
using UnityEngine;

public class MicrogameManager5 : MonoBehaviour
{
    private TimerManager timerManager;
    private GameManager gameManager;
    private BorderManager borderManager;


    public bool isWin;

    private void Awake()
    {
        gameManager = GameManager.Instance;

    }

    private void Start()
    {
        timerManager = FindObjectOfType<TimerManager>();
        borderManager = FindObjectOfType<BorderManager>();



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
        Debug.Log("Microgame ended");

    }

    public void Win()
    {
        if (isWin != true)
        {
            isWin = true;

            //turn off micro game mechanics
            borderManager.isWin = true;


            // Activate Win animations

            Debug.Log("Game5 win");
            Invoke("EndMicrogame", 3f);
        }

        //End Game
    }

    private void Lose()
    {
        if (!isWin)
        {          
            Invoke("EndMicrogame", 3f);
        }

    }


}
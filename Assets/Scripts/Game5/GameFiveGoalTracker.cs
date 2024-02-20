using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameFiveGoalTracker : MonoBehaviour
    
    //If certine range of position
      //Have some numerical value for position

    //is held for more than .25 seconds
      //have a timer 
{
    [SerializeField]
    private float goalMeasurement; // Assign the pivot point in the Unity Editor
    private Vector3 initialMousePosition;
    
    public bool isActive = true;
    

    public float minGoal = -1.5f;
    public float maxGoal = 2.5f;

    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        if (isActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                initialMousePosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                // Reset the initial mouse position when dragging stops
                initialMousePosition = Vector3.zero;
            }

            if (Input.GetMouseButton(0) && initialMousePosition != Vector3.zero)
            {
                // Get the vertical movement of the mouse
                float mouseX = Input.mousePosition.x - initialMousePosition.x;

                mouseX *= -.1f;
                Vector3 move = Vector3.forward;
               
               
                transform.RotateAround(transform.position, move, mouseX);
                

                // Update the initial mouse position for the next frame
                initialMousePosition = Input.mousePosition;
            }
                

        }

        UpdateGoalTracker();

    }

    private void UpdateGoalTracker()
    {
        goalMeasurement = NormalizeAngle(transform.rotation.eulerAngles.z);
               
        if (goalMeasurement >= minGoal && goalMeasurement <= maxGoal)

        {
            Debug.Log("Goal Met");
            sprite.color = Color.green;
        }

        else
        {
            Debug.Log("Goal not Met");
                
            sprite.color = Color.white;
        }


    }

    float NormalizeAngle(float angle)
    {
        if (angle > 180f)
        {
            angle -= 360f;
        }
        return angle;
    }
}

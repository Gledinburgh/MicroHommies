using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAngleTracker : MonoBehaviour
{
    private HingeJoint2D joint;
    public bool maxAngleReached = false;
    public bool minAngleReached = false;
    private MicrogameManager5 gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<MicrogameManager5>();
    }
    void Start()
    {
        joint = GetComponent<HingeJoint2D>();
    }

    void Update()
    {

        if (joint.jointAngle <= joint.limits.max && maxAngleReached)
        {
            maxAngleReached = false;
        }
        // Check if the current angle has reached the maximum
        if (joint.jointAngle >= joint.limits.max && !maxAngleReached)
        {
            maxAngleReached = true;

            Debug.Log("Max angle reached!");
        }

        if (joint.jointAngle <= joint.limits.min && !minAngleReached)
        {
            //gameManager.Win();
            minAngleReached = true;
            Debug.Log("min angle reached!");
        }


    }
}
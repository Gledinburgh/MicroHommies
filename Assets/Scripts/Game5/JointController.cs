using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointController : MonoBehaviour
{
    public Transform targetPosition;

    private Vector3 initialOffset;

    void Start()
    {
        initialOffset = transform.position - targetPosition.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = targetPosition.position + initialOffset;
    }
}

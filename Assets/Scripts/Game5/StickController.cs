using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickController : MonoBehaviour
{
    public Transform armPosition;

    private Vector3 initialOffset;

    void Start()
    {
        initialOffset = transform.position - armPosition.position;
    }

    // Update is called once per frame
    void Update()
    {

       transform.position = armPosition.position + initialOffset;
    }
}

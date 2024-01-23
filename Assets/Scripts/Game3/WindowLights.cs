using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowLights : MonoBehaviour
{

    public SpriteRenderer lights;
    public SpriteRenderer window;
    public SpriteRenderer ACFront;
    public bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
    }

    private void Update()
    {
        if (isActive)
        {
            lights.color = Color.yellow;
            window.color = Color.white;
            ACFront.color = Color.gray;
        }
    }

}

 

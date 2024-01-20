using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenProportionHandler : MonoBehaviour
{
    public float targetAspectRatio = 16f / 9f;

    private void Start()
    {
        AdjustScreenProportions();
    }

    private void AdjustScreenProportions()
    {
        float currentAspectRatio = (float)Screen.width / Screen.height;
        float scaleRatio = currentAspectRatio / targetAspectRatio;

        Camera.main.orthographicSize *= scaleRatio;

        // You may need to adjust other elements based on your specific requirements.
        // For example, you might adjust the position of UI elements or background objects.
    }
}
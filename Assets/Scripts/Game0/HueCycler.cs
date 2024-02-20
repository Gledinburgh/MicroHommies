using System.Collections.Generic;
using UnityEngine;

public class HueCycler : MonoBehaviour
{
    public List<SpriteRenderer> targetRenderers;
    public GameObject targetParent;
    public bool isActive = false;
    public bool isFirstCycle = true;
    public float startHue = 100f; // Starting hue value
    public float endHue = 180f; // Ending hue value
    public float currentHue = 160f; // Ending hue value

    public float hueIncrement = 50f; // Change the increment value to control cycling speed

    void Start()
    {
        if (targetParent != null)
        {
            for (int i = 0; i < targetParent.transform.childCount; i++)
            {
                Transform child = targetParent.transform.GetChild(i);
                SpriteRenderer spriteRenderer = child.GetComponent<SpriteRenderer>();
                targetRenderers.Add(spriteRenderer);
            } 
        }

        if (targetRenderers.Count < 1)
        {
            Debug.LogError("No renderers are assigned to the Hue Cycler");
        }
    }

    void Update()
    {

        if (isActive && isFirstCycle)
        {
            currentHue = startHue;
            isFirstCycle = false;
        }
        // Check for input or trigger hue cycling based on your game logic
        if (isActive == true)
        {
            foreach (SpriteRenderer target in targetRenderers)
            {
            if (target != null) CycleHue(target);

            }
            
            
        }
    }

    public void CycleHue(SpriteRenderer sprite)
    {
        // Check if there's a SpriteRenderer
        if (sprite != null)
        {
            // Cycle through hues between startHue and endHue
            currentHue = (currentHue + hueIncrement * Time.deltaTime) % 360f;
            if (currentHue > endHue || currentHue < startHue)
            {
                hueIncrement *= -1;
            }



            // Convert HSL to RGB and set the color
            Color newColor = HSLToRGB(currentHue / 360f, 1f, 0.5f); // Constant saturation and lightness
            sprite.color = newColor;
        }
        else
        {
            Debug.LogWarning("Target SpriteRenderer not set.");
        }
    }

    // Convert HSL to RGB
    // Convert HSL to RGB
    Color HSLToRGB(float h, float s, float l)
    {
        if (s == 0f)
        {
            return new Color(l, l, l); // Achromatic (grayscale)
        }
        else
        {
            float q = (l < 0.5f) ? (l * (1f + s)) : (l + s - l * s);
            float p = 2f * l - q;

            float hk = h;
            if (hk < 0f) hk += 1f;
            if (hk > 1f) hk -= 1f;

            float r = HueToRGB(p, q, hk + 1f / 3f);
            float g = HueToRGB(p, q, hk);
            float b = HueToRGB(p, q, hk - 1f / 3f);

            return new Color(r, g, b);
        }
    }

    float HueToRGB(float p, float q, float t)
    {
        if (t < 0f) t += 1f;
        if (t > 1f) t -= 1f;
        if (t < 1f / 6f) return p + (q - p) * 6f * t;
        if (t < 1f / 2f) return q;
        if (t < 2f / 3f) return p + (q - p) * (2f / 3f - t) * 6f;
        return p;
    }


}

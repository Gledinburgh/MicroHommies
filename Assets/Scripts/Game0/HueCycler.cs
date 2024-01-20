using UnityEngine;

public class HueCycler : MonoBehaviour
{
    private SpriteRenderer targetSpriteRenderer;
    public SpriteRenderer cross1;
    public SpriteRenderer cross2;
    public bool isActive = false;
    private float currentHue = 0f; // Initial hue value

    void Start()
    {
       
        
    }

    void Update()
    {
        // Check for input or trigger hue cycling based on your game logic
        if (isActive == true)

        {
            CycleHue(cross1);
            CycleHue(cross2);

        }
    }

    public void CycleHue(SpriteRenderer sprite)
    {
        // Check if there's a SpriteRenderer
        if (sprite != null)
        {
            // Cycle through hues
            currentHue = (currentHue + 30f) % 360f; // Change the increment value to control cycling speed

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

using UnityEngine;

public class CollisionHandler : MonoBehaviour
{

    private MicrogameManager0 microgameManager;
    private void Awake()
    {
        microgameManager = FindObjectOfType<MicrogameManager0>();
    }
    private void start()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // This method is called when a trigger overlap occurs.
        // Check if the collider belongs to the specific object you want.
        if (other.CompareTag("Cross"))
        {
            // Execute your code here.
            Debug.Log("Trigger overlap detected!");
            microgameManager.Win();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveLid : MonoBehaviour
{
    public float upwardForce = 20f;
    public float rightwardForce = 10f; // Adjust the rightward force as needed

    public HingeJoint2D hinge;
    public bool isActive;
    public BoxCollider2D boxCollider;
    public Rigidbody2D rb;

    private bool forceApplied = false;

    private void Awake()
    {
      
    }


    void Start()
    {
       
      
    }

void Update ()
{
    if (isActive)
        {
           

            // Apply upward force to the edge of the object
            
            if (rb != null && !forceApplied)
            {

                
                
                // Get the edge position (you might need to adjust this based on your object's structure)
                Vector2 edgePosition = transform.position + transform.up * (boxCollider.size.x / 8);

                Debug.Log("Edge possition" + edgePosition);
                // Apply force at the edge
                rb.AddForceAtPosition(Vector2.up * upwardForce, edgePosition, ForceMode2D.Impulse);

                rb.AddForce(Vector2.right * rightwardForce, ForceMode2D.Impulse);

                forceApplied = true;

               /* Debug.Log("removeLid");
                if (hinge != null)
                {
                    Debug.Log("destroy hinge");
                    Destroy(hinge);
                }*/
            }
        }
    }

       
}
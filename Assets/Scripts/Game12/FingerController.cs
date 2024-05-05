// FingerController.cs
using UnityEngine;

public class FingerController : MonoBehaviour
{
    public float speed = 1f; // Adjust this to control the speed of the finger
    private bool hasCollided = false;
    public MouseInputHandler mouseInput;

    void Update()
    {
        if (!hasCollided)
        {
            // Arrow key movement
            float verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);

            mouseInput.UpdateMouse();

        }

    }

    void Start()
    {
        
        
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Nose"))
        {
            Debug.Log("You Win!");
            hasCollided = true;

            // Optionally, you can add more actions here such as stopping the movement of the finger
        }
    }
}

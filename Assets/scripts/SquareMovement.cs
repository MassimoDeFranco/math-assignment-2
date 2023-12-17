using UnityEngine;

public class SquareMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 velocity;
    private float mass = 10f; // Mass of the square in kg
    private float upwardForce = 10f; // Adjust this value for the desired upward force
    private bool shouldApplyUpwardForce = false;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Check if the object is on the ground
        if (transform.position.y <= 0f)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);

            // If the object is on the ground, stop downward movement
            if (velocity.y < 0f)
            {
                velocity.y = 0f;
                shouldApplyUpwardForce = true; // Set the flag to apply upward force on the next frame
            }
        }

        // Check for mouse click
        if (shouldApplyUpwardForce && Input.GetMouseButtonDown(0)) // Change the button index as needed
        {
            // Apply upward impulse force
            velocity.y += upwardForce / mass;
            shouldApplyUpwardForce = false; // Reset the flag
        }

        // Simulate gravity with mass adjustment
        velocity.y += -9.8f * mass * Time.deltaTime;

        velocity = new Vector2(horizontal, velocity.y) * speed;
        transform.position += new Vector3(velocity.x, velocity.y, 0) * Time.deltaTime;

        // Clamp the position to ensure it doesn't go below y=0
        transform.position = new Vector3(transform.position.x, Mathf.Max(0f, transform.position.y), transform.position.z);
    }
}
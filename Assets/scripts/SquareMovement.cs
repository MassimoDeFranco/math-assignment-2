using UnityEngine;

public class SquareMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 velocity;
    private float mass = 10f; // Mass of the square in kg

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Simulate gravity with mass adjustment
        velocity.y += -9.8f * mass * Time.deltaTime;

        velocity = new Vector2(horizontal, vertical) * speed;
        transform.position += new Vector3(velocity.x, velocity.y, 0) * Time.deltaTime;

        // Check if the object is on the ground
        if (transform.position.y <= 0f)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);

            // If the object is on the ground, stop downward movement
            if (velocity.y < 0f)
            {
                velocity.y = 0f;
            }
        }
    }
}
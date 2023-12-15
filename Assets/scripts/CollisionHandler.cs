using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public float primitiveSize = 1f;

    private void Update()
    {
        // Remove the movement logic from this script

        // Get the positions of all primitives
        Vector3 squarePos = GameObject.Find("Square").transform.position;
        Vector3 circlePos = GameObject.Find("Circle").transform.position;
        Vector3 capsulePos = GameObject.Find("Capsule").transform.position;

        // Check for collisions manually (overlap in 2D space)
        if (CheckOverlap(squarePos, circlePos, primitiveSize) ||
            CheckOverlap(squarePos, capsulePos, primitiveSize) ||
            CheckOverlap(circlePos, capsulePos, primitiveSize))
        {
            SetColor(GameObject.Find("Square"), Color.green);
            SetColor(GameObject.Find("Circle"), Color.green);
            SetColor(GameObject.Find("Capsule"), Color.green);
        }
        else
        {
            SetColor(GameObject.Find("Square"), Color.red);
            SetColor(GameObject.Find("Circle"), Color.red);
            SetColor(GameObject.Find("Capsule"), Color.red);
        }
    }

    private bool CheckOverlap(Vector3 position1, Vector3 position2, float size)
    {
        // Calculate the distance between two positions
        float distance = Vector3.Distance(position1, position2);

        // Check if the distance is less than the sum of their sizes (if they overlap)
        return distance < size * 2;
    }

    private void SetColor(GameObject primitive, Color color)
    {
        primitive.GetComponent<SpriteRenderer>().color = color;
    }
}
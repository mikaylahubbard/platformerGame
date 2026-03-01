using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float patrolDistance = 3f;

    private Vector3 startPosition;
    private int direction = 1; // 1 = right, -1 = left

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Move in current direction
        transform.position += new Vector3(direction * moveSpeed * Time.deltaTime, 0, 0);

        //create bounds
        float rightBound = startPosition.x + patrolDistance;
        float leftBound = startPosition.x - patrolDistance;

        // Clamp and flip
        if (transform.position.x > rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
            direction = -1;
        }
        else if (transform.position.x < leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
            direction = 1;
        }
        // // Check if moved too far from start
        // float distanceFromStart = Vector3.Distance(startPosition, transform.position);

        // if (distanceFromStart > patrolDistance)
        // {
        //     direction *= -1; // Reverse direction
        // }
    }
}
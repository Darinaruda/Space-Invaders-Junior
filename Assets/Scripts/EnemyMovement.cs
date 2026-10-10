using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // These variables can be changed in the Unity Editor
    public float speed = 2f;
    public float moveDownDistance = 0.5f;
    public float leftEdge = -8f;
    public float rightEdge = 8f;
    
    private bool movingRight = true;

    // Update is called once per frame
    void Update()
    {
        if (movingRight)
        {
            // Move to the right
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            
            // Check if we hit the right edge
            if (transform.position.x >= rightEdge)
            {
                MoveDownAndReverse();
            }
        }
        else
        {
            // Move to the left
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            
            // Check if we hit the left edge
            if (transform.position.x <= leftEdge)
            {
                MoveDownAndReverse();
            }
        }
    }

    // This function moves the enemy down and flips its direction
    void MoveDownAndReverse()
    {
        movingRight = !movingRight; // Flip direction
        
        // Move down by 'moveDownDistance'
        Vector3 newPos = transform.position;
        newPos.y -= moveDownDistance;
        transform.position = newPos;
    }
}

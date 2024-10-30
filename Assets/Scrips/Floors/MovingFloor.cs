using UnityEngine;

public enum Directions
{
    Up,
    Down,
    Left,
    Right,
    Front,
    Back
}

public class MovingFloor : MonoBehaviour
{
    private Vector3 initialPos; 
    private Transform curPos;  
    private bool movingForward = true; 

    public float speed; 
    public float distance; 
    public Directions dir; 

    void Start()
    {
        initialPos = transform.position; 
        curPos = transform;
    }

    void Update()
    {
        MoveFloor();
    }

    void MoveFloor()
    {
        Vector3 targetPosition = initialPos;

        switch (dir)
        {
            case Directions.Left:
                targetPosition.x -= distance;
                break;
            case Directions.Right:
                targetPosition.x += distance;
                break;
            case Directions.Front:
                targetPosition.z += distance;
                break;
            case Directions.Back:
                targetPosition.z -= distance;
                break;
            case Directions.Up:
                targetPosition.y += distance;
                break;
            case Directions.Down:
                targetPosition.y -= distance;
                break;
        }

        if (movingForward)
        {
            curPos.position = Vector3.MoveTowards(curPos.position, targetPosition, speed * Time.deltaTime);
            if (Vector3.Distance(curPos.position, targetPosition) < 0.01f)
                movingForward = false; 
        }
        else
        {
            curPos.position = Vector3.MoveTowards(curPos.position, initialPos, speed * Time.deltaTime);
            if (Vector3.Distance(curPos.position, initialPos) < 0.01f)
                movingForward = true; 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.parent = curPos;
    }
    private void OnCollisionExit(Collision collision)
    {
        collision.transform.parent = null;
    }

}
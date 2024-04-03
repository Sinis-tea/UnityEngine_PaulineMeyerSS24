using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum MovementType { UpDown, LeftRight, Custom }

    public MovementType movementType;
    public float distance = 5f;
    public float speed = 2f;
    public Transform pointA;
    public Transform pointB;
    public float drawWireSphereRadius = 0.2f;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingForward = true;

    void Start()
    {
        startPos = transform.position;
        CalculateTargetPosition();
    }

    void FixedUpdate()
    {
        MovePlatform();
    }

    void MovePlatform()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

        if (transform.position == targetPos)
        {
            if (movementType == MovementType.Custom)
                CalculateTargetPosition();
            else
                UpdateTargetPosition();
        }
    }

    void UpdateTargetPosition()
    {
        if (movementType == MovementType.UpDown)
        {
            if (transform.position.y == startPos.y)
                movingForward = true;
            else if (transform.position.y == startPos.y + distance)
                movingForward = false;

            targetPos = movingForward ? startPos + Vector3.up * distance : startPos;
        }
        else if (movementType == MovementType.LeftRight)
        {
            if (transform.position.x == startPos.x)
                movingForward = true;
            else if (transform.position.x == startPos.x + distance)
                movingForward = false;

            targetPos = movingForward ? startPos + Vector3.right * distance : startPos;
        }
    }

    void CalculateTargetPosition()
    {
        targetPos = (targetPos == pointA.position) ? pointB.position : pointA.position;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pointA.position, drawWireSphereRadius);
        Gizmos.DrawWireSphere(pointB.position, drawWireSphereRadius);
    }

    private void OnTriggerEnter(Collider other)
    {
            other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
            other.transform.SetParent(null);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Transform targetWaypoint;

    private void Start()
    {
        //targetWaypoint = WaypointManager.Instance.GetNextWaypoint(); // Implement WaypointManager to get waypoints
    }

    private void Update()
    {
        //MoveToWaypoint();
    }

/*    private void MoveToWaypoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            targetWaypoint = WaypointManager.Instance.GetNextWaypoint(); // Implement WaypointManager to get waypoints
        }
    }*/
}
using UnityEngine;

public class MB_ObjectMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private SO_AbstractMovement _movementStrategy;

    private int _currentWaypointIndex = 0;

    private void FixedUpdate()
    {
        _movementStrategy.UpdatePosition(_waypoints[_currentWaypointIndex].position, transform);

        if (Vector3.Distance(transform.position, _waypoints[_currentWaypointIndex].position) < 0.1f)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
        }
    }
}
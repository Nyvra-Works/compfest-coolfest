using UnityEngine;

public class MB_ObjectMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private SO_AbstractMovement _movementStrategy;

    private int _currentWaypointIndex = 0;
    [SerializeField] bool startPaused = true;
    bool isPaused = false;
    void OnEnable()
    {
        isPaused = startPaused;
    }
    public void StartMovement()
    {
        isPaused = false;
    }
    public void StopMovement()
    {
        isPaused = true;
    }

    private void FixedUpdate()
    {
        if (isPaused)
        {
            return;
        }
        _movementStrategy.UpdatePosition(_waypoints[_currentWaypointIndex].position, transform);

        if (Vector3.Distance(transform.position, _waypoints[_currentWaypointIndex].position) < 0.1f)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
        }
    }
}
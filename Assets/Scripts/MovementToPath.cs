using UnityEngine;

public class MovementToPath : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Path _path;

    private int _nextWaypoint;
    private Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (_nextWaypoint >= _path.Waypoints.Count)
        {
            _speed = 0;
            return;
        }

        Vector2 nextWaypointPosition = _path.Waypoints[_nextWaypoint].position;
        Vector2 newPosition = Vector2.MoveTowards(transform.position, nextWaypointPosition, _speed * Time.fixedDeltaTime);
        _rb.MovePosition(newPosition);

        if (Vector2.Distance(transform.position, _path.Waypoints[_nextWaypoint].position) < 0.1f)
        {
            _nextWaypoint++;
        }
    }
}

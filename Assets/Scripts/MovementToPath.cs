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

        Vector2 direction = _path.Waypoints[_nextWaypoint].position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle = Mathf.LerpAngle(transform.eulerAngles.z, angle, Time.fixedDeltaTime * _speed);
        transform.eulerAngles = Vector3.forward * angle;

        Vector2 nextWaypointPosition = _path.Waypoints[_nextWaypoint].position;
        Vector2 newPosition = Vector2.MoveTowards(transform.position, nextWaypointPosition, _speed * Time.fixedDeltaTime);
        _rb.MovePosition(newPosition);

        if (Vector2.Distance(transform.position, _path.Waypoints[_nextWaypoint].position) < 0.1f)
        {
            _nextWaypoint++;
        }
    }
}

using System.Collections;
using UnityEngine;

public class TowerGun : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _detectionRadius;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Rocket _rocketPrefab;
    [SerializeField] private float _shootDelay;
    [SerializeField] private Transform _firePoint;

    private Enemy _targetEnemy;

    void Start()
    {
        StartCoroutine(ShootingCoroutine());
    }

    void Update()
    {
        if (_targetEnemy == null)
        {
            FindClosestEnemy();
        }
        else if (IsTargetEnemyInRange() == false)
        {
            _targetEnemy = null;
        }
        else if (_targetEnemy != null)
        {
            RotateTowardTarget();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }

    private void FindClosestEnemy()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _detectionRadius, _enemyLayer);

        float closestDistance = float.MaxValue;
        Enemy closestEnemy = null;

        foreach (Collider2D enemyCollider in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemyCollider.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemyCollider.GetComponent<Enemy>();
            }
        }

        if (closestEnemy != null)
        {
            _targetEnemy = closestEnemy;
        }
    }

    private bool IsTargetEnemyInRange()
    {
        float distance = Vector2.Distance(transform.position, _targetEnemy.transform.position);
        return distance <= _detectionRadius;
    }

    private void RotateTowardTarget()
    {
        Vector2 direction = _targetEnemy.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        angle = Mathf.LerpAngle(transform.eulerAngles.z, angle, Time.deltaTime * _rotateSpeed);
        transform.eulerAngles = Vector3.forward * angle;
    }

    private IEnumerator ShootingCoroutine()
    {
        while (true)
        {
            if (_targetEnemy == null)
            {
                yield return null;
            }
            else
            {
                Rocket newRocket = Instantiate(_rocketPrefab, _firePoint.position, transform.rotation);
                newRocket.SetTarget(_targetEnemy);
                yield return new WaitForSeconds(_shootDelay);
            }
        }
    }
}

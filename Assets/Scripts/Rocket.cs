using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _decalExplosionPrefab;

    private Rigidbody2D _rb;
    private Enemy _targetEnemy;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10);
    }

    void FixedUpdate()
    {
        if (_targetEnemy != null)
        {
            Vector2 direction = (_targetEnemy.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
            transform.eulerAngles = Vector3.forward * angle;

            _rb.velocity = direction * _speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            bool isKillingEnemy;
            isKillingEnemy = enemy.GetDamage(_damage);

            if (isKillingEnemy == true)
            {
                Instantiate(_decalExplosionPrefab, enemy.transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }
    }

    public void SetTarget(Enemy enemy)
    {
        _targetEnemy = enemy;
    }
}

using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public UnityEvent OnDieEvent = new();

    [SerializeField] private int _hp;
    [SerializeField] private MovementToPath _movementToPath;
    [SerializeField] private int _damage;

    public void Initialize(Path path)
    {
        _movementToPath.SetPath(path);
    }

    public bool GetDamage(int damage)
    {
        _hp -= damage;

        if (_hp <= 0)
        {
            OnDieEvent.Invoke();
            Destroy(gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out DefensiveBase defensiveBase))
        {
            defensiveBase.GetDamage(_damage);
        }
    }

}

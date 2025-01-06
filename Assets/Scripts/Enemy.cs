using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _hp;
    [SerializeField] private MovementToPath _movementToPath;

    public void Initialize(Path path)
    {
        _movementToPath.SetPath(path);
    }

    public bool GetDamage(int damage)
    {
        _hp -= damage;

        if (_hp <= 0)
        {
            Destroy(gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    public UnityEvent<int> OnEnemyDieEvent = new();

    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Path _path;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _maxEnemyCount;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private int _reward;

    private int _spawnedEnemyCount;
    private Coroutine _spawnerCoroutine;

    void Start()
    {
        StartSpawner();
    }

    [ContextMenu("Start Spawner")]
    public void StartSpawner()
    {
        _spawnerCoroutine = StartCoroutine(StartSpawnerCoroutine());
    }

    [ContextMenu("Stop Spawner")]
    public void StopSpawner()
    {
        StopCoroutine(_spawnerCoroutine);
    }

    private void SpawnEnemy()
    {
        Enemy newEnemy = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);
        newEnemy.Initialize(_path);
        newEnemy.OnDieEvent.AddListener(OnEnemyDie);
    }

    private IEnumerator StartSpawnerCoroutine()
    {
        while (_spawnedEnemyCount < _maxEnemyCount)
        {
            yield return new WaitForSeconds(_spawnDelay);
            SpawnEnemy();
            _spawnedEnemyCount++;
        }

        _spawnedEnemyCount = 0;
    }

    private void OnEnemyDie()
    {
        OnEnemyDieEvent.Invoke(_reward);
    }
}

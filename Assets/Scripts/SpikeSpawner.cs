using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    [SerializeField] private SpikeObjectPool _spikeUpPool;
    [SerializeField] private SpikeObjectPool _spikeDownPool;

    [SerializeField] private float _initialSpawnTime = 2f;
    [SerializeField] private float _spawnTimeDecreaseRate = 0.05f;
    [SerializeField] private float _minSpawnTime = 0.5f;
    private float _currentSpawnTime;

    [SerializeField] private float _initialSpikeSpeed = 5f;
    [SerializeField] private float _speedIncreaseRate = 0.1f; // Speed increase per second
    [SerializeField] private float _maxSpikeSpeed = 20f;
    private float _currentSpikeSpeed;

    private float _nextSpawnTime;
    
    private void Start()
    {
        _currentSpikeSpeed = _initialSpikeSpeed;
        _currentSpawnTime = _initialSpawnTime;
        _nextSpawnTime = Time.time + _initialSpawnTime;
    }

    private void Update()
    {
        // Gradually increase spike speed and decrease spawn time over time
        _currentSpikeSpeed += _speedIncreaseRate * Time.deltaTime;
        _currentSpikeSpeed = Mathf.Min(_maxSpikeSpeed, _currentSpikeSpeed); // Cap the speed to a maximum value

        _currentSpawnTime -= _spawnTimeDecreaseRate * Time.deltaTime;

        _currentSpawnTime = Mathf.Max(_minSpawnTime, _currentSpawnTime);

        if (Time.time >= _nextSpawnTime)
        {
            SpawnSpike();
            _nextSpawnTime = Time.time + _currentSpawnTime;
        }
    }


    private void SpawnSpike()
    {
        // Randomly choose between the two spike types
        GameObject spikeToSpawn;

        if (Random.Range(0, 6) < 3)
            spikeToSpawn = _spikeUpPool.GetPooledObject();
        else
            spikeToSpawn = _spikeDownPool.GetPooledObject();

        if (spikeToSpawn != null)
        {
            spikeToSpawn.transform.position = new Vector2(transform.position.x, spikeToSpawn.transform.position.y);

            if (spikeToSpawn.TryGetComponent<Spike>(out var spike))
            {
                spike.MoveSpeed = _currentSpikeSpeed;
            }

            spikeToSpawn.SetActive(true);
        }
    }
}

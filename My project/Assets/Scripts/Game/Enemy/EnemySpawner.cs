using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    private float _minimumSpawnTime = 6;
    private float _maximumSpawnTime = 8;
    private float _timeUntilSpawn;
    private float _timeToDecreaseSpawnTime = 60;
    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;
        _timeToDecreaseSpawnTime -= Time.deltaTime;

        if (_timeUntilSpawn <= 0)
        {
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }

        if (_timeToDecreaseSpawnTime <= 0)
        {
            SetTimeToDecreaseSpawnTime();
            decreaseSpawnTime();
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }

    private void SetTimeToDecreaseSpawnTime()
    {
        _timeToDecreaseSpawnTime = 60;
    }

    public void decreaseSpawnTime()
    {
        if (_minimumSpawnTime > 2)
        {
            _minimumSpawnTime -= 0.5f;
            _maximumSpawnTime -= 0.5f;
            //print(_minimumSpawnTime + " " + _maximumSpawnTime);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollectableDrop : MonoBehaviour
{
    [SerializeField]
    private float _dropChance;
    private CollectableSpawner _collectableSpawner;

    private void Awake()
    {
        _collectableSpawner = FindObjectOfType<CollectableSpawner>();
    }

    public void DropCollectable()
    {
        var randomValue = Random.Range(0f, 1f);
        if (randomValue <= _dropChance)
        {
            _collectableSpawner.SpawnCollectable(transform.position);
        }
    }
}

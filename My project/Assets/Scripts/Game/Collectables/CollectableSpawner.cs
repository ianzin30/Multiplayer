using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _collectablesPrefabs;

    public void SpawnCollectable(Vector2 position)
    {
        var index = Random.Range(0, _collectablesPrefabs.Count);
        var selectedCollectable = _collectablesPrefabs[index];

        Instantiate(selectedCollectable, position, Quaternion.identity);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public float minX, maxX, minY, maxY;

    void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            Vector3 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Not connected to Photon, unable to instantiate player.");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireUpCollectable : MonoBehaviour, ICollectableBehaviour
{
    [SerializeField]
    private float _fireUpAmount;

    [SerializeField]
    private float _fireUpDuration;
    public void OnCollected(GameObject player)
    {
        PlayerShoot playerShoot = player.GetComponent<PlayerShoot>();
        playerShoot.IncreaseFireRate(_fireUpAmount, _fireUpDuration);
    }
}

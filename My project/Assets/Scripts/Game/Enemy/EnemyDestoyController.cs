using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestoyController : MonoBehaviour
{
    public void DestroyEnemy(float delay)
    {
        Destroy(gameObject, delay);
    }
}

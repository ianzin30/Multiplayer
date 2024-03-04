using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerDamagedInvincibility : MonoBehaviour
{
    [SerializeField]
    private float _invincibilityDuration;
    [SerializeField]
    private Color _flashColor;
    [SerializeField]
    private int _numberOfFlashes;
    private InvicibilityController _invincibilityController;

    private void Awake()
    {
        _invincibilityController = GetComponent<InvicibilityController>();
    }

    public void StartInvincibility()
    {
        _invincibilityController.StartInvincibility(_invincibilityDuration, _flashColor, _numberOfFlashes);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvicibilityController : MonoBehaviour
{
    private HealthController _healthController;

    private void Awake() {
        _healthController = GetComponent<HealthController>();
    }

    public void StartInvincibility(float invicibilityDuration) {
        StartCoroutine(InvincibilityCoroutine(invicibilityDuration));
    }

    private IEnumerator InvincibilityCoroutine(float invicibilityDuration) {
        _healthController.IsInvincible = true;
        yield return new WaitForSeconds(invicibilityDuration);
        _healthController.IsInvincible = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvicibilityController : MonoBehaviour
{
    private HealthController _healthController;
    private SpriteFlash _spriteFlash;

    private void Awake()
    {
        _healthController = GetComponent<HealthController>();
        _spriteFlash = GetComponent<SpriteFlash>();
    }

    public void StartInvincibility(float invicibilityDuration, Color flashColor, int numberOfFlashes)
    {
        StartCoroutine(InvincibilityCoroutine(invicibilityDuration, flashColor, numberOfFlashes));
    }

    private IEnumerator InvincibilityCoroutine(float invicibilityDuration, Color flashColor, int numberOfFlashes)
    {
        _healthController.IsInvincible = true;
        //yield return new WaitForSeconds(invicibilityDuration);
        yield return _spriteFlash.FlashCoroutine(invicibilityDuration, flashColor, numberOfFlashes);
        _healthController.IsInvincible = false;
    }
}

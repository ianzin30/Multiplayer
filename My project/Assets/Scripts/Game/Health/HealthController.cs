using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _maximumHeath;
    public bool IsInvincible {get; set;}

    public float RemainingHealthPercentage {
        get {
            return _currentHealth / _maximumHeath;
        }
    }

    public void TakeDamage(float damageAmount) {
        if (_currentHealth == 0) {
            return;
        }

        if (!IsInvincible) {
            _currentHealth -= damageAmount;
            OnHealthCHange.Invoke();
            if (_currentHealth < 0) {
                _currentHealth = 0;
            }

            if (_currentHealth == 0) {
                OnDied.Invoke();
            } else {
                OnDamage.Invoke();
            }
        }
        
    }

    public void AddHealth(float amountToAdd) {
        if (_currentHealth == _maximumHeath) {
            return ;
        }

        _currentHealth += amountToAdd;
        OnHealthCHange.Invoke();
        
        if (_currentHealth > _maximumHeath) {
            _currentHealth = _maximumHeath;
        }
    }

    public UnityEvent OnDied;
    public UnityEvent OnDamage;
    public UnityEvent OnHealthCHange;
}

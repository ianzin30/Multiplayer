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
    public bool IsInvincible { get; set; }

    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maximumHeath;
        }
    }

    [SerializeField] private AudioSource _deathSoundEffect;
    [SerializeField] private AudioSource _damageSoundEffect;
    [SerializeField] private AudioSource _damageSoundEffect2;
    [SerializeField] private AudioSource _damageSoundEffect3;

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth == 0)
        {
            return;
        }

        if (!IsInvincible)
        {
            _currentHealth -= damageAmount;
            OnHealthCHange.Invoke();
            if (_currentHealth < 0)
            {
                _currentHealth = 0;
            }

            if (_currentHealth == 0)
            {
                _deathSoundEffect.Play();
                OnDied.Invoke();
            }
            else
            {
                OnDamage.Invoke();
                int randomNumber = UnityEngine.Random.Range(0, 3); // 0 is inclusive, 3 is exclusive
                switch (randomNumber)
                {
                    case 0:
                        _damageSoundEffect.Play();
                        break;
                    case 1:
                        _damageSoundEffect2.Play();
                        break;
                    case 2:
                        _damageSoundEffect3.Play();
                        break;
                }
            }
        }

    }

    public void AddHealth(float amountToAdd)
    {
        if (_currentHealth == _maximumHeath)
        {
            return;
        }

        _currentHealth += amountToAdd;
        OnHealthCHange.Invoke();

        if (_currentHealth > _maximumHeath)
        {
            _currentHealth = _maximumHeath;
        }
    }

    public UnityEvent OnDied;
    public UnityEvent OnDamage;
    public UnityEvent OnHealthCHange;

    public void AddKill()
    {
        Kills killCounter = GetComponent<Kills>() ?? FindObjectOfType<Kills>();
        if (killCounter != null)
        {
            killCounter.AddKill();
        }
    }

    public void DeathPause()
    {
        PauseController pauseController = FindObjectOfType<PauseController>();
        if (pauseController != null)
        {
            pauseController.Pausar();
        }
    }
}
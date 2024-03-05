using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _maximumHealth;
    public HealthBarUI healthBarUI; // Referência para a barra de vida UI

    public bool IsInvincible { get; set; }

    public float RemainingHealthPercentage => _currentHealth / _maximumHealth;

    [SerializeField] private AudioSource _deathSoundEffect;

    // Eventos para comunicar mudanças de estado
    public UnityEvent OnDied;
    public UnityEvent OnDamage;
    public UnityEvent OnHealthChange;

    private void Start()
    {
        // Certifique-se de que a saúde não comece com um valor inválido
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maximumHealth);

        // Atualiza a UI da barra de vida no início para refletir a saúde inicial
        if (healthBarUI != null)
        {
            healthBarUI.UpdateHealthBar(this);
        }

        // Chama o evento de mudança de saúde para atualizar qualquer outro ouvinte
        OnHealthChange?.Invoke();
    }

    [SerializeField] private AudioSource _damageSoundEffect;
    [SerializeField] private AudioSource _damageSoundEffect2;
    [SerializeField] private AudioSource _damageSoundEffect3;

    public void TakeDamage(float damageAmount)
    {
        if (_currentHealth <= 0) return;

        if (!IsInvincible)
        {
            _currentHealth = Mathf.Max(_currentHealth - damageAmount, 0);
            OnHealthChange?.Invoke();
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
        if (_currentHealth >= _maximumHealth) return;

        _currentHealth = Mathf.Min(_currentHealth + amountToAdd, _maximumHealth);
        OnHealthChange?.Invoke();

        if (_currentHealth > _maximumHealth)
        {
            _currentHealth = _maximumHealth;
        }
    }

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

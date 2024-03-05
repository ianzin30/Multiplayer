using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private Image _healthBarForegroundImage; // Referência à imagem da barra de vida
    [SerializeField]
    private float updateSpeedSeconds = 0.5f; // Velocidade da animação de atualização da barra de vida

    private Coroutine _healthBarCoroutine; // Variável para manter a referência à corrotina ativa

    // Corrotina para atualizar a barra de vida
    private IEnumerator ChangeToPct(float targetPct)
    {
        float preChangePct = _healthBarForegroundImage.fillAmount;
        float elapsed = 0f;

        while (elapsed < updateSpeedSeconds)
        {
            elapsed += Time.deltaTime;
            _healthBarForegroundImage.fillAmount = Mathf.Lerp(preChangePct, targetPct, elapsed / updateSpeedSeconds);
            yield return null;
        }

        _healthBarForegroundImage.fillAmount = targetPct;
    }

    public void UpdateHealthBar(HealthController healthController)
    {
        if (_healthBarCoroutine != null)
        {
            StopCoroutine(_healthBarCoroutine); // Interrompe a corrotina atual se ela estiver rodando
        }
        _healthBarCoroutine = StartCoroutine(ChangeToPct(healthController.RemainingHealthPercentage)); // Inicia uma nova corrotina
    }
}

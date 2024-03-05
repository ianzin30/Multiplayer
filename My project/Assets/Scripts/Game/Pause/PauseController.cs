using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private GameObject _pausePanel;
    
    // Variável para controlar o estado de pausa do jogo
    private bool isPaused = false;

    void Update()
    {
        // Verifica se a tecla ESC foi pressionada
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
        }
    }
    
    public void Pausar(){
        _pausePanel.SetActive(true);
        Time.timeScale = 0; // Pausa o jogo
        isPaused = true;
    }

    public void Continuar(){
        _pausePanel.SetActive(false);
        Time.timeScale = 1; // Continua o jogo
        isPaused = false;
    }

    public void Sair(){
        Time.timeScale = 1; // Garante que o timeScale é resetado
        SceneManager.LoadScene(_sceneName);
    }
}

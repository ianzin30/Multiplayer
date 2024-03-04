using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private GameObject _pausePanel;

    void Update()
    {
        // Verifica se a tecla ESC foi pressionada
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausar();
        }
    }
    
    public void Pausar(){
        _pausePanel.SetActive(true);
    }

    public void Continuar(){
        _pausePanel.SetActive(false);
    }

    public void Sair(){
        SceneManager.LoadScene(_sceneName);
    }
}

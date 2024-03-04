using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    private int minutes;
    private int seconds;
    private bool isRunning = true; 

    void Start()
    {
        HealthController playerHealth = GetComponent<HealthController>() ?? FindObjectOfType<HealthController>(); 
        if (playerHealth != null)
        {
            playerHealth.OnDied.AddListener(StopTimer);
        }
    }

    void Update()
    {
        if (isRunning) 
        {
            elapsedTime += Time.deltaTime;
            minutes = Mathf.FloorToInt(elapsedTime / 60);
            seconds = Mathf.FloorToInt(elapsedTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    private void StopTimer()
    {
        isRunning = false; 
    }
}

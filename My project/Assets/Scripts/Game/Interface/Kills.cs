using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Kills : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI killsText;
    public int kills = 0;
    public void AddKill()
    {
        kills++;
        killsText.text = kills.ToString();
    }
}

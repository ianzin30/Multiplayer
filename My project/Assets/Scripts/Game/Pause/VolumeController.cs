using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioSource musica;

    public void SetVolume(float volume){
        musica.volume = volume;
    }
}

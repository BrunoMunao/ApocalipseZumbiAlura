using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaAudio : MonoBehaviour
{
    // Variáveis 
    private AudioSource controlaAudio;
    public static AudioSource InstanciaAudio;

    private void Awake()
    {
        controlaAudio = GetComponent<AudioSource>();
        InstanciaAudio = controlaAudio;
    }
}

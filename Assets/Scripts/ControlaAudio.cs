using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaAudio : MonoBehaviour
{
    // Vari�veis 
    private AudioSource controlaAudio;
    public static AudioSource InstanciaAudio;

    private void Awake()
    {
        controlaAudio = GetComponent<AudioSource>();
        InstanciaAudio = controlaAudio;
    }
}

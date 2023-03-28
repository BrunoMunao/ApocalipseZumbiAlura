using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    // Variáveis
    public int Vida { get; set; }
    public float Velocidade { get; set; } = 10;
    public int VidaInicial { get; private set; } = 100;

    void Awake()
    {
        Vida = VidaInicial;
    }
}

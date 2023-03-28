using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{
    // Variáveis
    public GameObject Bala;
    public GameObject CanoDaArma;
    public AudioClip SomTiro;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bala, CanoDaArma.transform.position, CanoDaArma.transform.rotation);
            ControlaAudio.InstanciaAudio.PlayOneShot(SomTiro);
        }
    }
}

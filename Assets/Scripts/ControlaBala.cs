using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaBala : MonoBehaviour
{
    // Variáveis
    public float velocidadeBala = 20;
    private Rigidbody rbBala;
    public AudioClip ZumbiMorto;
    private int danoBala = 1;

    void Start()
    {
        rbBala = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rbBala.MovePosition(rbBala.position + transform.forward * velocidadeBala * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider objetoDeColisao)
    {
        if (objetoDeColisao.gameObject.tag == Tags.Inimigo)
        {
            objetoDeColisao.GetComponent<ControlaZumbi>().TomarDano(danoBala);
            ControlaAudio.InstanciaAudio.PlayOneShot(ZumbiMorto);
        }
        Destroy(gameObject);
    }
}

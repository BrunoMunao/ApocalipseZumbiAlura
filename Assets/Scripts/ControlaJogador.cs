using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour, IMatavel
{
    // Váriaveis 
    private Vector3 direcao;
    public LayerMask MascaraChao;
    public GameObject TextoGameOver;
    public ControlaInterface ScriptControlaInterface;
    public AudioClip DanoJogador;
    public Status status;

    // Scripts de Personagem
    private MovimentaPersonagem movimentacao;
    private AnimacaoPersonagem animacao;


    void Start()
    {
        movimentacao = GetComponent<MovimentaPersonagem>();
        animacao = GetComponent<AnimacaoPersonagem>();
        status = GetComponent<Status>();
    }

    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);

        animacao.Mover(direcao.magnitude);

    }

    void FixedUpdate()
    {
        movimentacao.Movimentar(direcao, status.Velocidade);
        RotacionarJogador();
    }

    public void TomarDano(int dano)
    {
        status.Vida -= dano;
        ScriptControlaInterface.AtualizarSliderVidaJogador();
        ControlaAudio.InstanciaAudio.PlayOneShot(DanoJogador);
        if (status.Vida <= 0)
        {
            Morrer();
        }
    }

    public void Morrer()
    {
        ScriptControlaInterface.GameOver();
    }

    private void RotacionarJogador()
    {
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit impacto;

        if (Physics.Raycast(raio, out impacto, 100, MascaraChao))
        {

            Vector3 posicaoMiraJogador = impacto.point - transform.position;
            posicaoMiraJogador.y = transform.position.y;

            movimentacao.Rotacionar(posicaoMiraJogador);

        }
    }
}

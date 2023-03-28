using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaZumbi : MonoBehaviour, IMatavel
{
    // Vari�veis
    public GameObject Jogador;
    public float velocidadeZumbi = 3;
    private Vector3 direcao;
    private float tempoVagar;
    private float tempoVagarFim = 4.0f;
    private Vector3 posAleatoria;

    // Scripts de Personagem
    private MovimentaPersonagem movimentacao;
    private AnimacaoPersonagem animacao;
    private Status status;


    void Start()
    {
        Jogador = GameObject.FindWithTag(Tags.Jogador);
        EscolheSkin();
        movimentacao = GetComponent<MovimentaPersonagem>();
        animacao = GetComponent<AnimacaoPersonagem>();
        status = GetComponent<Status>();
        status.Vida = 1;
    }

    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

        movimentacao.Rotacionar(direcao);
        animacao.Mover(direcao.magnitude);


        if (distancia > 15)
        {
            Vagar();
        }
        else if (distancia > 2.5)
        {
            direcao = Jogador.transform.position - transform.position;
            movimentacao.Movimentar(direcao, velocidadeZumbi);
            animacao.Atacar(false);
        }
        else
        {
            direcao = Jogador.transform.position - transform.position;
            animacao.Atacar(true);
        }
    }
    void AtacaJogador()
    {
        int danoZumbi = Random.Range(20, 30);
        Jogador.GetComponent<ControlaJogador>().TomarDano(danoZumbi);
    }

    void EscolheSkin()
    {
        int skin = Random.Range(1, 28);
        transform.GetChild(skin).gameObject.SetActive(true);
    }

    public void TomarDano(int _dano)
    {
        status.Vida -= _dano;
        if (status.Vida <= 0)
        {
            Morrer();
        }
    }

    public void Morrer()
    {
        Destroy(gameObject);
    }

    private void Vagar()
    {

        tempoVagar -= Time.deltaTime;
        if (tempoVagar <= 0)
        {
            posAleatoria = RandomPos();
            tempoVagar += tempoVagarFim;
        }

        bool ficouPertin = Vector3.Distance(transform.position, posAleatoria) <= 0.05;
        if (ficouPertin == false)
        {
            direcao = posAleatoria - transform.position;
            movimentacao.Movimentar(direcao, velocidadeZumbi);
        }
    }

    private Vector3 RandomPos()
    {
        Vector3 posicao = Random.insideUnitSphere * 10;
        posicao += transform.position;
        posicao.y = transform.position.y;

        return posicao;
    }
}

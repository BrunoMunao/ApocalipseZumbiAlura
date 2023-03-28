using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentaPersonagem : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Movimentar(Vector3 direcao, float velocidade)
    {
        _rigidbody.MovePosition((_rigidbody.position) + (Time.deltaTime * direcao.normalized * velocidade));
    }

    public void Rotacionar(Vector3 direcao)
    {
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        _rigidbody.MoveRotation(novaRotacao);
    }
}

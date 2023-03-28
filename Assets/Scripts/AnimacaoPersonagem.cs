using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoPersonagem : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Atacar(bool status)
    {
        _animator.SetBool("Atacando", status);
    }
 
    public void Mover(float movimento)
    {
        _animator.SetFloat("Movendo", movimento);
    }

}

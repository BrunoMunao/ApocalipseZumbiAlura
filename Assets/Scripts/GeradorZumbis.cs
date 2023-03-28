using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbis : MonoBehaviour
{
    public GameObject Zumbi;
    private float contadorTempo = 0;
    public float TempoGerarZumbi = 1;
    public LayerMask LayerZumbi;

    void Update()
    {
        contadorTempo += Time.deltaTime;

        if (contadorTempo >= TempoGerarZumbi)
        {
            StartCoroutine(GerarNovoZumbi());
            contadorTempo = 0;

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 3);
    }

    private IEnumerator GerarNovoZumbi()
    {
        Collider[] colisores = Physics.OverlapSphere(RandomPos(), 1, LayerZumbi);

        while (colisores.Length > 0)
        {
            colisores = Physics.OverlapSphere(RandomPos(), 1, LayerZumbi);
            yield return null;
        }

        Instantiate(Zumbi, RandomPos(), transform.rotation);
    }

    private Vector3 RandomPos()
    {
        Vector3 posicao = Random.insideUnitSphere * 3;
        posicao += transform.position;
        posicao.y = 0;

        return posicao;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaInterface : MonoBehaviour
{
    // Variáveis
    private ControlaJogador scriptJogador;
    public Slider SliderVidaJogador;
    public GameObject GameOverText;
    public Text TempoDeSobrevivencia;
    public Text TempoMaxSobrevivencia;
    private float tempoPontuacaoSalvo;


    void Start()
    {
        scriptJogador = GameObject.FindWithTag("Player").GetComponent<ControlaJogador>();
        SliderVidaJogador.maxValue = scriptJogador.status.Vida;
        AtualizarSliderVidaJogador();
        Time.timeScale = 1;
        tempoPontuacaoSalvo = PlayerPrefs.GetFloat("BestScore");
    }

    public void AtualizarSliderVidaJogador()
    {
        SliderVidaJogador.value = scriptJogador.status.Vida;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverText.SetActive(true);

        int minutos = (int) (Time.timeSinceLevelLoad / 60);
        int segundos = (int)(Time.timeSinceLevelLoad % 60);

        AtualizaScore(minutos, segundos);

        TempoDeSobrevivencia.text = $"Game over! \n Você sobreviveu {minutos}min {segundos}s.";
    }

    private void AtualizaScore(int min, int seg)
    {
        if(Time.timeSinceLevelLoad > tempoPontuacaoSalvo)
        {
            PlayerPrefs.SetFloat("BestScore", Time.timeSinceLevelLoad);
            tempoPontuacaoSalvo = PlayerPrefs.GetFloat("BestScore");
            TempoMaxSobrevivencia.text = $"Seu recorde é {min}min {seg}s.";
        }
        if (TempoMaxSobrevivencia.text == "")
        {
            min = (int)tempoPontuacaoSalvo / 60;
            seg = (int)tempoPontuacaoSalvo % 60;
            TempoMaxSobrevivencia.text = string.Format("Seu melhor tempo é {0}min e {1}s", min, seg);
        }
        else
        {
            int minutos = (int)(tempoPontuacaoSalvo / 60);
            int segundos = (int)(tempoPontuacaoSalvo % 60);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}

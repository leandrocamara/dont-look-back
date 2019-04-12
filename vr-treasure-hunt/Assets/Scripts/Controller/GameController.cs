using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Classe responsável por controlar as ações gerais do Jogo.
 */
public class GameController : MonoBehaviour
{
    /**
     * Redireciona o Jogador para a tela de GameOver.
     */
    public static void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    /**
     * Reinicia o jogo.
     */
    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }

    /**
     * Redireciona o Jogador para a tela de Congratulations.
     */
    public void Congratulations()
    {
        StartCoroutine(changeSceneCongratulations());
    }

    /**
     * Redireciona o Jogador para a tela de Congratulations após 3 segundos.
     */
    private IEnumerator changeSceneCongratulations()
    {
        yield return new WaitForSeconds (2.5f);
        SceneManager.LoadScene("Congratulations");
    }
}

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
     * Reinicia o jogo após o Monstro alcançar o Jogador.
     */
    public static void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

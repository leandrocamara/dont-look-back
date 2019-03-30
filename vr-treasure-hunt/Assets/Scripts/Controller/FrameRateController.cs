using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Classe responsável por controlar as ações gerais do Jogo.
 */
public class FrameRateController : MonoBehaviour
{
    /**
     * Método Start.
     */
    private void Start()
    {
        // Define o FrameRate do Jogo em "60" no dispositivo.
        Application.targetFrameRate = 60;
    }
}

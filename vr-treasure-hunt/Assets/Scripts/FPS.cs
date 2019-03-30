using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Classe responsável pela apresentação do FrameRate na câmera do Jogador.
 */
public class FPS : MonoBehaviour
{
    private Text fps;
    private float deltaTime = 0.0f;

    /**
     * Método Start.
     */
    private void Start()
    {
        fps = GetComponent<Text>();
    }

    /**
     * Método Update.
     */
    private void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        fps.text = "FPS: " + (int) (1.0f / deltaTime);
    }
}

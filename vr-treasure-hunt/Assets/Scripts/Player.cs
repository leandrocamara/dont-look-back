using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Classe responsável pelas características e ações do Jogador.
 */
public class Player : MonoBehaviour
{
    private AudioSource audioSource;

    /**
     * Ativa o áudio do Jogador "andando".
     */
    public void ActiveAudioWalkingPlayer()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    /**
     * Interrompe o áudio do Jogador "andando".
     */
    public void StopAudioWalkingPlayer()
    {
        audioSource.Stop();
    }

    /**
     * Método Start.
     */
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
}

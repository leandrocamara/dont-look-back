using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Classe responsável pelas características e ações do Monstro.
 */
public class Monster : MonoBehaviour
{
    public GameObject player;
    public AudioSource audioMonster;
    public bool chasePlayer = false;
    public float speedMovement = 0.5f;
    public float heightAbovePlayer = -0.8f;

    private Vector3 lastPosPlayer;

    /**
     * Aciona o ataque do Monstro ao Jogador.
     */
    public void AttackPlayer()
    {
        chasePlayer = true;
    }

    /**
     * Reproduz o som do Monstro.
     */
    public void PlayAudioMonster()
    {
        audioMonster.Play();
    }

    /**
     * Método FixedUpdate.
     */
    private void FixedUpdate()
    {
        // Caso o Monstro tenha que perseguir o Jogador e o mesmo tenha se movimentado.
        if (chasePlayer && lastPosPlayer != player.transform.position)
        {
            MoveMonster();
            LookAtPlayer();
        }
    }

    /**
     * Rotaciona o Monster em direção ao Player.
     */
    private void LookAtPlayer()
    {
        transform.LookAt(player.transform);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 90f, 0);
    }

    /**
     * Posiciona o Monster até à posição do Player.
     */
    private void MoveMonster()
    {
        UpdateLastPosPlayer();

        iTween.MoveTo(gameObject,
            iTween.Hash(
                "position", GetNewPositionToMonster(),
                "speed", speedMovement,
                "easetype", "linear"
            )
        );
    }

    /**
     * Evento acionado quando um objeto (collider) entrar em contato com o Monstro.
     */
    private void OnTriggerEnter (Collider other)
    {
        GameController.GameOver();
    }

    /**
     * Retorna a nova posição do Monstro, baseado na posição do Jogador.
     */
    private Vector3 GetNewPositionToMonster()
    {
        return new Vector3(
            lastPosPlayer.x,
            lastPosPlayer.y + heightAbovePlayer,
            lastPosPlayer.z
        );
    }

    /**
     * Atualiza a variável responsável por armazenar a última posição do Jogador.
     */
    private void UpdateLastPosPlayer()
    {
        lastPosPlayer = player.transform.position;
    }
}

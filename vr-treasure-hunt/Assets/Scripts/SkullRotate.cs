using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Classe responsável pela Rotação da Caveira.
 */
public class SkullRotate : MonoBehaviour
{
    public GameObject player;

    /**
     * Método Update.
     */
    private void Update()
    {
        RotateSkullToPlayer();
    }

    /**
     * Rotaciona a Caveira em direção ao Jogador.
     */
    private void RotateSkullToPlayer()
    {
        transform.LookAt(player.transform);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 90f, 0);
    }
}

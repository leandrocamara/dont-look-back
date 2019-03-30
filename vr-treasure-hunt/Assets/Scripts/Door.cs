using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Classe responsável pelas características e ações da Porta.
 */
public class Door : MonoBehaviour
{
    public bool openStart;

    private Animator animator;

    /**
     * Ativa a animação responsável por abrir a Porta.
     */
    public void OpenDoor()
    {
        animator.SetTrigger("Open");
    }

    /**
     * Ativa a animação responsável por fechar a Porta.
     */
    public void CloseDoor()
    {
        animator.SetTrigger("Close");
    }

    /**
     * Método Start.
     */
    private void Start()
    {
        animator = GetComponent<Animator>();

        // Caso o "openStart" esteja ativo.
        if (openStart) {
            animator.SetTrigger("Open");
        }
    }
}

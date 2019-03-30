using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Classe responsável pelas características e ações do Baú.
 */
public class Chest : MonoBehaviour
{
    public MonsterController monsterController;

    private Animator anim;

    /**
     * Método responsável por abrir o Baú.
     */
    public void OpenChest()
    {
        anim.SetTrigger("Open");
        monsterController.ChasePlayer();
    }

    /**
     * Método Start.
     */
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
}

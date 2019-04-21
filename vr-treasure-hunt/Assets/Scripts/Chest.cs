using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Classe responsável pelas características e ações do Baú.
 */
public class Chest : MonoBehaviour
{
    public MonsterController monsterController;

    public GameObject[] gold;

    public bool opened = false;

    private Animator anim;

    /**
     * Método responsável por abrir o Baú.
     */
    public void OpenChest()
    {
        anim.SetTrigger("Open");
        SetActiveGoldCollider(true);
        GetComponent<BoxCollider>().enabled = false;
    }

    /**
     * Ativa o Monstro após o Tesouro ser pego pelo Jogador.
     */
    public void TakeTreasure()
    {
        InactiveGold();
        if (monsterController)
        {
            monsterController.ActiveMonster();
            monsterController.takedTreasure = true;
        }
    }

    /**
     * Método Start.
     */
    private void Start()
    {
        SetActiveGoldCollider(false);
        anim = GetComponentInChildren<Animator>();
        if (opened)
        {
            OpenChest();
        }
    }

    /**
     * Ativa/inativa o "Collider" do Ouro do baú do Tesouro.
     */
    private void SetActiveGoldCollider(bool active)
    {
        foreach (var item in gold)
        {
            item.GetComponent<MeshCollider>().enabled = active;
        }
    }

    /**
     * Inativa o Ouro do baú do Tesouro.
     */
    private void InactiveGold()
    {
        foreach (var item in gold)
        {
            item.SetActive(false);
        }
    }
}

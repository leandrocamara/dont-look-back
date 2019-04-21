using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Classe responsável por controlar o Monstro.
 */
public class MonsterController : MonoBehaviour
{
    public Monster monster;
    public Door[] doorsToOpen;
    public Door[] doorsToClose;
    public GameObject monsterStatic;
    public bool takedTreasure = false;
    public AudioSource audioMonsterStatic;
    public WaypointController waypointController;

    /**
     * Ativa o Monstro (estático) da sala da Chave.
     */
    public void ActiveMonsterStatic()
    {
        audioMonsterStatic.Play();
        monsterStatic.SetActive(true);
    }

    /**
     * Ativa o Monstro da sala do Tesouro.
     */
    public void ActiveMonster()
    {
        monster.gameObject.SetActive(true);
        monster.PlayAudioMonster();
    }

    /**
     * Ativa a ação do Monstro de perseguição ao Jogador.
     */
    public void ChasePlayer()
    {
        if (!monster.chasePlayer && takedTreasure)
        {
            monster.AttackPlayer();
            OpenDoorsExitRoomChest();
            CloseDoorsEnterRoomChest();
            waypointController.ActiveWaypointExit();
        }
    }

    /**
     * Método Start.
     */
    private void Start()
    {
        monsterStatic.SetActive(false);
        monster.gameObject.SetActive(false);
    }

    /**
     * Abre as portas que permitem o Jogador sair da sala do Tesouro.
     */
    private void OpenDoorsExitRoomChest()
    {
        foreach (var door in doorsToOpen)
        {
            door.OpenDoor();
        }
    }

    /**
     * Fecha as portas que permitem o Jogador entrar da sala do Tesouro.
     */
    private void CloseDoorsEnterRoomChest()
    {
        foreach (var door in doorsToClose)
        {
            door.CloseDoor();
        }
    }
}

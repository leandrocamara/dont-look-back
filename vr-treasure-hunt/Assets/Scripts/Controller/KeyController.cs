using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Classe responsável por controlar a Chave.
 */
public class KeyController : MonoBehaviour
{
    public GameObject key;
    public Door treasureEnterDoor;
    public bool playerHasKey = false;
    public MonsterController monsterController;

    /**
     * Abre a porta da sala do Tesouro e ativa o Monstro (estático).
     */
    public void PlayerFoundKey()
    {
        playerHasKey = true;
        key.SetActive(false);
        treasureEnterDoor.OpenDoor();
        monsterController.ActiveMonsterStatic();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    public GameObject key;
    public bool playerHasKey = false;
    public Door treasureEnterDoor;
    public MonsterController monsterController;

    public void PlayerFoundKey()
    {
        playerHasKey = true;
        key.SetActive(false);
        treasureEnterDoor.OpenDoor();
        monsterController.ActiveMonsterStatic();
    }
}

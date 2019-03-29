using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public GameObject monsterStatic;
    public GameObject monsterAlive;
    public AudioSource audioMonsterStatic;
    public AudioSource audioMonsterAlive;
    public Door[] doorsToClose;
    public Door[] doorsToOpen;

    private void Start()
    {
        monsterAlive.SetActive(false);
        monsterStatic.SetActive(false);
    }

    public void ActiveMonsterStatic()
    {
        audioMonsterStatic.Play();
        monsterStatic.SetActive(true);
    }

    public void ChasePlayer()
    {
        audioMonsterAlive.Play();
        monsterAlive.SetActive(true);

        OpenDoorsExitRoomChest();
        CloseDoorsExitRoomChest();
    }

    private void OpenDoorsExitRoomChest()
    {
        foreach (var door in doorsToOpen)
        {
            door.OpenDoor();
        }
    }

    private void CloseDoorsExitRoomChest()
    {
        foreach (var door in doorsToClose)
        {
            door.CloseDoor();
        }
    }
}

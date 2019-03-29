using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator anim;
    public MonsterController monsterController;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void OpenChest()
    {
        anim.SetTrigger("Open");
    }

    public void TakeGoldChest()
    {
        monsterController.ChasePlayer();
    }
}

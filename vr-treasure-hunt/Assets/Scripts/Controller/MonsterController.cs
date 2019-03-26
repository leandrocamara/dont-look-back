using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public GameObject monsterStatic;
    public AudioSource audioMonsterStatic;

    private void Start()
    {
        monsterStatic.SetActive(false);
    }

    public void ActiveMonsterStatic()
    {
        audioMonsterStatic.Play();
        monsterStatic.SetActive(true);
    }
}

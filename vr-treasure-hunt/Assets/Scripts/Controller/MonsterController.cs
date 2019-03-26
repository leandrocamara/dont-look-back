using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public GameObject monsterStatic;

    private void Start()
    {
        monsterStatic.SetActive(false);
    }

    public void ActiveMonsterStatic()
    {
        monsterStatic.SetActive(true);
    }
}

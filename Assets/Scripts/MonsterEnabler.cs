using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEnabler : MonoBehaviour
{
    public GameObject[] monsters;
    int monsterIterator = 0;

    public void EnableMonster()
    {
        if (monsterIterator < monsters.Length)
        monsters[monsterIterator].SetActive(true);
        monsterIterator++;
    }
}

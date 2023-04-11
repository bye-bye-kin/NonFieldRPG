using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int hp;
    public int at;
    public GameObject testprefab;

    //攻撃する
    public int Attack(EnemyManager enemy)
    {
        Instantiate(testprefab);
        int damage = enemy.Damage(at);
        return damage;
    }

    //ダメージを受ける
    public int Damage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
        }
        return damage;
    }


}

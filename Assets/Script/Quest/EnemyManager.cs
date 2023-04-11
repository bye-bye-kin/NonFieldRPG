using System;
using UnityEngine;
using DG.Tweening;

public class EnemyManager : MonoBehaviour
{

    //関数登録
    Action tapAction; //クリックされた時に実行したい関数（外部から設定したい）

    public new string name;
    public int hp;
    public int at;


    //攻撃する
    public int Attack(PlayerManager player)
    {
        int damage = player.Damage(at);
        return damage;
    }

    //ダメージを受ける
    public int Damage(int damage)
    {
        transform.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
        }
        return damage;
    }

    //tapActionに関数を登録する関数を作る
    public void AddEventListenerOnTap(Action action)
    {
        tapAction += action;

    }

    public void OnTap()
    {
        Debug.Log("クリックされた");
        tapAction();
    }
}

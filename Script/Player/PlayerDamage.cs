using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Playerのダメージを管理するクラス
/// </summary>
public class PlayerDamage : MonoBehaviour
{
    //当たり判定を出して敵ならダメージを与える。
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Damage(damage:1);
        }
    }

    //ダメージ処理
    public void Damage(int damage)
    {
        PlayerProvider.i.PlayerStatus.decreaseHp(damage);
        PlayerProvider.i.PlayerDead.CheckDead();
        PlayerProvider.i.PlayerAnimation.DamageAnimation();
        HpEffect.i.HpWatch();
    }
}

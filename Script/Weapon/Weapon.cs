using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//攻撃する武器の当たり判定処理
public class Weapon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var eDamage = other.GetComponent<EnemyDamage>();
            if (eDamage)
            {
                Vector3 attackDirection = other.transform.position - gameObject.transform.position;
                eDamage.Damage(new AttackInfo(PlayerProvider.i.PlayerStatus.Attack, attackDirection));
            }
        }
    }
}

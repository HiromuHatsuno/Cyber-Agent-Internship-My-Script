using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//スペシャル攻撃の当たり判定として利用するクラス
public class SpecialWeapon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var eDamage = other.GetComponent<EnemyDamage>();
            if (eDamage)
            {
                Vector3 attackDirection = other.transform.position - gameObject.transform.position;
                eDamage.Damage(new AttackInfo(PlayerProvider.i.PlayerStatus.SpecialAttack, attackDirection));
            }
        }
    }
}

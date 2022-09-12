using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Playerの攻撃を管理するクラス
/// </summary>
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackDelay;
    [SerializeField] private float attackEndDelay;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] int attackID;
	//攻撃処理
    public void Attack()
    {
        var attack = AttackGenerater.instance?.GetAttack(attackID);
        if (attack.IsActive) return;
        PlayerProvider.i.PlayerAnimation.AttackAnimation();
        attack?.Activate(PlayerProvider.i.transform.position, PlayerProvider.i.PlayerLookMouse.direction);
        if (attack == null) Debug.LogError("PlayerAttack is null");
    }
	//攻撃当たり判定を出力する処理
    public void OnEnableAttackCollision()
    {
        boxCollider2D.enabled = true;
        PlayerProvider.i.PlayerEffect.PlayAttackEffect();
        
    }
	//攻撃当たり判定を隠す処理
    public void DisEnableAttackCollision()
    {
        boxCollider2D.enabled = false;
    }
}

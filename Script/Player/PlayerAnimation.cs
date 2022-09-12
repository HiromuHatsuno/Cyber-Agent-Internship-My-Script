using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーのアニメーションを管理するクラス
/// </summary>
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    private static readonly int Attack = Animator.StringToHash("attack");
    private static readonly int Damaged = Animator.StringToHash("damaged");
    private static readonly int Pray = Animator.StringToHash("pray");
    
    //移動アニメーション
    public void MoveAnimation()
    {
        animator.SetBool(IsMoving,true);
    }
    //停止アニメーション
    public void StopMoveAnimation()
    {
        animator.SetBool(IsMoving,false);
    }
    //攻撃アニメーション
    public void AttackAnimation()
    {
        animator.SetTrigger(Attack);
    }
    //ダメージアニメーション
    public void DamageAnimation()
    {
        animator.SetBool(Damaged,true);
        Invoke(nameof(StopDamageAnimation),1);
    }
    //ダメージアニメーションの停止
    public void StopDamageAnimation()
    {
        animator.SetBool(Damaged,false);
    }
    //祈りのアニメーション
    public void PrayAnimation()
    {
        animator.SetBool(Pray,true);
    }
    //死亡アニメーション
    public void PlayDead()
    {
        animator.SetBool("isDead",true);
    }
    //祈り停止アニメーション
    public void StopPrayAnimation()
    {
        animator.SetBool(Pray,false);
    }
}

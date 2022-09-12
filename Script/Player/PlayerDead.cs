using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
/// <summary>
///　プレイヤーの死亡を管理するクラス
/// </summary>
public class PlayerDead : MonoBehaviour
{
   [SerializeField] public BloomChange _bloomChange;
   public bool isDead;
    Subject<Unit> onDeadSubject = new Subject<Unit>();
    public System.IObservable<Unit> OnDead => onDeadSubject;
    //死亡判定
   public void CheckDead()
   {
      if (PlayerProvider.i.PlayerStatus.Hp<=0)
      {
         isDead = true;
         Dead();
      }
      else
      {
         //生存処理
      }
   }

   //死亡処理
   public void Dead()
   {
      _bloomChange.isChange = true;
         
      PlayerProvider.i.PlayerAnimation.PlayDead();
        PlayerProvider.i.Rigidbody2D.velocity = Vector2.zero;
      
      onDeadSubject.OnNext(Unit.Default);
        GameLoopManager.instance.OnDead();
        Invoke(nameof(DeadEffect),3);
        Destroy(this.gameObject,1);
   }

   //死亡エフェクト
   public void DeadEffect()
   {
      _bloomChange.ChangeBloom();
   }
}

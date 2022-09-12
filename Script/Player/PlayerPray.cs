using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーの祈り処理クラス
public class PlayerPray : MonoBehaviour
{
   [SerializeField]private float currentTime;
   [SerializeField] private float currentPrayTime;
   [SerializeField] private float ratioCount=0;
   //祈りをチャージする処理
   public void PrayCharge()
   {
      currentTime += Time.deltaTime;
      if (currentTime>.5)
      {
         Pray();   
      }
   }
   //祈りを止める処理
   public void StopPray()
   {
      PlayerProvider.i.PlayerAnimation.StopPrayAnimation();
      ratioCount = 0;
      currentTime = 0;
   }
   //祈り処理
   public void Pray()
   {
      //アニメーション表示
      PlayerProvider.i.PlayerAnimation.PrayAnimation();
      currentPrayTime += Time.deltaTime;
      if (currentPrayTime>.25f)
      {
         ratioCount++;
         currentPrayTime = 0;
         var ratio=1f;
         ratio+= ratioCount * 0.1f;
         //業が時間経過によって減少するプログラム。
         if ((TokuManager.i.gou - (int)(20 * ratio))<=0)
         {
            return;
         }         
         TokuManager.i.gou -= (int)(20 * ratio);
         TokuManager.i.toku += (int)(20 * ratio);
      }
      
      //effect表示
      PlayerProvider.i.PlayerEffect.PlayPrayEffect();
   }
}

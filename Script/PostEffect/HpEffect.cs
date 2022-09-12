using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Serialization;

/// <summary>
/// HpEffectのクラス
/// </summary>
public class HpEffect : MonoBehaviour
{
   //スタートと終わり
   public float start;
   public float end1;
   public float end2;
   public float end3;
   public float current;

   public float hpPer;
   public bool isChange;
   // スピード
   public float speed = 1.0F;
   [SerializeField] private PostProcessVolume volume;
   [SerializeField] private Vignette _vignette;

   public static HpEffect i;

   public void Awake()
   {
      i = this;
      _vignette = volume.profile.GetSetting<Vignette> ();

   }

   private void Update()
   {
      if (isChange)
      {
         DecleaseHp();
      }
   }

   //Hpを減らすクラス
   public void DecleaseHp()
   {
      if (hpPer>=1)
      {
         if (_vignette.roundness.value==start)
         {
            return;
         }
         _vignette.roundness.value=Mathf.MoveTowards(_vignette.roundness.value,start,speed);
      }
      Debug.Log(hpPer);
      if (hpPer>=0.8)
      {
         _vignette.roundness.value=Mathf.MoveTowards(_vignette.roundness.value,end1,speed);
      }else if(hpPer>=.4)
      {
         _vignette.roundness.value=Mathf.MoveTowards(_vignette.roundness.value,end2,speed);
      }else if (hpPer>=0)
      {
         _vignette.roundness.value=Mathf.MoveTowards(_vignette.roundness.value,end3,speed);
      }
   }
   //Hpを監視する処理
   public void HpWatch()
   {
      Debug.Log(PlayerProvider.i.PlayerStatus.Hp);
      Debug.Log(PlayerProvider.i.PlayerStatus.maxHp);
      hpPer = (float)(PlayerProvider.i.PlayerStatus.Hp) / (float)(PlayerProvider.i.PlayerStatus.maxHp);
      Debug.Log(hpPer);
      if (hpPer<=1)
      {
         isChange = true;
      }
   }
}

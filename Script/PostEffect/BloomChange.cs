using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Serialization;

/// <summary>
/// Bloomを変更するクラス
/// </summary>
public class BloomChange : MonoBehaviour
{
    //tはthresholdの略です。
    public bool isChange=false;
    [SerializeField] private bool isReturnChange=false;

    [FormerlySerializedAs("isEndToBloom")] [SerializeField] private bool isEndBloom = false;
    [FormerlySerializedAs("currentNum")] public float currentNumIntensity;

    public float currentNumThreshold;
    //スタートと終わり
   public float start;
   public float end;
 
   public float tStart;
   public float tEnd;

   // スピード
   public float speed = 1.0F;
 
   //二点間の距離を入れる
   private float distance_two;
   private float tDistance_two;

   [SerializeField] private PostProcessVolume volume;
   [SerializeField] private Bloom bloom;

   [SerializeField]
   public void Start()
   {
       distance_two = end - start;
       tDistance_two = tEnd - tStart;
       //volume = GetComponent<PostProcessVolume> ();
       //設定を取得する
       bloom = volume.profile.GetSetting<Bloom> ();
   }

   public void FixedUpdate()
   {
       if (isChange==true)
       {
           if (isReturnChange==false)
           {
               ChangeBloom();
           }
           else
           {
               ChangeBloomReturn();
           }
       }
   }

   //Bloomの効果を発動する
   public void ChangeBloom()
   { 
       bloom.intensity.value = Mathf.MoveTowards(bloom.intensity.value,end,speed);
       currentNumIntensity = bloom.intensity.value;
       if (bloom.intensity.value>=end)
      {
          isReturnChange = true;
          distance_two = start - end;
          tDistance_two = tStart - tEnd;
      }
   }
   //Bloomの効果を戻す
   public void ChangeBloomReturn()
   {
       // 現在の位置
       bloom.intensity.value = Mathf.MoveTowards(bloom.intensity.value,0,speed);
       currentNumIntensity = bloom.intensity.value;

        if(bloom.intensity.value <= 0)
        {
            isReturnChange = false;
            isChange = false;
        }

   }
}

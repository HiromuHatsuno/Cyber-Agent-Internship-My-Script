using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

/// <summary>
/// 人徳解放のエフェクトクラス
/// </summary>
public class SpecialEffect : MonoBehaviour
{
    //スタートと終わり
    public float end;
    public float end2;
    public bool isChange;
    public bool isZoom;
    public bool isMiddium;
    public float speed;
    [SerializeField] private PostProcessVolume volume;
    [SerializeField] private LensDistortion lensDistortion;
    public static SpecialEffect i;
    public void Awake()
    {
        i = this;
        lensDistortion = volume.profile.GetSetting<LensDistortion> ();
    }
    private void Update()
    {
        if (isChange)
        {
            if (isZoom)
            {
                ZoomFx();
            }
            else
            {
                if (isMiddium == true)
                {
                    EndZoomFX();
                }
                else
                {
                    OutZoomFX();
                }
            }
        }
    }

    //画面をズームする処理
    public void ZoomFx()
    {
        lensDistortion.intensity.value=Mathf.MoveTowards(lensDistortion.intensity.value,end,speed);
        if (lensDistortion.intensity.value==end)
        {
            isZoom = false;
        }
    }

    //画面をズームアウトする処理
    public void OutZoomFX()
    {
            lensDistortion.intensity.value = Mathf.MoveTowards(lensDistortion.intensity.value, end2, speed);
        if (lensDistortion.intensity.value==end2)
        {
            isMiddium = true;
        }
    }

    //ズームアウト、インを戻す処理
    public void EndZoomFX()
    {
        lensDistortion.intensity.value = Mathf.MoveTowards(lensDistortion.intensity.value, 0, speed);
        if (lensDistortion.intensity.value==0)
        {
            isChange = false;
        }
    }

    public void startFx()
    {
        isChange = true;
        isZoom = true;
        isMiddium = false;
    }
    
    
}


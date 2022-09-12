using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// エフェクトを管理するクラス
/// </summary>
public class PlayerEffect : MonoBehaviour
{
    [SerializeField] private GameObject attackEffect;

    [SerializeField] private GameObject damageEffect;

    [SerializeField] private GameObject prayEffect;

    [SerializeField] private GameObject benevolentEffect;

    [SerializeField] private float effectDestroyTime;
    //プレイヤーの攻撃エフェクト
    public void PlayAttackEffect()
    {
        var effect = Instantiate(attackEffect, this.transform.position, Quaternion.identity);
        Destroy(effect,effectDestroyTime);
    }
    //プレイヤーのダメージエフェクト
    public void PlayDamageEffect()
    {
        var effect = Instantiate(damageEffect, this.transform.position, Quaternion.identity);
        Destroy(effect,effectDestroyTime);
    }
    //プレイヤーの祈りエフェクト
    public void PlayPrayEffect()
    {
        var effect = Instantiate(prayEffect, this.transform.position, Quaternion.identity);
        Destroy(effect,effectDestroyTime);
    }
    //人徳解放エフェクト
    public void PlayBenevolentEffect()
    {
        var effect = Instantiate(benevolentEffect, this.transform.position, Quaternion.identity);
        Destroy(effect,effectDestroyTime);
    }
}

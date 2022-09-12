using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Playerの特別効果クラス
/// </summary>
public class PlayerSpecial : MonoBehaviour
{
    [SerializeField]private float currentTime;
    [SerializeField] private bool specialOK;
    [SerializeField] private float attackDelay;
    [SerializeField] private float attackEndDelay;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private int decleaseToku;
    [SerializeField] private bool canCharge=true;
    [SerializeField] private float coolTime=5;
    [SerializeField] int attackID;
    //人徳解放のチャージプログラム
    public void ChargeSpecial()
    {
        if (canCharge)
        {
            currentTime += Time.deltaTime;
            if (currentTime > 0)
            {
                specialOK = true;
            }
        }
    }
    //人徳解放を止める処理
    public void StopSpecial()
    {
        specialOK = false;
        currentTime = 0;
    }
    
    //人徳解放
    public void Special()
    {
        Debug.Log("呼び出されています。"+specialOK);
        if (specialOK==true)
        {
            //仁徳解放の発動を止める処理
            var attack = AttackGenerater.instance?.GetAttack(attackID);
            if (attack.IsActive) return;

            canCharge = false;
            //徳の減少プログラム]
            if ((TokuManager.i.toku-decleaseToku)<=0)
            {
                return;
            }
            SpecialEffect.i.startFx();
            TokuManager.i.toku -= decleaseToku;
            StopSpecial();
            Debug.Log("Special発動");
            Invoke(nameof(CanCharging),coolTime);
            attack?.Activate(PlayerProvider.i.transform.position, PlayerProvider.i.PlayerLookMouse.direction);
            if (attack == null) Debug.LogError("PlayerAttack is null");
        }
    }
    public void OnEnableSpecialCollision()
    {
        boxCollider2D.enabled = true;
        PlayerProvider.i.PlayerEffect.PlayAttackEffect();
    }

    //徳をチャージする事を可能とするプログラム
    public void CanCharging()
    {
        canCharge = true;
    }
    public void DisEnableSpecialCollision()
    {
        boxCollider2D.enabled = false;
    }
}

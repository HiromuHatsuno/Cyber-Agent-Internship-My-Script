using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// プレイヤーのProviderクラス
/// </summary>
public class PlayerProvider : MonoBehaviour
{
    public PlayerMove playerMove;
    public PlayerInput playerInput;
    public PlayerStatus PlayerStatus;
    public PlayerLookMouse PlayerLookMouse;
    public PlayerAnimation PlayerAnimation;
    public PlayerAttack PlayerAttack;
    public PlayerDamage PlayerDamage;
    public PlayerDead PlayerDead;
    public PlayerEffect PlayerEffect;
    public PlayerPray PlayerPray;
    public Rigidbody2D Rigidbody2D;
    public PlayerSpecial PlayerSpecial;
    public static PlayerProvider i;
    
    private void Awake() { 
        i=this;
    }
}
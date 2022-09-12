using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// プレイヤーのステータス処理
/// </summary>
public class PlayerStatus : MonoBehaviour
{
    [SerializeField]private float speed = 0.5f;
    [SerializeField]private int attack = 5;
    [SerializeField]private int specialAttack = 5;
    [SerializeField] private int hp = 5;
    [SerializeField] public int maxHp = 5;

    public int Attack => attack;    
    public int SpecialAttack => specialAttack;
    public int Hp => hp;
    public float Speed => speed;

    private void Start()
    {
        maxHp = hp;
    }

    public void decreaseHp(int decreaseNumber)
    {
        hp -= decreaseNumber;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//徳を管理するManagerクラス
public class TokuManager : MonoBehaviour
{
   
    public int toku = 5000;

    public int gou=15;

    [SerializeField] public int totalToku;

    [SerializeField] private bool isStartTensei=true;

    [SerializeField] private int TokuisMushiRank;
    [SerializeField] private int TokuisDoubutuRank;
    [SerializeField] private int TokuisHitoRank;
    [SerializeField] private Transform bornPosition;
    [SerializeField] private GameObject mushi;
    [SerializeField] private GameObject doubutu;
    [SerializeField] private GameObject hito;
    [SerializeField] private GameObject kami;
    [SerializeField] private SceneManager _sceneManager;
    public static TokuManager i;
    //最終的な徳を計算させます。
    public void CalculateTotalToku()
    {
        totalToku=toku - gou;
        
        SelectCharacter();
    } 
    //シングルトンなので初期化
    private void Awake() { 
        i=this;
    }

    private void Update()
    {
        //クリア判定
        if (toku-gou>=10000)
        {
            _sceneManager.ChangeScene();
        }
    }

    //初期に転生させるプログラム
    public void Start()
    {
        //スタート時転生させる場合
        if (isStartTensei)
        {
            CalculateTotalToku();
        }
    }

    //転生させるプログラム
    public void SelectCharacter()
    {
        totalToku = toku - gou;
        toku -= gou;
        gou = 0;
        if (toku<=0)
        {
            toku = 0;
        }
        if (totalToku <= TokuisMushiRank)
        {
            //プレイヤーを虫を表示させる処理を行う。
            Instantiate(mushi, bornPosition.position, Quaternion.identity);
        }else if (totalToku>=TokuisMushiRank&&totalToku<=TokuisDoubutuRank)
        {
            //プレイヤーを動物にする処理
            Instantiate(doubutu, bornPosition.position, Quaternion.identity);
        }else if (totalToku>=TokuisDoubutuRank&&totalToku <= TokuisHitoRank)
        {
            //プレイヤーを人にする処理
            Instantiate(hito, bornPosition.position, Quaternion.identity);
        }else if (totalToku>TokuisHitoRank)
        {
            //プレイヤーを神にする処理
            Instantiate(kami, bornPosition.position, Quaternion.identity);
        }
        //Hpエフェクトの更新
        HpEffect.i.HpWatch();
    }
}

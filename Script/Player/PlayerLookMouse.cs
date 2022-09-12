using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// マウスに合わせてプレイヤの向きを変更する処理
/// </summary>
public class PlayerLookMouse : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    //プレイヤーが移動だけで回転が変わってしまうのを防ぐ
    [SerializeField] private Transform offsetObj;
    public Vector3 direction;

    public void Start()
    {
        offsetObj = Camera.main.gameObject.transform;
    }
    
    public void LookMouse(Vector3 mousePosition)
    {
        //Mouseの座標からプレイヤーの座標を引くことでベクトル算出
        Vector3 mouseVec = Camera.main.ScreenToWorldPoint(mousePosition) - offsetObj.transform.position;
        Vector3 mouseNormalized = mouseVec.normalized; //正規化
        mouseNormalized = new Vector3(mouseNormalized.x, mouseNormalized.y, 0); //Z座標の初期化
        
        //回転処理
        float angle = Vector3.Angle(new Vector3(0, 1, 0), mouseNormalized);
        if (mouseNormalized.x > 0) angle = -angle;
        direction = mouseNormalized;
    }
}

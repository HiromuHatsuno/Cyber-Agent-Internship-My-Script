using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// プレイヤー移動クラス
/// </summary>
public class PlayerMove : MonoBehaviour
{
    private float dashTime;
    private float xSpeed;
    private float ySpeed;
    public AnimationCurve dashCurve;

    public void LeftMove()
    {
        xSpeed = -PlayerProvider.i.PlayerStatus.Speed;
    }
    public void RightMove()
    {
        xSpeed = PlayerProvider.i.PlayerStatus.Speed;
    }
    public void UpMove()
    {
        ySpeed = PlayerProvider.i.PlayerStatus.Speed;
    }
    public void DownMove()
    {
        ySpeed = -PlayerProvider.i.PlayerStatus.Speed;
    }
    public void CountDash()
    {
        dashTime += Time.deltaTime;
        Run();
    }

    //ダッシュ停止処理
    public void StopRun()
    {
        dashTime = 0;
        xSpeed = 0;
        ySpeed = 0;
        PlayerProvider.i.Rigidbody2D.velocity = new Vector2(0,0);
    }
    //ダッシュ処理
    public void Run()
    {
        
        xSpeed *= dashCurve.Evaluate(dashTime);
        ySpeed *= dashCurve.Evaluate(dashTime);
        PlayerProvider.i.Rigidbody2D.velocity = new Vector2(xSpeed, ySpeed);
        
    }
}

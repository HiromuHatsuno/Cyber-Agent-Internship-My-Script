using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// プレイヤーの入力クラス
/// </summary>
public class PlayerInput : MonoBehaviour
{
    [SerializeField] public Transform transformT;
    private bool canMove=true;
    void Update()
    {
        //ポーズ中は止める
        if (Time.timeScale == 0)
        {
            return;
        }
        if (!GameLoopManager.instance.IsPlaying) return;

        canMove = true;
        //志望したら動かなくさせる
        if (PlayerProvider.i.PlayerDead.isDead)
        {
            PlayerProvider.i.Rigidbody2D.velocity = Vector2.zero;
            return;
        }
        //何かボタンを押した時の処理
        if (Input.anyKeyDown)
        {
            PlayerProvider.i.PlayerSpecial.StopSpecial();
            PlayerProvider.i.PlayerPray.StopPray();
        }
        //十字キーの入力があった時の処理
        else if (Input.GetAxis("Horizontal")!=0&Input.GetAxis("Vertical")!=0)
        {
            PlayerProvider.i.PlayerSpecial.StopSpecial();
            PlayerProvider.i.PlayerPray.StopPray();
        }
        //人徳解放チャージが押された時の処理
        else if (Input.GetMouseButton(1))
        {
            PlayerProvider.i.PlayerPray.StopPray();
            PlayerProvider.i.PlayerSpecial.ChargeSpecial();
            canMove = false;
        }
        //何もバタンが押されてない時は祈る。
        else　if(!(Input.anyKeyDown)&Input.GetAxis("Horizontal")==0&Input.GetAxis("Vertical")==0&!Input.GetMouseButton(1))
        {
            PlayerProvider.i.PlayerPray.PrayCharge();
        }
        //人徳解放ボタンが押された時の処理
        if (Input.GetMouseButtonUp(1))
        {
            PlayerProvider.i.PlayerSpecial.Special();
            PlayerProvider.i.PlayerPray.StopPray();
        }
        
        //移動ができない場合ここで処理を止める。
        if (canMove==false)
        {
            return;
        }
        //移動処理
        if (Input.GetAxis("Horizontal") > 0)
        {
            transformT.localScale = new Vector3(-1, 1, 1);
            PlayerProvider.i.PlayerAnimation.MoveAnimation();
            PlayerProvider.i.playerMove.RightMove();
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transformT.localScale = new Vector3(1, 1, 1);
            PlayerProvider.i.PlayerAnimation.MoveAnimation();
            PlayerProvider.i.playerMove.LeftMove();
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            PlayerProvider.i.PlayerAnimation.MoveAnimation();
            PlayerProvider.i.playerMove.UpMove();
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            PlayerProvider.i.PlayerAnimation.MoveAnimation();
            PlayerProvider.i.playerMove.DownMove();
        }
        if (Input.GetAxis("Horizontal")!=0||Input.GetAxis("Vertical")!=0)
        {
            PlayerProvider.i.playerMove.CountDash();
            PlayerProvider.i.playerMove.Run();
        }
        //停止処理
        else
        {
            PlayerProvider.i.PlayerAnimation.StopMoveAnimation();
            PlayerProvider.i.playerMove.StopRun();
        }
        //Mouse操作
        PlayerProvider.i.PlayerLookMouse.LookMouse(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            PlayerProvider.i.PlayerAttack.Attack();
        }
       
    }
}

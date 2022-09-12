using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//画面にカーソルが出ない様にする処理
public class CursolDeleate : MonoBehaviour
{
    //カーソルの消去処理
    void Start()
    {
        Cursor.visible = false;
    }
}

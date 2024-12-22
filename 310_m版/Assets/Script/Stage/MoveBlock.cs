/**
* @file MoveBlock.cs
* @brief MoveBlockクラスの実装
* @author 倉　和規
* @date 5/5
*
* @details 
* @note 
*/

using UnityEngine;
using System.Collections;


/** クラスの概要説明 */
/**
* 自身を上下にゆらゆら動かす
*/
public class MoveBlock : MonoBehaviour
{
    [Header("揺れの幅")]
    [SerializeField]
    private float Radius = 0;

    //! 自分のRigidbody格納用
    private Rigidbody rigid;


    //! 自分の初期位置保存用
    private Vector3 defaultPos;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        defaultPos = transform.position;
    }

    private void FixedUpdate()
    {
        rigid.MovePosition(new Vector3(defaultPos.x, defaultPos.y + Mathf.PingPong(Time.time, Radius), defaultPos.z));

    }
}

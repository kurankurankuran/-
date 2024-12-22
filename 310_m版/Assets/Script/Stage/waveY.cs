/**
* @file MoveBlock.cs
* @brief MoveBlockクラスの実装
* @author 倉　和規
* @date 5/5
*
* @details 
* @note 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/** クラスの概要説明 */
/**
* 自身を上下にゆらゆら動かす
*/
public class waveY : MonoBehaviour
{
    [SerializeField]
    private float RengeY = 0.3f;

    [SerializeField]
    private float DefY = 0.0f;


    private float nowPosi;

    void Start()
    {
        nowPosi = this.transform.position.y;
    }

  

    private void LateUpdate()
    {
        transform.position = new Vector3(transform.position.x, nowPosi + Mathf.PingPong(Time.time / 10.0f + DefY, RengeY), transform.position.z);
    }

}
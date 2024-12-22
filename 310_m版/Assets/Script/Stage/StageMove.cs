/**
* @file StageMove.cs
* @brief StageMoveクラスの実装
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
* ステージ全体の親オブジェクトを入力方向に回転させる
*/
public class StageMove : MonoBehaviour
{
    private PlayerMove PlayerMoveScript;

    

    // Start is called before the first frame update
    void Start()
    {
        PlayerMoveScript = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    PlayerMoveScript.CirCleMove(transform);
    //}
    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMoveScript.CirCleMove(transform);
    }

    // 生成するパーティクル用関数
    public void SetPlayerMove()
    {
       
        PlayerMoveScript = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
    }
}

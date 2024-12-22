/**
* @file Dead.cs
* @brief Deadクラスの実装
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
* 機能：
* ・１プレイヤーがあたると死亡フラグを立てる
* 使い方:
* １　オブジェクトにアタッチ
*/


public class Dead : MonoBehaviour
{

    //あたり判定検査
    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーの時
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("AudioController").GetComponent<GAudio>().OverSEPlay();

            DeadShow.DanChu = true;


        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

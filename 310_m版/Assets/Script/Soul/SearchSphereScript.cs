/**
* @file SearchSphereScript.cs
* @brief SearchSphereScriptクラスの実装
* @author 倉　和規
* @date 5/5
*
* @details 
* @note 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// プレイヤー追跡用探索球
/** クラスの概要説明 */
/**
* 機能：
* ・アタッチされたオブジェクトにプレイヤーがあたるとDarkSoulを追尾状態にする
* 
* 使い方:
* １　探索範囲にしたいオブジェクトにアタッチする
*/


public class SearchSphereScript : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            transform.parent.GetComponent<DarkSoulScript>().Horming = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            transform.parent.GetComponent<DarkSoulScript>().Horming = false;
        }
    }
}

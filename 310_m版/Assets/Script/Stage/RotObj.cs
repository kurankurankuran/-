/**
* @file RotObj.cs
* @brief RotObjクラスの実装
* @author 倉　和規
* @date 5/5
*
* @details 
* @note 
*/

//**************************************************************:
// 機能：
// ・回転柱に触れているオブジェクトを共に回転、移動させる
//***************************************************************
// 使い方
//
// 特になし
// 親オブジェクトにdistortionスクリプトをアタッチすれば自動的に付与され、値の操作などもdistortionスクリプトで行う
//****************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/** クラスの概要説明 */
/**
* 柱が回転しているかどうかを判断するだけのクラス
*/

public class RotObj : MonoBehaviour
{
    //// それぞれの回転柱に触れたオブジェクトを格納するList
    //private List<GameObject> objList = new List<GameObject>();

    // スクリプト格納用
    private distortion DistScript;

    // 回転するかどうかフラグ（親オブジェクトで変更している）
    public bool RotBool;

    // 親のtransform格納用
    Transform parentTransform;

    Color myColor;

    private void Awake()
    {
        RotBool = false;

        // 親のtransform取得
        parentTransform = transform.parent.gameObject.transform;

        
    }

    // Start is called before the first frame update
    void Start()
    {
        //myColor = GetComponent<Color>();
        //myColor.a = 0.5f;
        //GetComponent<Renderer>().material.color = myColor;

        // 親のスクリプト取得
        DistScript = transform.parent.gameObject.GetComponent<distortion>();
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //    for (int i = 0; i < objList.Count; ++i)
    //    {
    //        // Listの要素がNULLの場合Listから削除
    //        if (objList[i] == null)
    //        {
    //            objList.Remove(objList[i]);
    //            continue;
    //        }

    //        // 回転柱に触れているオブジェクトを入力方向に移動させる処理
    //        //float x = Input.GetAxis("Horizontal") * DistScript.RotSpeed;
    //        //objList[i].transform.RotateAround(parentTransform.position, parentTransform.up, -x);
    //    }

    //    //if (RotBool)
    //    //{
    //    //    for (int i = 0; i < objList.Count; ++i)
    //    //    {
    //    //        // 回転柱に触れているオブジェクトも回転柱とともに回転させる処理
    //    //        objList[i].transform.RotateAround(transform.position, transform.right, DistScript.RotValue);
                
               
    //    //    }
    //    //}
        
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    // プレイヤーは回転柱とともに回転しない
    //    if (other.gameObject.tag != "Player")
    //    {
    //        // 既にList内に同じオブジェクトが有ればListに追加しない
    //        if (objList.FindIndex(n => n.name == other.name) < 0)
    //        {
    //            // Listにオブジェクトを追加
    //            objList.Add(other.gameObject);

                
    //        }
            
           
    //    }
    //}
   
}

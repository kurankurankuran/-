/**
* @file CircleDeployer.cs
* @brief CircleDeployerクラスの実装
* @author 倉　和規
* @date 5/5
*
* @details 
* @note 
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/** クラスの概要説明 */
/**
* 子にあるオブジェクトを円状に配置するクラス
*/

public class CircleDeployer : MonoBehaviour
{

    //半径
    [SerializeField]
    public float _radius;

    //=================================================================================
    //初期化
    //=================================================================================

    private void Awake()
    {
        Deploy();
    }

    //Inspectorの内容(半径)が変更された時に実行
    private void OnValidate()
    {
        Deploy();
    }

    //子を円状に配置する(ContextMenuで鍵マークの所にメニュー追加)
    [ContextMenu("Deploy")]
    private void Deploy()
    {

        //子を取得
        List<GameObject> childList = new List<GameObject>();
        foreach (Transform child in transform)
        {
            bool bSkip = false;
            for (int i = 0; i < childList.Count; ++i)
            {
                if (childList[i].gameObject.name == child.gameObject.name)
                {
                    bSkip = true;
                }
            }

            if (!bSkip)
            {
                childList.Add(child.gameObject);
            }
        }

        //数値、アルファベット順にソート
        childList.Sort(
          (a, b) => {
              return string.Compare(a.name, b.name);
          }
        );

        //オブジェクト間の角度差
        float angleDiff = 360f / (float)childList.Count;


        //各オブジェクトを円状に配置
        for (int i = 0; i < childList.Count; i++)
        {
         
            
            childList[i].transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
            childList[i].transform.Rotate(transform.up, i * angleDiff);

            //if (childList[i].tag == "Screen")
            //{
            //    childList[i].transform.Rotate(transform.right, -90);
            //}
            //if (childList[i].tag == "ThatScreen")
            //{
            //    childList[i].transform.Rotate(transform.right, 90);
            //}


            Vector3 childPostion = transform.position;

            float angle = (90 - angleDiff * i) * Mathf.Deg2Rad;
            childPostion.x += _radius * Mathf.Cos(angle);
            childPostion.z += _radius * Mathf.Sin(angle);

            childList[i].transform.position = childPostion;

           
        }

    }

}
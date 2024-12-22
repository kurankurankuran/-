/**
* @file SortCamera.cs
* @brief SortCameraクラスの実装
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
* ・カメラ同士を名前順に等間隔で並べる
* 使い方:
* １　カメラ達の親オブジェクトにアタッチする
*/

public class SortCamera : MonoBehaviour
{
    [Header("カメラ同士の距離")]
    [SerializeField]
    public float Distance;


    private void Awake()
    {
        Sort();
    }

    //Inspectorの内容(半径)が変更された時に実行
    private void OnValidate()
    {
        Sort();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Sort()
    {
        //子を取得
        List<GameObject> childList = new List<GameObject>();
        foreach (Transform child in transform)
        {
            bool bSkip = false;
            if(this.name == child.gameObject.name)
            {
                bSkip = true;
            }

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

        //各カメラを横一列に配置
        for (int i = 0; i < childList.Count; i++)
        {
            //Reset(childList[i].transform);

            childList[i].transform.localPosition = new Vector3((i - childList.Count / 2) * Distance, 0.0f, 0.0f);


            //childList[i].transform.position = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
            //childList[i].transform.Rotate(transform.up, i * angleDiff);

            ////if (childList[i].tag == "Screen")
            ////{
            ////    childList[i].transform.Rotate(transform.right, -90);
            ////}
            ////if (childList[i].tag == "ThatScreen")
            ////{
            ////    childList[i].transform.Rotate(transform.right, 90);
            ////}


            //Vector3 childPostion = transform.position;

            //float angle = (90 - angleDiff * i) * Mathf.Deg2Rad;
            //childPostion.x += _radius * Mathf.Cos(angle);
            //childPostion.z += _radius * Mathf.Sin(angle);

            //childList[i].transform.position = childPostion;


        }
    }

    private void Reset(Transform SortTransform, bool isLocal = false)
    {
        if (isLocal)
        {
            SortTransform.localPosition = Vector3.zero;
            //transform.localRotation = Quaternion.identity;
            //transform.localScale = Vector3.one;
        }
        else
        {
            SortTransform.position = Vector3.zero;
            //transform.rotation = Quaternion.identity;
            //transform.localScale = new Vector3(
            //  transform.localScale.x / transform.lossyScale.x,
            //  transform.localScale.y / transform.lossyScale.y,
            //  transform.localScale.z / transform.lossyScale.z
            //);
        }
    }
}

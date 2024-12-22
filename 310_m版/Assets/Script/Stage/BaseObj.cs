/**
* @file BaseObj.cs
* @brief BaseObjクラスの実装
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
* ソウルが逃げるとこの地点に帰還する
*/
public class BaseObj : MonoBehaviour
{
    
    [Header("SoulオブジェクトをD&D")]
    [SerializeField]
    GameObject SoulObj;


    [Header("世界判断フラグ(tureでこの世)")]
    [SerializeField]

    //! 自身がいる世界を判断
    private bool bThisorThat = true;

    private void OnValidate()
    {
        transform.position = SoulObj.transform.position;
    }

    private void Awake()
    {
        transform.position = SoulObj.transform.position;
    }

    public bool GetThisorflg()
    {
        return bThisorThat;
    }
    
}

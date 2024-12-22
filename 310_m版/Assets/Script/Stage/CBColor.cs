////**************************************************************:
//// 機能：
//// ・白黒の色切替
//// ・すり抜ける抜けない性質の付与と切替
////***************************************************************
//// 使い方
//// １　すり抜ける抜けないの性質を持たせるオブジェクトにアタッチ
//// ２　インスペクターから値を設定
//// ３　以上
////***************************************************************

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CBColor : MonoBehaviour
//{
//    [Header("このオブジェクトが属している回転柱をここに設定")]
//    [SerializeField]
//    private GameObject BW;
 
//    // 自身のコライダー格納用（isTrigger切替用）
//    private Collider m_ObjectWCollider;

//    [Header("初期性質を設定（黒(true)ですり抜ける）")]
//    [SerializeField]
//    private bool bBlack;
    
//    // 回転柱のBWSwitchスクリプト格納用
//    BWSwitch RodPillar;
   
//    // 前フレーム時点のフラグ格納用
//    bool bOldBWSwitch;



//    //Inspectorの内容が変更された時に実行
//    private void OnValidate()
//    {
//        // 自身のコライダー取得
//        m_ObjectWCollider = GetComponent<Collider>();

//        // 色切替とisTrigger設定
//        if (bBlack)
//        {
//            this.GetComponent<MeshRenderer>().material.color = Color.black;

//            m_ObjectWCollider.isTrigger = true;
//        }
//        else
//        {
//            this.GetComponent<MeshRenderer>().material.color = Color.white;

//            m_ObjectWCollider.isTrigger = false;
//        }


//    }


//    // Start is called before the first frame update
//    void Start()
//    {
//        // 回転柱のBWSwitch取得
//        RodPillar = BW.GetComponent<BWSwitch>();

//        // フラグ保存
//        bOldBWSwitch = RodPillar.bBWSwich;

        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // フラグ切り替わったのか判定
//        if (RodPillar.bBWSwich != bOldBWSwitch)
//        {
//            // isTrigger切替
//            m_ObjectWCollider.isTrigger = !m_ObjectWCollider.isTrigger;
           
//            // 色切替
//            if (this.GetComponent<MeshRenderer>().material.color == Color.white)
//            {
//                this.GetComponent<MeshRenderer>().material.color = Color.black;
//            }
//            else
//            {
//                this.GetComponent<MeshRenderer>().material.color = Color.white;
//            }
//        }

//        // フラグ保存
//        bOldBWSwitch = RodPillar.bBWSwich;
//    }


//}


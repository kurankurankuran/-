////**************************************************************:
//// 機能：
//// ・bBWSwitchの切替
//// ・このスクリプトのbBWSwitchを参照して、2面性を持つオブジェクトの性質が切り替わる
////***************************************************************
//// 使い方
////
//// 特になし
//// 親オブジェクトにdistortionスクリプトをアタッチすれば自動的に付与され、値の操作などもdistortionスクリプトで行う
////****************************************************************
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BWSwitch : MonoBehaviour
//{
//    // 2面性を持つオブジェクトの性質を切り替えるフラグ 
//    // 回転柱の回転により切り替わる
//    public bool bBWSwich;

//    // 切り替える時間、回転柱が90°回転するごとに切り替わるよう調整済み
//    private float nSwitchTime;

//    // 切替時間保存用
//    float nDefSwitchTime;

//    // スクリプト保存用 
//    private distortion DistScript;
//    // スクリプト保存用 
//    private RotObj RotObjScript;

    
//    // Start is called before the first frame update
//    void Start()
//    {
//        // スクリプト取得
//        RotObjScript = transform.GetComponent<RotObj>();

//        // スクリプト取得
//        DistScript = transform.parent.GetComponent<distortion>();

//        // 回転柱が90°回転するごとに切り替わるよう調整
//        nSwitchTime = 360 / DistScript.RotValue / 4;

//        nDefSwitchTime = nSwitchTime * 2;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (RotObjScript.RotBool)
//        {
//            --nSwitchTime;
            
//            if (nSwitchTime < 0)
//            {
//                bBWSwich = !bBWSwich;
//                nSwitchTime = nDefSwitchTime;
                
//            }
//        }

//    }




//}

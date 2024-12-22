/**
* @file WorldTimeScript.cs
* @brief WorldTimeScriptクラスの実装
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
* ・TimeScaleを指定時間（unscaledDeltaTime）だけ0にする
* 使い方:
* １　回転柱を子オブジェクトとする親オブジェクトにアタッチする
* ２　TimeStop(float stopTime)を止めたい時間だけ止める
* ３　以上
*/


public class WorldTimeScript : MonoBehaviour
{
    private static bool Stop = false;
    private static float StopTime = 0;
    private float StopCnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Stop)
        {
            StopCnt += Time.unscaledDeltaTime;

            if (StopTime < StopCnt)
            {
                StopCnt = 0;
                Stop = false;
                Time.timeScale = 1;

            }
        }
    }

    public static void TimeStop(float stopTime)
    {
        Time.timeScale = 0;
        Stop = true;
        StopTime = stopTime;
    }
}

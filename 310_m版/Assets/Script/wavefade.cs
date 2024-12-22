/**
* @file wavefade.cs
* @brief wavefadeクラスの実装
* @author 倉　和規
* @date 5/27
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
* ・波紋型フェードの生成用

* 使い方:
* １　空のオブジェクトにアタッチして他の好きなスクリプト内でFadeStart()関数を仕様
*/
public class wavefade : MonoBehaviour
{
    //画像
    [SerializeField]
    private Texture image;

    //透明値
    float alpha;
    //フェード速度
    public float speed;

    private static bool bOut;

    private static bool bFadeNow;

    private static bool bFadeStart; 

    // Start is called before the first frame update
    void Start()
    {
        bFadeStart = true;
        bFadeNow = false;
        bOut = false;
        alpha = 1.0f;
    }

    private void OnGUI()
    {
        if (!bFadeNow)
        {
           
            if (bFadeStart/*Input.GetKeyDown(KeyCode.X)*/)
            {
                bFadeNow = true;
                WaterWaveFade.Onoff = true;
               
            }
        }
        else
        {
            if (bOut)
            {
                alpha += speed;

                if (alpha >= 1.0)
                {
                    bFadeStart = false;
                    bFadeNow = false;
                    bOut = false;


                    LoadScene.StartNextScene();

                    LoadScene.SetNull();
                }
            }
            else
            {
                alpha -= speed;

                if (alpha <= 0.0)
                {
                    bFadeStart = false;
                    bFadeNow = false;
                    bOut = true;
                }
            }
        }




        //画像のcolor
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        //画面全体的に表示
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), image);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void FadeStart()
    {
        bFadeNow = false;
        bOut = true;
        bFadeStart = true;
    }
}

/**
* @file moviefade.cs
* @brief moviefadeクラスの実装
* @author 倉　和規
* @date 5/5\27
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
* ・ムービー用フェード発生用
* 
* 使い方:
* １　空のオブジェクトにアタッチしてxキー
*/

public class moviefade : MonoBehaviour
{
    //画像
    [SerializeField]
    private Texture image;

    //透明値
    float alpha;
    //フェード速度
    public float speed;

    private bool bOut;

    private bool bFadeNow;

    // Start is called before the first frame update
    void Start()
    {
        bFadeNow = false;
        bOut = true;
        alpha = 0.0f;
    }

    private void OnGUI()
    {
        if (!bFadeNow)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                bFadeNow = true;
               
            }
        }
        else
        {
            if (bOut)
            {
                alpha += speed;

                if (alpha >= 1.0)
                {
                    bFadeNow = false;
                    bOut = false;
                }
            }
            else
            {
                alpha -= speed;

                if (alpha <= 0.0)
                {
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
}

/**
* @file SupriseAlpha.cs
* @brief SupriseAlphaクラスの実装
* @author 倉　和規
* @date 5/27
*
* @details 
* @note 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 制御元スクリプト
using static ImageExt;


/** クラスの概要説明 */
/**
* 機能：
* ・画像を揺らす
* 
* 使い方:
* １　回転柱を子オブジェクトとする親オブジェクトにアタッチする
* ２　インスペクターからそれぞれの値を決定
* ３　以上
*/



public class SupriseAlpha : MonoBehaviour
{
    [SerializeField]
    Image image;

    public UIShake shake;

    //[Header("Alpha１での表示時間")]
    //[SerializeField]
    private float DispTime = 500.0f;
    private float DispCount = 0.1f;

    private bool bUp = false;

    // Start is called before the first frame update
    void Start()
    {
        image.SetOpacity(0.0f);
        //// GameObjectの取得
        //GameObject target = GameObject.Find("Target");
        // Imageの取得
        //image = target.GetComponent<Image>();
        // 0=透明 1=不透明なので、1.0で完全に不透明になる
        //image.SetOpacity(1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (bUp)
        {
           
            image.SetOpacity(image.GetOpacity() + 0.2f);
            if (1.0f <= image.GetOpacity())
            {
                bUp = false;
            }
        }
        else if (image.GetOpacity() >= 1.0f && DispCount < DispTime) 
        {
            DispCount += 0.1f;

        }
        else if(DispCount >= DispTime)
        {
            image.SetOpacity(image.GetOpacity() - 0.01f);

            if (image.GetOpacity() <= 0) 
            {
                DispCount = 0;
            }
        }

    }

    public void AlphaUpDown(float Count)
    {
        DispTime = Count;
        bUp = true;
        
        shake.Shake(1000.0f, 0.05f);


    }



}

/**
* @file JumpTutorial.cs
* @brief  JumpTutorialクラスの実装
* @author 倉　和規
* @date 5/29
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
* ・飛ぶ跳ねる床オブジェクトのチュートリアル再生用
* 使い方:
* １　このスクリプトがアタッチされたオブジェクトにプレイヤーがあたるとチュートリアルが再生される。
*/
public class JumpTutorial : MonoBehaviour
{

    // チュートリアル再生できるか
    private bool bPlay;


    // Start is called before the first frame update
    void Start()
    {
        bPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (bPlay)
        {
            if (other.tag == "Player")
            {
                bPlay = false;

                Tutorial.PlayTutorial(Tutorial.TUTORIAL.JUMP_TUTORIAL);


            }
        }

    }
}

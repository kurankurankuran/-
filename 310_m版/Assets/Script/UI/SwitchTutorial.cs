/**
* @file SwitchTutorial.cs
* @brief  SwitchTutorialクラスの実装
* @author 倉　和規
* @date 5/5
*
* @details 
* @note 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


/** クラスの概要説明 */
/**
* 機能：
* ・出現/消滅を繰り返すオブジェクトのチュートリアル再生用
* 使い方:
* １　このスクリプトがアタッチされたオブジェクトにプレイヤーがあたるとチュートリアルが再生される。
*/
public class SwitchTutorial : MonoBehaviour
{
    private PlayableDirector director;
    private TrackAsset track;
    // チュートリアル再生できるか
    private bool bPlay;

    //private static PlayableDirector director;


    // Start is called before the first frame update
    void Start()
    {
        director = Tutorial.director;
        bPlay = true;
        //director = GetComponent<PlayableDirector>();
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

                Tutorial.PlayTutorial(Tutorial.TUTORIAL.SWITCH_TUTORIAL);

               
            }
        }

    }
}

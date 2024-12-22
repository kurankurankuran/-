/**
* @file Tutorial.cs
* @brief Tutorialクラスの実装
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


/** クラスの概要説明 */
/**
* 機能：
* ・事前に定数で設定されたチュートリアル(TimeLine)を再生する
* ・再生中はプレイヤーのアニメーションはwate状態になる
* 
* 使い方:
* １ 空のオブジェクトにアタッチ
*  2 PlayTutorial(再生したいチュートリアル定数)を再生したいタイミングのスクリプト内で使用
*/

public class Tutorial : MonoBehaviour
{
    public enum TUTORIAL
    {
        NONE_TUTORIAL = 0,
        START_TUTORIAL,
        SWITCH_TUTORIAL,
        JUMP_TUTORIAL,
        DARKSOUL_TUTORIAL,

        MAX_TUTORIAL
    }
    public static PlayableDirector director { get; set; }
    private static PlayableDirector director_1;
    private static PlayableDirector director_2;
    private static PlayableDirector director_3;
    private static PlayableDirector director_4;


    private PlayerMove playerMove;

    private static bool bDid = false;

  

    // Start is called before the first frame update
    void Start()
    {
        //PlayableDirector playableDirector;
      
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();

        if (GameObject.Find("SoulTimeLine") != null) 
        director_1 = GameObject.Find("SoulTimeLine").GetComponent<PlayableDirector>();
        else
        {
            director_1 = null;
        }

        if (GameObject.Find("SwitchTimeLine") != null) 
        director_2 = GameObject.Find("SwitchTimeLine").GetComponent<PlayableDirector>();
        else
        {
            director_2 = null;
        }

        if(GameObject.Find("JumpTimeLine") != null)
        director_3 = GameObject.Find("JumpTimeLine").GetComponent<PlayableDirector>();
        else
        {
            director_3 = null;
        }

        if (GameObject.Find("DarkSoulTimeLine") != null)
            director_4 = GameObject.Find("DarkSoulTimeLine").GetComponent<PlayableDirector>();
        else
        {
            director_4 = null;
        }

        // directorには必ず何かしら中身を入れておく
        if (director_1 != null)
            director = director_1;
        else if (director_2 != null)
            director = director_2;
        else if (director_3 != null)
            director = director_3;
        else if (director_4 != null)
            director = director_4;

    }

    private void FixedUpdate()
    {

        if (!bDid)
        {
          
            if (IsDoing())
            {
                
                playerMove.SetMoveFlg(false);

                // コルーチンの起動
                StartCoroutine(DelayoSetflg());
            }
        }

       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void LateUpdate()
    {
       
    }

   
    public static void PlayTutorial(TUTORIAL tUTORIAL)
    {
        switch (tUTORIAL)
        {
            case TUTORIAL.NONE_TUTORIAL:

                break;

            case TUTORIAL.START_TUTORIAL:
                //PlayerAnim.AnimationAllReset();
                director = director_1;
                break;

            case TUTORIAL.SWITCH_TUTORIAL:
                
                director = director_2;
                break;

            case TUTORIAL.JUMP_TUTORIAL:

                director = director_3;
                break;
            case TUTORIAL.DARKSOUL_TUTORIAL:

                director = director_4;
                break;
        }

        director.Play();
        bDid = false;
    }

    //! TimeLineが起動しているとTrueを返す
    public static bool IsDoing()
    {
        if (director != null)
            return 0 < director.time && director.time <= director.duration;
        else

            return false;

        
    }



    // コルーチン本体
    private IEnumerator DelayoSetflg()
    {
        PlayerAnim.AnimationAllReset();
        bDid = true;
        // ～秒間待つ
        yield return new WaitForSeconds((float)director.duration);

        //Debug.Log(director.duration);
        playerMove.SetMoveFlg(true);
        

        director = null;
        
        yield break;
    }
}

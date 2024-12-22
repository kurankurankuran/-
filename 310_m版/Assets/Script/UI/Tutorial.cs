/**
* @file Tutorial.cs
* @brief Tutorial�N���X�̎���
* @author �q�@�a�K
* @date 5/5
*
* @details 
* @note 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


/** �N���X�̊T�v���� */
/**
* �@�\�F
* �E���O�ɒ萔�Őݒ肳�ꂽ�`���[�g���A��(TimeLine)���Đ�����
* �E�Đ����̓v���C���[�̃A�j���[�V������wate��ԂɂȂ�
* 
* �g����:
* �P ��̃I�u�W�F�N�g�ɃA�^�b�`
*  2 PlayTutorial(�Đ��������`���[�g���A���萔)���Đ��������^�C�~���O�̃X�N���v�g���Ŏg�p
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

        // director�ɂ͕K���������璆�g�����Ă���
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

                // �R���[�`���̋N��
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

    //! TimeLine���N�����Ă����True��Ԃ�
    public static bool IsDoing()
    {
        if (director != null)
            return 0 < director.time && director.time <= director.duration;
        else

            return false;

        
    }



    // �R���[�`���{��
    private IEnumerator DelayoSetflg()
    {
        PlayerAnim.AnimationAllReset();
        bDid = true;
        // �`�b�ԑ҂�
        yield return new WaitForSeconds((float)director.duration);

        //Debug.Log(director.duration);
        playerMove.SetMoveFlg(true);
        

        director = null;
        
        yield break;
    }
}

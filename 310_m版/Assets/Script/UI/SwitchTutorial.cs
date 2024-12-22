/**
* @file SwitchTutorial.cs
* @brief  SwitchTutorial�N���X�̎���
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
using UnityEngine.Timeline;


/** �N���X�̊T�v���� */
/**
* �@�\�F
* �E�o��/���ł��J��Ԃ��I�u�W�F�N�g�̃`���[�g���A���Đ��p
* �g����:
* �P�@���̃X�N���v�g���A�^�b�`���ꂽ�I�u�W�F�N�g�Ƀv���C���[��������ƃ`���[�g���A�����Đ������B
*/
public class SwitchTutorial : MonoBehaviour
{
    private PlayableDirector director;
    private TrackAsset track;
    // �`���[�g���A���Đ��ł��邩
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

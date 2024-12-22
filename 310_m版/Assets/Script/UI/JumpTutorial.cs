/**
* @file JumpTutorial.cs
* @brief  JumpTutorial�N���X�̎���
* @author �q�@�a�K
* @date 5/29
*
* @details 
* @note 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/** �N���X�̊T�v���� */
/**
* �@�\�F
* �E��Ԓ��˂鏰�I�u�W�F�N�g�̃`���[�g���A���Đ��p
* �g����:
* �P�@���̃X�N���v�g���A�^�b�`���ꂽ�I�u�W�F�N�g�Ƀv���C���[��������ƃ`���[�g���A�����Đ������B
*/
public class JumpTutorial : MonoBehaviour
{

    // �`���[�g���A���Đ��ł��邩
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

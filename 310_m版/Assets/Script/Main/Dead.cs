/**
* @file Dead.cs
* @brief Dead�N���X�̎���
* @author �q�@�a�K
* @date 5/5
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
* �E�P�v���C���[��������Ǝ��S�t���O�𗧂Ă�
* �g����:
* �P�@�I�u�W�F�N�g�ɃA�^�b�`
*/


public class Dead : MonoBehaviour
{

    //�����蔻�茟��
    private void OnTriggerEnter(Collider other)
    {
        //�v���C���[�̎�
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("AudioController").GetComponent<GAudio>().OverSEPlay();

            DeadShow.DanChu = true;


        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

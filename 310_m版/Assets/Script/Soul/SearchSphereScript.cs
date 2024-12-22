/**
* @file SearchSphereScript.cs
* @brief SearchSphereScript�N���X�̎���
* @author �q�@�a�K
* @date 5/5
*
* @details 
* @note 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �v���C���[�ǐ՗p�T����
/** �N���X�̊T�v���� */
/**
* �@�\�F
* �E�A�^�b�`���ꂽ�I�u�W�F�N�g�Ƀv���C���[���������DarkSoul��ǔ���Ԃɂ���
* 
* �g����:
* �P�@�T���͈͂ɂ������I�u�W�F�N�g�ɃA�^�b�`����
*/


public class SearchSphereScript : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            transform.parent.GetComponent<DarkSoulScript>().Horming = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            transform.parent.GetComponent<DarkSoulScript>().Horming = false;
        }
    }
}

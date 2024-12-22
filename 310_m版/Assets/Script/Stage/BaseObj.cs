/**
* @file BaseObj.cs
* @brief BaseObj�N���X�̎���
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
* �\�E����������Ƃ��̒n�_�ɋA�҂���
*/
public class BaseObj : MonoBehaviour
{
    
    [Header("Soul�I�u�W�F�N�g��D&D")]
    [SerializeField]
    GameObject SoulObj;


    [Header("���E���f�t���O(ture�ł��̐�)")]
    [SerializeField]

    //! ���g�����鐢�E�𔻒f
    private bool bThisorThat = true;

    private void OnValidate()
    {
        transform.position = SoulObj.transform.position;
    }

    private void Awake()
    {
        transform.position = SoulObj.transform.position;
    }

    public bool GetThisorflg()
    {
        return bThisorThat;
    }
    
}

/**
* @file StageMove.cs
* @brief StageMove�N���X�̎���
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
* �X�e�[�W�S�̂̐e�I�u�W�F�N�g����͕����ɉ�]������
*/
public class StageMove : MonoBehaviour
{
    private PlayerMove PlayerMoveScript;

    

    // Start is called before the first frame update
    void Start()
    {
        PlayerMoveScript = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    PlayerMoveScript.CirCleMove(transform);
    //}
    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMoveScript.CirCleMove(transform);
    }

    // ��������p�[�e�B�N���p�֐�
    public void SetPlayerMove()
    {
       
        PlayerMoveScript = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
    }
}

/**
* @file AbilityType.cs
* @brief AbilityType�N���X�̎���
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
* �E�v���C���[���G���ƃv���C���[�X�e�[�^�X��ύX����B
* 
* �g����:
* �P�@�I�u�W�F�N�g�ɃA�^�b�`����
*/

public class AbilityType : MonoBehaviour
{
    public enum TYPE
    {
        NONE_TYPE = 0,
        SPEED_TYPE,
        JUMP_TYPE,

        MAX_TYPE
    }

    public TYPE TypeNum { get; set; }

    private PlayerMove playerMove;
    private TestJump testJump;

    // �A�r���e�B��t�^�ł��邩�ǂ���
    public bool bAbility { get; set; }

    private float defValue;

    // Start is called before the first frame update
    void Start()
    {
        TypeNum = TYPE.NONE_TYPE;

        bAbility = true;
        playerMove = GetComponent<PlayerMove>();
        testJump = GetComponent<TestJump>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bAbility)
        {
            switch (TypeNum)
            {
                case TYPE.NONE_TYPE:
                    // �������Ȃ�

                    break;

                case TYPE.SPEED_TYPE:
                    defValue = playerMove.RotSpeed;
                    playerMove.RotSpeed = 0.2f;

                    bAbility = false;
                    break;

                case TYPE.JUMP_TYPE:
                    defValue = testJump.JumpPower;
                    testJump.JumpPower = 3000;

                    bAbility = false;
                    break;
            }      
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Gage")
        {
            switch (TypeNum)
            {
                case TYPE.NONE_TYPE:
                    // �������Ȃ�

                    break;

                case TYPE.SPEED_TYPE:
                    TypeNum = TYPE.NONE_TYPE;
                    playerMove.RotSpeed = defValue;
                    bAbility = true;
                    break;

                case TYPE.JUMP_TYPE:
                    TypeNum = TYPE.NONE_TYPE;
                    testJump.JumpPower = defValue;
                    bAbility = true;
                    break;
            }
        }
    }
}

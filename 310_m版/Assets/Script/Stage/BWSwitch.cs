////**************************************************************:
//// �@�\�F
//// �EbBWSwitch�̐ؑ�
//// �E���̃X�N���v�g��bBWSwitch���Q�Ƃ��āA2�ʐ������I�u�W�F�N�g�̐������؂�ւ��
////***************************************************************
//// �g����
////
//// ���ɂȂ�
//// �e�I�u�W�F�N�g��distortion�X�N���v�g���A�^�b�`����Ύ����I�ɕt�^����A�l�̑���Ȃǂ�distortion�X�N���v�g�ōs��
////****************************************************************
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class BWSwitch : MonoBehaviour
//{
//    // 2�ʐ������I�u�W�F�N�g�̐�����؂�ւ���t���O 
//    // ��]���̉�]�ɂ��؂�ւ��
//    public bool bBWSwich;

//    // �؂�ւ��鎞�ԁA��]����90����]���邲�Ƃɐ؂�ւ��悤�����ς�
//    private float nSwitchTime;

//    // �ؑ֎��ԕۑ��p
//    float nDefSwitchTime;

//    // �X�N���v�g�ۑ��p 
//    private distortion DistScript;
//    // �X�N���v�g�ۑ��p 
//    private RotObj RotObjScript;

    
//    // Start is called before the first frame update
//    void Start()
//    {
//        // �X�N���v�g�擾
//        RotObjScript = transform.GetComponent<RotObj>();

//        // �X�N���v�g�擾
//        DistScript = transform.parent.GetComponent<distortion>();

//        // ��]����90����]���邲�Ƃɐ؂�ւ��悤����
//        nSwitchTime = 360 / DistScript.RotValue / 4;

//        nDefSwitchTime = nSwitchTime * 2;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (RotObjScript.RotBool)
//        {
//            --nSwitchTime;
            
//            if (nSwitchTime < 0)
//            {
//                bBWSwich = !bBWSwich;
//                nSwitchTime = nDefSwitchTime;
                
//            }
//        }

//    }




//}

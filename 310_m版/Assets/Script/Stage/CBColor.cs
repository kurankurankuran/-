////**************************************************************:
//// �@�\�F
//// �E�����̐F�ؑ�
//// �E���蔲���锲���Ȃ������̕t�^�Ɛؑ�
////***************************************************************
//// �g����
//// �P�@���蔲���锲���Ȃ��̐�������������I�u�W�F�N�g�ɃA�^�b�`
//// �Q�@�C���X�y�N�^�[����l��ݒ�
//// �R�@�ȏ�
////***************************************************************

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class CBColor : MonoBehaviour
//{
//    [Header("���̃I�u�W�F�N�g�������Ă����]���������ɐݒ�")]
//    [SerializeField]
//    private GameObject BW;
 
//    // ���g�̃R���C�_�[�i�[�p�iisTrigger�ؑ֗p�j
//    private Collider m_ObjectWCollider;

//    [Header("����������ݒ�i��(true)�ł��蔲����j")]
//    [SerializeField]
//    private bool bBlack;
    
//    // ��]����BWSwitch�X�N���v�g�i�[�p
//    BWSwitch RodPillar;
   
//    // �O�t���[�����_�̃t���O�i�[�p
//    bool bOldBWSwitch;



//    //Inspector�̓��e���ύX���ꂽ���Ɏ��s
//    private void OnValidate()
//    {
//        // ���g�̃R���C�_�[�擾
//        m_ObjectWCollider = GetComponent<Collider>();

//        // �F�ؑւ�isTrigger�ݒ�
//        if (bBlack)
//        {
//            this.GetComponent<MeshRenderer>().material.color = Color.black;

//            m_ObjectWCollider.isTrigger = true;
//        }
//        else
//        {
//            this.GetComponent<MeshRenderer>().material.color = Color.white;

//            m_ObjectWCollider.isTrigger = false;
//        }


//    }


//    // Start is called before the first frame update
//    void Start()
//    {
//        // ��]����BWSwitch�擾
//        RodPillar = BW.GetComponent<BWSwitch>();

//        // �t���O�ۑ�
//        bOldBWSwitch = RodPillar.bBWSwich;

        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // �t���O�؂�ւ�����̂�����
//        if (RodPillar.bBWSwich != bOldBWSwitch)
//        {
//            // isTrigger�ؑ�
//            m_ObjectWCollider.isTrigger = !m_ObjectWCollider.isTrigger;
           
//            // �F�ؑ�
//            if (this.GetComponent<MeshRenderer>().material.color == Color.white)
//            {
//                this.GetComponent<MeshRenderer>().material.color = Color.black;
//            }
//            else
//            {
//                this.GetComponent<MeshRenderer>().material.color = Color.white;
//            }
//        }

//        // �t���O�ۑ�
//        bOldBWSwitch = RodPillar.bBWSwich;
//    }


//}


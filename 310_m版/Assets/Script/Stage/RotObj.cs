/**
* @file RotObj.cs
* @brief RotObj�N���X�̎���
* @author �q�@�a�K
* @date 5/5
*
* @details 
* @note 
*/

//**************************************************************:
// �@�\�F
// �E��]���ɐG��Ă���I�u�W�F�N�g�����ɉ�]�A�ړ�������
//***************************************************************
// �g����
//
// ���ɂȂ�
// �e�I�u�W�F�N�g��distortion�X�N���v�g���A�^�b�`����Ύ����I�ɕt�^����A�l�̑���Ȃǂ�distortion�X�N���v�g�ōs��
//****************************************************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/** �N���X�̊T�v���� */
/**
* ������]���Ă��邩�ǂ����𔻒f���邾���̃N���X
*/

public class RotObj : MonoBehaviour
{
    //// ���ꂼ��̉�]���ɐG�ꂽ�I�u�W�F�N�g���i�[����List
    //private List<GameObject> objList = new List<GameObject>();

    // �X�N���v�g�i�[�p
    private distortion DistScript;

    // ��]���邩�ǂ����t���O�i�e�I�u�W�F�N�g�ŕύX���Ă���j
    public bool RotBool;

    // �e��transform�i�[�p
    Transform parentTransform;

    Color myColor;

    private void Awake()
    {
        RotBool = false;

        // �e��transform�擾
        parentTransform = transform.parent.gameObject.transform;

        
    }

    // Start is called before the first frame update
    void Start()
    {
        //myColor = GetComponent<Color>();
        //myColor.a = 0.5f;
        //GetComponent<Renderer>().material.color = myColor;

        // �e�̃X�N���v�g�擾
        DistScript = transform.parent.gameObject.GetComponent<distortion>();
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //    for (int i = 0; i < objList.Count; ++i)
    //    {
    //        // List�̗v�f��NULL�̏ꍇList����폜
    //        if (objList[i] == null)
    //        {
    //            objList.Remove(objList[i]);
    //            continue;
    //        }

    //        // ��]���ɐG��Ă���I�u�W�F�N�g����͕����Ɉړ������鏈��
    //        //float x = Input.GetAxis("Horizontal") * DistScript.RotSpeed;
    //        //objList[i].transform.RotateAround(parentTransform.position, parentTransform.up, -x);
    //    }

    //    //if (RotBool)
    //    //{
    //    //    for (int i = 0; i < objList.Count; ++i)
    //    //    {
    //    //        // ��]���ɐG��Ă���I�u�W�F�N�g����]���ƂƂ��ɉ�]�����鏈��
    //    //        objList[i].transform.RotateAround(transform.position, transform.right, DistScript.RotValue);
                
               
    //    //    }
    //    //}
        
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    // �v���C���[�͉�]���ƂƂ��ɉ�]���Ȃ�
    //    if (other.gameObject.tag != "Player")
    //    {
    //        // ����List���ɓ����I�u�W�F�N�g���L���List�ɒǉ����Ȃ�
    //        if (objList.FindIndex(n => n.name == other.name) < 0)
    //        {
    //            // List�ɃI�u�W�F�N�g��ǉ�
    //            objList.Add(other.gameObject);

                
    //        }
            
           
    //    }
    //}
   
}

/**
* @file DSGenerater.cs
* @brief DSGenerater�N���X�̎���
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
* �E�˂���ɂ���ăI�u�W�F�N�g�𐶐�����
* �g����:
* �P �I�u�W�F�N�g�ɃA�^�b�`����
* 2 �C���X�y�N�^�[�ɐ����������I�u�W�F�N�g��D&D
*/
public class DSGenerater : MonoBehaviour
{
    [SerializeField] public GameObject DsObject;

    [Header("�ŏ����琶������Ă��邩�ǂ���")]
    [SerializeField]
    private bool bGenerate = true;
   
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Gage")
        {
            if (bGenerate/*transform.childCount <= 0*/)
            {
                
                bGenerate = false;

                GameObject Ds = Instantiate(DsObject, this.transform.position, Quaternion.identity); //�Q�[���I�u�W�F�N�g����

                Ds.transform.rotation = transform.rotation;
                Ds.transform.parent = this.transform.parent;
                


                foreach (Transform childTransform in Ds.transform)
                {
                    childTransform.GetComponent<DarkSoulScript>().SetPlayer(GameObject.FindGameObjectWithTag("Player"));

                    break;
                }
               

               
            }
            else
            {
                bGenerate = true;
            }
        }
    }
}

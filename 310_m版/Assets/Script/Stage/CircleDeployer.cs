/**
* @file CircleDeployer.cs
* @brief CircleDeployer�N���X�̎���
* @author �q�@�a�K
* @date 5/5
*
* @details 
* @note 
*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/** �N���X�̊T�v���� */
/**
* �q�ɂ���I�u�W�F�N�g���~��ɔz�u����N���X
*/

public class CircleDeployer : MonoBehaviour
{

    //���a
    [SerializeField]
    public float _radius;

    //=================================================================================
    //������
    //=================================================================================

    private void Awake()
    {
        Deploy();
    }

    //Inspector�̓��e(���a)���ύX���ꂽ���Ɏ��s
    private void OnValidate()
    {
        Deploy();
    }

    //�q���~��ɔz�u����(ContextMenu�Ō��}�[�N�̏��Ƀ��j���[�ǉ�)
    [ContextMenu("Deploy")]
    private void Deploy()
    {

        //�q���擾
        List<GameObject> childList = new List<GameObject>();
        foreach (Transform child in transform)
        {
            bool bSkip = false;
            for (int i = 0; i < childList.Count; ++i)
            {
                if (childList[i].gameObject.name == child.gameObject.name)
                {
                    bSkip = true;
                }
            }

            if (!bSkip)
            {
                childList.Add(child.gameObject);
            }
        }

        //���l�A�A���t�@�x�b�g���Ƀ\�[�g
        childList.Sort(
          (a, b) => {
              return string.Compare(a.name, b.name);
          }
        );

        //�I�u�W�F�N�g�Ԃ̊p�x��
        float angleDiff = 360f / (float)childList.Count;


        //�e�I�u�W�F�N�g���~��ɔz�u
        for (int i = 0; i < childList.Count; i++)
        {
         
            
            childList[i].transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
            childList[i].transform.Rotate(transform.up, i * angleDiff);

            //if (childList[i].tag == "Screen")
            //{
            //    childList[i].transform.Rotate(transform.right, -90);
            //}
            //if (childList[i].tag == "ThatScreen")
            //{
            //    childList[i].transform.Rotate(transform.right, 90);
            //}


            Vector3 childPostion = transform.position;

            float angle = (90 - angleDiff * i) * Mathf.Deg2Rad;
            childPostion.x += _radius * Mathf.Cos(angle);
            childPostion.z += _radius * Mathf.Sin(angle);

            childList[i].transform.position = childPostion;

           
        }

    }

}
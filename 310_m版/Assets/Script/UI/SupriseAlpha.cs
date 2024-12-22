/**
* @file SupriseAlpha.cs
* @brief SupriseAlpha�N���X�̎���
* @author �q�@�a�K
* @date 5/27
*
* @details 
* @note 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ���䌳�X�N���v�g
using static ImageExt;


/** �N���X�̊T�v���� */
/**
* �@�\�F
* �E�摜��h�炷
* 
* �g����:
* �P�@��]�����q�I�u�W�F�N�g�Ƃ���e�I�u�W�F�N�g�ɃA�^�b�`����
* �Q�@�C���X�y�N�^�[���炻�ꂼ��̒l������
* �R�@�ȏ�
*/



public class SupriseAlpha : MonoBehaviour
{
    [SerializeField]
    Image image;

    public UIShake shake;

    //[Header("Alpha�P�ł̕\������")]
    //[SerializeField]
    private float DispTime = 500.0f;
    private float DispCount = 0.1f;

    private bool bUp = false;

    // Start is called before the first frame update
    void Start()
    {
        image.SetOpacity(0.0f);
        //// GameObject�̎擾
        //GameObject target = GameObject.Find("Target");
        // Image�̎擾
        //image = target.GetComponent<Image>();
        // 0=���� 1=�s�����Ȃ̂ŁA1.0�Ŋ��S�ɕs�����ɂȂ�
        //image.SetOpacity(1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (bUp)
        {
           
            image.SetOpacity(image.GetOpacity() + 0.2f);
            if (1.0f <= image.GetOpacity())
            {
                bUp = false;
            }
        }
        else if (image.GetOpacity() >= 1.0f && DispCount < DispTime) 
        {
            DispCount += 0.1f;

        }
        else if(DispCount >= DispTime)
        {
            image.SetOpacity(image.GetOpacity() - 0.01f);

            if (image.GetOpacity() <= 0) 
            {
                DispCount = 0;
            }
        }

    }

    public void AlphaUpDown(float Count)
    {
        DispTime = Count;
        bUp = true;
        
        shake.Shake(1000.0f, 0.05f);


    }



}

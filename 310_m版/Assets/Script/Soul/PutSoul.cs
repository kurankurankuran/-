/**
* @file PutSoul.cs
* @brief PutSoul�N���X�̎���
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
* �E�v���C���[��������������ԂŃA�^�b�`���ꂽ�I�u�W�F�ɂ�����ƍ��������ɒu���ꂽ��Ԃɂ���
* �g����:
* �P�@�S�[���ڕW�ɂ������I�u�W�F�N�g�ɃA�^�b�`
*/

public class PutSoul : MonoBehaviour
{
   
    [SerializeField]
    public GameObject Soul;

    [Header("����������ݒ�itrue�ōŏ��͎��̂����j")]
    [SerializeField]
    private bool bTouch;

    private DisCharge_Generate_Effect DisEffect;

    private void OnValidate()
    {
        //GetComponent<Renderer>().material.color = Soul.GetComponent<Renderer>().material.color;

        // �F�ؑւƐG���ݒ�
        if (bTouch)
        {
            //GetComponent<Renderer>().material.color = new Color(
            //         GetComponent<Renderer>().material.color.r,
            //         GetComponent<Renderer>().material.color.g,
            //         GetComponent<Renderer>().material.color.b
            //         , 1.0f);

        }
        else
        {
            //GetComponent<Renderer>().material.color = new Color(
            //        GetComponent<Renderer>().material.color.r,
            //        GetComponent<Renderer>().material.color.g,
            //        GetComponent<Renderer>().material.color.b
            //        , 0.1f);

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        DisEffect = GetComponent<DisCharge_Generate_Effect>();

        //GetComponent<Renderer>().material.color = Soul.GetComponent<Renderer>().material.color;

        // �F�ؑւƐG���ݒ�
        if (bTouch)
        {
            //GetComponent<Renderer>().material.color = new Color(
            //         GetComponent<Renderer>().material.color.r,
            //         GetComponent<Renderer>().material.color.g,
            //         GetComponent<Renderer>().material.color.b
            //         , 1.0f);

        }
        else
        {
            //GetComponent<Renderer>().material.color = new Color(
            //        GetComponent<Renderer>().material.color.r,
            //        GetComponent<Renderer>().material.color.g,
            //        GetComponent<Renderer>().material.color.b
            //        , 0.1f);

        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        //if (bTouch)
        //{
        if (other.tag == "Player" || other.tag == "PlayerLR") 
        {
            if (Soul.GetComponent<Soul>().bRot)
            {
                if (Soul.GetComponent<Soul>().transform.name == "Soul")
                {
                    GameObject.Find("SoullconPanel").GetComponent<SoulScore>().ScaleON1();
                }
                else if(Soul.GetComponent<Soul>().transform.name == "Soul (1)")
                {
                    GameObject.Find("SoullconPanel").GetComponent<SoulScore>().ScaleON2();
                }
                else if(Soul.GetComponent<Soul>().transform.name == "Soul (2)")
                {
                    GameObject.Find("SoullconPanel").GetComponent<SoulScore>().ScaleON3();
                }



                Soul.GetComponent<Soul>().bRot = false;
                Soul.GetComponent<Soul>().bPut = true;

                DisEffect.Generate_Effect();



                GameObject.Find("AudioController").GetComponent<GAudio>().HPBarSEStop();

                GameObject.Find("Souls").GetComponent<SoulCnt>().DelSoul();

                Soul.transform.position = transform.position;

                Soul.transform.parent = transform;
                
            }
        }
        //}
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Gage")
        {

            bTouch = !bTouch;
            // �����x�ؑ�
            if (bTouch)
            {

                //GetComponent<Renderer>().material.color = new Color(
                //   GetComponent<Renderer>().material.color.r,
                //   GetComponent<Renderer>().material.color.g,
                //   GetComponent<Renderer>().material.color.b
                //   , 1.0f);


            }
            else
            {

                //GetComponent<Renderer>().material.color = new Color(
                //     GetComponent<Renderer>().material.color.r,
                //     GetComponent<Renderer>().material.color.g,
                //     GetComponent<Renderer>().material.color.b
                //     , 0.3f);


            }
        }

    }
}

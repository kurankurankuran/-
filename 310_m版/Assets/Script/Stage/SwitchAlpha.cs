/**
* @file SwitchAlpha.cs
* @brief SwitchAlpha�N���X�̎���
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
* �I�u�W�F�N�g���˂���ɂ���ē����A�s�����ɐ؂�ւ���
* 
* �g�����F
* �P�@���蔲���锲���Ȃ��̐�������������I�u�W�F�N�g�ɃA�^�b�`
* �Q�@�C���X�y�N�^�[����l��ݒ�
*/
public class SwitchAlpha : MonoBehaviour
{
   

    // ���g�̃R���C�_�[�i�[�p�iisTrigger�ؑ֗p�j
    private Collider m_ObjectWCollider;

    [Header("����������ݒ�itrue�ōŏ��͎��̂����j")]
    [SerializeField]
    private bool bInstance;

    

    GroundChecker GroundCheckerScript;

    private int EntetFoot;

    TestJump PlayerJump;

    // ���g�̃��b�V�������_���[�擾
    MeshRenderer myMeshRendere;

    //Inspector�̓��e���ύX���ꂽ���Ɏ��s
    private void OnValidate()
    {
        myMeshRendere = GetComponent<MeshRenderer>();

        // ���g�̃R���C�_�[�擾
        m_ObjectWCollider = GetComponent<Collider>();
     
        // �\���ؑւ�isTrigger�ݒ�
        if (bInstance)
        {
            myMeshRendere.enabled = true;
            //GetComponent<Renderer>().material.color = new Color(
            //         GetComponent<Renderer>().material.color.r,
            //         GetComponent<Renderer>().material.color.g,
            //         GetComponent<Renderer>().material.color.b
            //         , 1.0f);


            m_ObjectWCollider.isTrigger = false;
        
        }
        else
        {
            myMeshRendere.enabled = false;

            //GetComponent<Renderer>().material.color = new Color(
            //        GetComponent<Renderer>().material.color.r,
            //        GetComponent<Renderer>().material.color.g,
            //        GetComponent<Renderer>().material.color.b
            //        , 0.3f);

            m_ObjectWCollider.isTrigger = true;
          
        }


    }


    // Start is called before the first frame update
    void Start()
    {
        myMeshRendere = GetComponent<MeshRenderer>();

        EntetFoot = 0;

        GroundCheckerScript = GameObject.FindGameObjectWithTag("Foot").GetComponent<GroundChecker>();
        PlayerJump = GameObject.FindGameObjectWithTag("Player").GetComponent<TestJump>();

        // ���g�̃R���C�_�[�擾
        m_ObjectWCollider = GetComponent<Collider>();

        // �\���ؑւ�isTrigger�ݒ�
        if (bInstance)
        {
            myMeshRendere.enabled = true;

            //GetComponent<Renderer>().material.color = new Color(
            //         GetComponent<Renderer>().material.color.r,
            //         GetComponent<Renderer>().material.color.g,
            //         GetComponent<Renderer>().material.color.b
            //         , 1.0f);
            

            m_ObjectWCollider.isTrigger = false;
            
        }
        else
        {
            myMeshRendere.enabled = false;

            //GetComponent<Renderer>().material.color = new Color(
            //        GetComponent<Renderer>().material.color.r,
            //        GetComponent<Renderer>().material.color.g,
            //        GetComponent<Renderer>().material.color.b
            //        , 0.3f);
            

            m_ObjectWCollider.isTrigger = true;
          
        }

      
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Foot") 
        {
            EntetFoot--;
        }

        if (other.gameObject.tag == "Gage")
        {
            if (EntetFoot == 1)
            {
                if (!m_ObjectWCollider.isTrigger)
                {
                    GroundCheckerScript.DelentetNum();
                    if (GroundCheckerScript.GetEnterNum() <= 0)
                    {
                        PlayerJump.PlayerFall();
                        GroundCheckerScript.OnExitGround.Invoke();
                    }
                }
                else
                {
                    GroundCheckerScript.PlusentetNum();
                    if (GroundCheckerScript.GetEnterNum() > 0)
                    {
                        
                        GroundCheckerScript.OnEnterGround.Invoke();
                    }
                }
            }
           

            // isTrigger�ؑ�
            m_ObjectWCollider.isTrigger = !m_ObjectWCollider.isTrigger;

            

            // �����x�ؑ�
            if (m_ObjectWCollider.isTrigger)
            {
                myMeshRendere.enabled = false;
                //GetComponent<Renderer>().material.color = new Color(
                //   GetComponent<Renderer>().material.color.r,
                //   GetComponent<Renderer>().material.color.g,
                //   GetComponent<Renderer>().material.color.b
                //   , 0.3f);

            }
            else
            {
                myMeshRendere.enabled = true;
                //GetComponent<Renderer>().material.color = new Color(
                //     GetComponent<Renderer>().material.color.r,
                //     GetComponent<Renderer>().material.color.g,
                //     GetComponent<Renderer>().material.color.b
                //     , 1.0f);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Foot")
        {
            if (EntetFoot <= 0)
            {
                EntetFoot++;
            }
        }
    }
    
}


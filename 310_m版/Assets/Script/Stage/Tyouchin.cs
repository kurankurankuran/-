/**
* @file Tyouchin.cs
* @brief Tyouchin�N���X�̎���
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
* �G��ė�͏���Ŏ��̉�����
*/
public class Tyouchin : MonoBehaviour
{

    // �G��Ă���t���O
    private bool bTouchi;

    [Header("���ʔ����܂ł̗v�`���[�W����")]
    [SerializeField]
    private int ChargeTime;

    [Header("���̉����Ă��鎞��")]
    [SerializeField]
    private int InsTime;

    [Header("������")]
    [SerializeField]
    private int Cost;


    // �`���[�W���ԃJ�E���g
    private int ChargeCnt;

    // ���̉����ԃJ�E���g
    private int InsCnt;


    //// �����͓���
    //private bool bInstance;

    // ���g�̃R���C�_�[�i�[�p�iisTrigger�ؑ֗p�j
    private Collider m_ObjectWCollider;

    private PlayerStatus PlayerStatusScript;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStatusScript = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
        // ���g�̃R���C�_�[�擾
        m_ObjectWCollider = GetComponent<Collider>();

        bTouchi = false;
        ChargeCnt = 0;
        InsCnt = 0;
        //bInstance = false;

        GetComponent<Renderer>().material.color = new Color(
                    GetComponent<Renderer>().material.color.r,
                    GetComponent<Renderer>().material.color.g,
                    GetComponent<Renderer>().material.color.b
                    , 0.3f);
        
        m_ObjectWCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(bTouchi)
        {
            if (Input.GetKey("k"))
            {
                if (PlayerStatusScript.GetHp() > 0)
                {
                    ChargeCnt++;
                    if (InsCnt > 0)
                    {
                        if (!m_ObjectWCollider.isTrigger)
                        {
                            ChargeCnt--;
                            PlayerStatusScript.SetHp(PlayerStatusScript.GetHp() - 1);
                            InsCnt--;
                            Debug.Log(InsCnt);
                        }
                    }
                }
                
               
   
                if (ChargeTime < ChargeCnt)
                {
                    if (PlayerStatusScript.GetHp() > Cost && m_ObjectWCollider.isTrigger)
                        
                    {
                        PlayerStatusScript.SetHp(PlayerStatusScript.GetHp() - Cost);

                        ChargeCnt = 0;

                        GetComponent<Renderer>().material.color = new Color(
                       GetComponent<Renderer>().material.color.r,
                       GetComponent<Renderer>().material.color.g,
                       GetComponent<Renderer>().material.color.b
                       , 1.0f);

                        m_ObjectWCollider.isTrigger = false;

                    }
                    else if(!m_ObjectWCollider.isTrigger)
                    {
                        ChargeCnt = 0;
                    }
                }
                
            }
        }


        if (!m_ObjectWCollider.isTrigger)
        {
            InsCnt++;
            if (InsCnt > InsTime) 
            {
                GetComponent<Renderer>().material.color = new Color(
                GetComponent<Renderer>().material.color.r,
                GetComponent<Renderer>().material.color.g,
                GetComponent<Renderer>().material.color.b
                , 0.3f);

                m_ObjectWCollider.isTrigger = true;

                InsCnt = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("�G��Ă���");
            bTouchi = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("���ꂽ");
            bTouchi = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("�G��Ă���");
            bTouchi = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("���ꂽ");
            bTouchi = false;
        }
    }
}

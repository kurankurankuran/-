/**
* @file SkyRantan.cs
* @brief SkyRantan�N���X�̎���
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
* �G��Ȃ����͏���ŖړI�n�܂Ŏ����œ�������
*/
public class SkyRantan : MonoBehaviour
{
    // �G��Ă���t���O
    private bool bTouchi;
    // �v���C���[�̋r���G��Ă���t���O
    private bool bTouchiFoot;

    // ���ł���t���O
    private bool bSky;

    [Header("���ʔ����܂ł̗v�`���[�W����")]
    [SerializeField]
    private int ChargeTime;

    [Header("��������")]
    [SerializeField]
    private int InsTime;

    [Header("�ړI�n�ɒ����Ă���̑ҋ@����")]
    [SerializeField]
    private int breakTime;

    [Header("������")]
    [SerializeField]
    private int Cost;

    [Header("�ړ���X")]
    [SerializeField]
    private float moveX;

    [Header("�ړ���Y")]
    [SerializeField]
    private float moveY;

    [Header("StageObject��D��D")]
    [SerializeField]
    private GameObject StageObj;

    [Header("Player��D��D")]
    [SerializeField]
    private GameObject Player;



    // �`���[�W���ԃJ�E���g
    private int ChargeCnt;

    // ���̉����ԃJ�E���g
    private int InsCnt;


    //// �����͓���
    //private bool bInstance;
    
    private PlayerStatus PlayerStatusScript;

    private CRGenerate_Effect EffectPlay;

    // Start is called before the first frame update
    void Start()
    {
        EffectPlay = GetComponent<CRGenerate_Effect>();
        
        PlayerStatusScript = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();

        bSky = false;
        bTouchi = false;
        ChargeCnt = 0;
        InsCnt = 0;
        bTouchiFoot = false;
        //bInstance = false;

     
    }

    // Update is called once per frame
    void Update()
    {
        if (bTouchi)
        {
            if (Input.GetKey("k"))
            {
                if (PlayerStatusScript.GetHp() > 0)
                {
                    ChargeCnt++;
                    //if (InsCnt > 0)
                    //{
                    //    if (!m_ObjectWCollider.isTrigger)
                    //    {
                    //        ChargeCnt--;
                    //        PlayerStatusScript.SetHp(PlayerStatusScript.GetHp() - 1);
                    //        InsCnt--;
                    //        Debug.Log(InsCnt);
                    //    }
                    //}
                }



                if (ChargeTime < ChargeCnt)
                {
                    if (PlayerStatusScript.GetHp() > Cost && !bSky)

                    {
                        PlayerStatusScript.SetHp(PlayerStatusScript.GetHp() - Cost);

                        ChargeCnt = 0;

                        bSky = true;

                        EffectPlay.DestroyParticle();

                        //transform.position = new Vector3(,)

                    }
                    else if (!bSky)
                    {
                        ChargeCnt = 0;
                    }
                }

            }
        }


        if (bSky)
        {
            if (InsCnt == 0) 
            {
                EffectPlay.GenerateParticle();
            }


            InsCnt++;

           

            if (InsCnt < InsTime)
            {
                
                // �ړI�n�܂œ���

                transform.position = new Vector3(transform.position.x, transform.position.y + moveY, transform.position.z);
                transform.RotateAround(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), -moveX);

                if (bTouchiFoot)
                {
                    Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + moveY, Player.transform.position.z);
                    StageObj.transform.RotateAround(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), moveX);
                }
            }
            else if(InsCnt < InsTime + breakTime)
            {
                // ���̏�őҋ@����
            }
            else if(InsCnt < InsTime * 2 + breakTime)
            {
                // �ړI�n����A���Ă���

                transform.position = new Vector3(transform.position.x, transform.position.y - moveY, transform.position.z);
                transform.RotateAround(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), moveX);

                if (bTouchiFoot)
                {
                    Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - moveY, Player.transform.position.z);
                    StageObj.transform.RotateAround(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), -moveX);
                }
            }
            else if (InsCnt >= InsTime * 2 + breakTime)
            {
                bSky = false;

                InsCnt = 0;
            }

            //if (InsCnt > InsTime)
            //{
            //    bSky = false;

            //    InsCnt = 0;
            //}
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Foot")
        {
            Debug.Log("�r�ɐG��Ă���");
            bTouchiFoot = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Foot")
        {
            Debug.Log("�r�����ꂽ");
            bTouchiFoot = false;
        }
    }

}

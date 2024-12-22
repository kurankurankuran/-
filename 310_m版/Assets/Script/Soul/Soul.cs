

/**
* @file Soul.cs
* @brief Soul�N���X�̎���
* @author �q�@�a�K
* @date 5/5
*
* @details 
* @note 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/** �N���X�̊T�v���� */
/**
* �@�\�F
* �E�v���C���[�ɂ�����ƃv���C���[�̎������]���n�߂�
* �E�v���C���[�̃X�e�[�^�X���Q�Ƃ��ė�̓Q�[�W���O�ɂȂ�Ƃ�������㏸���Ă��猳�ʒu�ɖ߂�
* 
* �g����:
* �P�@������^�������I�u�W�F�N�g�ɃA�^�b�`����
*/

public class Soul : MonoBehaviour
{
   
    SupriseAlpha supriseAlpha;

    [Header("�����Ă��猳�̏ꏊ�ɖ߂�܂ł̎���")]
    [SerializeField] private float waitTime = 5;

    [Header("�����Ă���̏㏸���x")]
    [SerializeField] private float upValue = 0.5f;

    [Header("�v���C���[�ێ����G�t�F�N�g")]
    [SerializeField] private GameObject particleObject1;

    [Header("�����Ă���Œ��G�t�F�N�g")]
    [SerializeField] private GameObject particleObject2;


    [Header("����������ݒ�itrue�ōŏ��͎��̂����j")]
    [SerializeField]
    public bool bTouch;
    //private bool bInstance;

    [Header("�A�N�e�B�u��؂�ւ���I�u�W�F�N�g1")]
    [SerializeField]
    private GameObject Particle1;

    [Header("�A�N�e�B�u��؂�ւ���I�u�W�F�N�g2")]
    [SerializeField]
    private GameObject Particle2;



    //�@���񂷂�^�[�Q�b�g
    private Transform target;
    //�@���݂̊p�x
    private float angle;

    [HideInInspector]
    public bool bRot;
    [HideInInspector]
    public bool bPut;
    [HideInInspector]
    public bool bEscape;

    private bool bReturn;
  
    // ���g�̃R���C�_�[�i�[�p�iisTrigger�ؑ֗p�j
    private Collider m_ObjectWCollider;

    // �����ʒu�ۑ�
    Transform DefTransform;
   
    private PlayerMove PlayerMoveScript;

    Vector3 PtoS;

    private Vector3 CameraForword;

    private void OnValidate()
    {
     

        //// �F�ؑւƐG���ݒ�
        //if (bTouch)
        //{
          
        //    Particle1.SetActive(true);
        //    Particle2.SetActive(true);
        //}
        //else
        //{
        //    Particle1.SetActive(false);
        //    Particle2.SetActive(false);

        //}


    }


    private void Start()
    {
        CameraForword = GameObject.FindWithTag("MainCamera").transform.forward;

        bRot = false;
        bPut = false;
        bEscape = false;
        bReturn = false;

        PlayerMoveScript = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        supriseAlpha = GameObject.FindWithTag("Mark").GetComponent<SupriseAlpha>();
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerMoveScript.CirCleMove(DefTransform);
        if (bRot)
        {

            // ��]�̃N�H�[�^�j�I���쐬
            var angleAxis = Quaternion.AngleAxis(360 / 2 * Time.deltaTime,transform.up/* CameraForword*/);

            // �~�^���̈ʒu�v�Z
            var pos = PtoS;

            pos = angleAxis * pos;

            PtoS = pos;


            //���j�b�g�̈ʒu = �^�[�Q�b�g�̈ʒu �{ �^�[�Q�b�g���猩�����j�b�g�̊p�x �~�@�^�[�Q�b�g����̋���
            if (bReturn)
            {

                PtoS = new Vector3(0.0f, upValue, 0.0f);
                transform.position += /*target.position +*/ PtoS;
            }
            else
            {
                transform.position = target.position + PtoS;
            }

            //transform.position = target.position /*+ PtoS*/;

            // Debug.Log("��]�J�n�I");
            if (target.GetComponent<PlayerStatus>().GetHp() <= 0 || SoulRelease.bRelease) 
            {
                //Debug.Log("Soul�������܂���");
                //GetComponent<ResetPos>().ResetTransform();
                //bRot = false;

                if (!bReturn)
                {
                    GameObject.Find("AudioController").GetComponent<GAudio>().LostSoulSEPlay();
                    //supriseAlpha.AlphaUpDown(30.0f);
                    supriseAlpha/*.GetComponent<SupriseAlpha>()*/.AlphaUpDown(1.0f);

                    bEscape = true;
                    bRot = false;
                    bReturn = true;

                    particleObject1.SetActive(false);
                    particleObject2.SetActive(true);

                    // �R���[�`���̋N��
                    StartCoroutine(DelayCoroutine());

                    
                }
            }
        }

        if(bEscape)
        {
            PtoS = new Vector3(0.0f, upValue, 0.0f);
            transform.position += /*target.position +*/ PtoS;
        }

        if (bPut)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            particleObject1.SetActive(false);
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (!bPut)
        {
            //if (bTouch)
            //{
                if (!bRot)
                {
                    if (!bEscape)
                    {
                        if (other.gameObject.tag == "Player")
                        {



                        PtoS = other.transform.forward/* CameraForword.normalized*/ / 2.0f;

                        PtoS = new Vector3(PtoS.x, PtoS.y + 0.15f, PtoS.z);
                        //PtoS = new Vector3(0.0f, 0.0f, 0.0f);

                        GetComponent<Charge_generated_effect>().PlayEffect();



                        bRot = true;

                        target = other.transform;
                        GameObject.Find("AudioController").GetComponent<GAudio>().SoulGetSEPlay();


                        transform.GetChild(0).gameObject.SetActive(false);


                        particleObject1.SetActive(true);

                        //GameObject Particle = Instantiate(
                        //    particleObject, 
                        //    this.transform.position + new Vector3(0.0f,1.0f,0.0f), 
                        //    Quaternion.identity); //�p�[�e�B�N���p�Q�[���I�u�W�F�N�g����

                        //Particle.transform.parent = this.transform;

                    }
                }
                }
            //}
        }


        //if (!bRot)
        //{
        //    if (!bPut)
        //    {
        //        if (other.tag == "Screen")
        //        {
        //            bTouch = true;
        //            Particle1.SetActive(true);
        //            Particle2.SetActive(true);
        //        }
        //        else if (other.tag == "ThatScreen")
        //        {
        //            bTouch = false;
        //            Particle1.SetActive(false);
        //            Particle2.SetActive(false);
        //        }
        //    }
        //}

    }
    

    // �R���[�`���{��
    private IEnumerator DelayCoroutine()
    {

        // �`�b�ԑ҂�
        yield return new WaitForSeconds(waitTime);

        particleObject2.SetActive(false);
        GetComponent<ResetPos>().ResetTransform();
        transform.GetChild(0).gameObject.SetActive(true);
        
        bReturn = false;
        bEscape = false;

        //bTouch = GetComponent<ResetPos>().GetThisorflg();
    }
}
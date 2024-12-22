/**
* @file DarkSoulScript.cs
* @brief DarkSoulScript�N���X�̎���
* @author �q�@�a�K
* @date 5/5
*
* @details 
* @note 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/** �N���X�̊T�v���� */
/**
* �@�\�F
* �E�v���C���[��ǔ�
* �E������Ɨ�̓Q�[�W���O��
* �E�˂���Ɋ������܂��ƌł܂葫���
* �E����Ɋ������܂��Ə�����
*/
public class DarkSoulScript : MonoBehaviour
{
    [Header("cube��D&D")]
    [SerializeField]
    private GameObject Brock; 

    //[Header("Player��D&D")]
    //[SerializeField]

    //! �v���C���[�I�u�W�F�N�g�i�[�p
    private GameObject Player;
    
    [Header("�_���[�W")]
    [SerializeField]
    private int Damage = 100;

    [Header("�ǐՑ��xX")]
    [SerializeField]
    private float SpeedX = 0.1f;

    private float _SpeedX = 0.0f;

    [Header("�ǐՑ��xY")]
    [SerializeField]
    private float SpeedY = 0.025f;
    private float _SpeedY = 0.0f;

    [Header("�ړ������W��X")]
    [SerializeField]
    private float RotateX = 0.025f;

    [Header("�ړ������W��Y")]
    [SerializeField]
    private float RotateY = 0.025f;


    // ���g�̃��b�V�������_���[�擾
    //MeshRenderer myMeshRendere;

    //! �ǐ�ONOFF
    public bool Horming = false;

    //! CameraShake�X�N���v�g�i�[�p
    private CameraShake Shake;

    //[Header("��������")]
    //[SerializeField]
    //! �ł܂��Ă���t���O
    private bool bSolid = false;

    //! ���g�̃R���C�_�[�i�[�p
    Collider myCollider;


    bool bTouchFoot = false;

   

    // Start is called before the first frame update
    void Start()
    {
        //myMeshRendere = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        GroundChecker groundChecker = GameObject.FindGameObjectWithTag("Foot").GetComponent<GroundChecker>();

        if (Player != null)
        {
            if (!bSolid)
            {

                if (Horming)
                {
                   

                    if (0 < Vector3.SignedAngle(Player.transform.position, transform.position, new Vector3(0.0f, 1.0f, 0.0f)))
                    {
                        _SpeedX -= SpeedX;

                        transform.RotateAround(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), _SpeedX/*-SpeedX*/);
                    }
                    else
                    {
                        _SpeedX += SpeedX;
                        transform.RotateAround(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), _SpeedX/*SpeedX*/);
                    }

                    if (transform.position.y < Player.transform.position.y)
                    {
                        _SpeedY += SpeedY;

                        transform.position = new Vector3(transform.position.x, transform.position.y + _SpeedY/*SpeedY*/, transform.position.z);
                    }
                    else
                    {
                        _SpeedY -= SpeedY;
                        transform.position = new Vector3(transform.position.x, transform.position.y + _SpeedY/*SpeedY*/, transform.position.z);
                    }

                    _SpeedX += (0.0f - _SpeedX) * RotateX;
                    _SpeedY += (0.0f - _SpeedY) * RotateY;
                }
            }
            else
            {

            }
        }
    }
    



    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Gage")
        {
            if (bSolid)
            {
                if (bTouchFoot)
                {
                  
                    GroundChecker groundChecker = GameObject.FindGameObjectWithTag("Foot").GetComponent<GroundChecker>();
                   
                    groundChecker.DelentetNum();
                    if (groundChecker.GetEnterNum() <= 0)
                    {
                        groundChecker.OnExitGround.Invoke();
                    }
                }

                Destroy(this.gameObject.transform.parent.gameObject);
            }
            else
            {

                bSolid = true;
                myCollider.isTrigger = false;

                //myMeshRendere.enabled = false;
                foreach (Transform childTransform in transform)
                {
                    childTransform.gameObject.SetActive(false);

                    break;
                }

                Brock.SetActive(true);

                GetComponent<Changegenerated_effect>().PlayEffect();


            }
        }

        

        if (!bSolid)
        {
            if (other.tag == "Player")
            {
                GameObject.FindGameObjectWithTag("Audio").GetComponent<GAudio>().DamageSE2Play();

                PlayerStatus playerStatus = other.GetComponent<PlayerStatus>();
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>().Shake(5.0f, 0.3f);

                playerStatus.SetHp(playerStatus.GetHp() - Damage);


                Destroy(this.gameObject.transform.parent.gameObject);
            }
        }else if(other.tag == "Foot")
        {
            bTouchFoot = true;
           
        }
       
    }


    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Foot")
        {
            bTouchFoot = false;
        }
    


        //if (other.tag == "Screen")
        //{
        //    if (bSolid)
        //    {
        //        Debug.Log("�j��");
        //        Destroy(this.gameObject.transform.parent.gameObject);
        //    }
        //}

        //if (other.tag == "ThatScreen")
        //{

        //    bSolid = true;
        //    myCollider.isTrigger = false;

        //}
    }

    


    public void SetPlayer(GameObject _Player)
    {

        Player = _Player;

        myCollider = transform.GetComponent<Collider>();

       
    }
}

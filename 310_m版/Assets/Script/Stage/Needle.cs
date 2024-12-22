/**
* @file Needle.cs
* @brief Needle�N���X�̎���
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
* ���g���v���C���[�ɐG���ƃ��X�|�[���n�_�܂Ŗ߂�
*/
public class Needle : MonoBehaviour
{
    //! ���X�|�[���I�u�W�F�N�g�i�[�p
    private GameObject ResPlayerObj;

    //! ���X�|�[���I�u�W�F�N�g�̃g�����X�t�H�[���i�[�p
    private Transform ResTransform;
    
    [Header("Player�X�g�b�v����")]
    [SerializeField]
    private int StopTime = 30;

    //! �q�b�g�X�g�b�vCnt
    private int StopCnt = 0;

    //! �v���C���[���G�ꂽ���ǂ���
    private bool Touch = false;

    //! PlayerMove�X�N���v�g�i�[�p
    PlayerMove PlayerMoveScript;


    [Header("�_���[�W")]
    [SerializeField]
    private int Damage = 100;

    //! PlayerAnim�X�N���v�g�i�[�p
    //PlayerAnim PlayerAnimScript;

    //! CameraShake�X�N���v�g�i�[�p
    private CameraShake Shake;
   
    
    // Start is called before the first frame update
    void Start()
    {
        Shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();

        ResPlayerObj = GameObject.Find("ResPlayer").gameObject;

        ResTransform = ResPlayerObj.transform;

        //PlayerAnimScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnim>();
    }


    private void FixedUpdate()
    {
        if (Touch)
        {
            StopCnt++;
            if (StopTime < StopCnt)
            {
                //PlayerBehavior.enabled = true;
                PlayerMoveScript.LeftObj = null;
                PlayerMoveScript.RightObj = null;
                PlayerMoveScript.bMoveLeft = true;
                PlayerMoveScript.bMoveRight = true;

                PlayerMoveScript.SetMoveFlg(true);

                Touch = false;
                StopCnt = 0;


                ResPlayerObj.GetComponent<RespornScript>().Resporn();


            }
        }
    }


    //// Update is called once per frame
    //void Update()
    //{
    //    if (Touch)
    //    {
    //        StopCnt++;
    //        if (StopTime < StopCnt)
    //        {
    //            //PlayerBehavior.enabled = true;
    //            PlayerMoveScript.LeftObj = null;
    //            PlayerMoveScript.RightObj = null;
    //            PlayerMoveScript.bMoveLeft = true;
    //            PlayerMoveScript.bMoveRight = true;

    //            PlayerMoveScript.SetMoveFlg(true);

    //            Touch = false;
    //            StopCnt = 0;


    //            ResPlayerObj.GetComponent<RespornScript>().Resporn();


    //        }
    //    }
    //}
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag=="Player")
        {
            //Debug.Log(1233);

            Shake.Shake(5.0f, 0.1f);

            Touch = true;

            //PlayerBehavior = collision.transform.GetComponent<Behaviour>();
            PlayerMoveScript = collision.transform.GetComponent<PlayerMove>();
            PlayerMoveScript.SetMoveFlg(false);

            PlayerStatus playerStatus = collision.gameObject.GetComponent<PlayerStatus>();
            int hp = playerStatus.GetHp() - Damage;
            if (hp < 0) 
            {
                hp = 0;
            }
            playerStatus.SetHp(hp);

            PlayerAnim.AnimationAllReset();
            //PlayerAnimScript.AnimationAllReset();
            PlayerAnim.SetDamageAnim(true);
            //PlayerAnimScript.SetDamageAnim(true);

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>().Shake(5.0f, 0.3f);
            GameObject.FindGameObjectWithTag("Audio").GetComponent<GAudio>().DamageSEPlay();
        }
    }
}

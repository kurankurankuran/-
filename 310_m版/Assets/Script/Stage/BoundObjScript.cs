/**
* @file BoundObjScript.cs
* @brief BoundObjScript�N���X�̎���
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
* �˂���ɂ���ђ��˂�M�~�b�N�̎���
*/

public class BoundObjScript : MonoBehaviour
{
    //! �v���C���[�̋r���G��Ă���t���O
    private bool bTouchiFoot;

    //! ���ł���t���O
    private bool bSky;

    //! �����n�_ ���W�ۑ�
    Vector3 pos;
    
    //! �v���C���[�I�u�W�F�N�g�i�[�p
    private GameObject Player;

    //Rigidbody RbPlayer;

    [Header("�㏸�ʊ|���l")]
    [SerializeField]
    float upValue;

    //! ����upValue1�ꎞ�i�[�p
    float SaveupValue;

    [Header("�㏸��")]
    [SerializeField]
    private float moveY;

    [Header("�������x")]
    [SerializeField]
    float downValue = 0.1f;

    //! ����moveY�ꎞ�i�[�p
    float SavemoveY;

    //! �㏸�����ǂ���
    private bool bUp;
    
   
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        SavemoveY = moveY;
        bUp = true;
     
        pos = transform.localPosition;

        SaveupValue = upValue;

        bTouchiFoot = false;
        bSky = false;
    }

    private void FixedUpdate()
    {
        if (bSky)
        {

            

            if (moveY < 0.1f && upValue > 0)
            {
                bUp = false;
            }

            if (bUp)
            {
                moveY *= upValue;

                transform.position = new Vector3(transform.position.x, transform.position.y + moveY, transform.position.z);

                if (bTouchiFoot)
                {

                    Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + moveY, Player.transform.position.z);

                }
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - downValue, transform.position.z);
                if (bTouchiFoot)
                {
                    Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - downValue, Player.transform.position.z);

                }
            }
            

            if (transform.position.y < pos.y)
            {

                bUp = true;
                moveY = SavemoveY;

                bSky = false;


                transform.localPosition = new Vector3(pos.x, pos.y, pos.z);
              
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
     
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Foot")
        {
            bTouchiFoot = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
     
        if (!bSky)
        {
            if (other.tag == "Gage")
            {
                bSky = true;
              
            }
        }
        if (other.tag == "Foot")
        {
            bTouchiFoot = false;
        }
    }
}

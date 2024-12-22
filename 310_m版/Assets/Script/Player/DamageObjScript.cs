/**
* @file distortion.cs
* @brief distortion�N���X�̎���
* @author �q�@�a�K
* @date 5/5
*
* @details 
* @note 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObjScript : MonoBehaviour
{
    [Header("�v���C���[�ɓ����������̃_���[�W")]
    [SerializeField]
    public int Damage;

    [Header("����������ݒ�itrue�ōŏ��͎��̂����j")]
    [SerializeField]
    private bool bTouch;

    [Header("Player��D��D")]
    [SerializeField]
    private GameObject Player;

    private generated_effect HitEffect;

    private void OnValidate()
    {
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

        HitEffect = GetComponent<generated_effect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
       
        if (bTouch)
        {
            if (other.tag == "Player")
            {
                Debug.Log("�_���[�W�I");
                Player.GetComponent<PlayerStatus>().SetHp(Player.GetComponent<PlayerStatus>() .GetHp() - Damage);
                HitEffect.generate_Effect_Hit((this.transform.position + other.transform.position) / 2);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //Destroy(this);

        if (other.gameObject.tag == "Gage")
        {

            //// isTrigger�ؑ�
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

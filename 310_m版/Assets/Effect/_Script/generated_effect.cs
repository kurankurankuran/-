using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generated_effect : MonoBehaviour
{
    [Header("�G�t�F�N�g�̎�ނ̃v���n�u")]
    [SerializeField] public GameObject particleObject;

    //private void OnTriigerEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "DamageObj") //Object�^�O�̕t�����Q�[���I�u�W�F�N�g�ƏՓ˂���������
    //    {
    //        Instantiate(particleObject, (this.transform.position + collision.transform.position) / 2, Quaternion.identity); //�p�[�e�B�N���p�Q�[���I�u�W�F�N�g����
    //        //Destroy(this.gameObject); //�Փ˂����Q�[���I�u�W�F�N�g���폜

    //    }
    //}


   
    //�@�����^�C�~���O�𑼂̃X�N���v�g�ŒǋL���� 
    public void generate_Effect_Hit(Vector3 pos)
    {
        Instantiate(particleObject, pos, Quaternion.identity); //�p�[�e�B�N���p�Q�[���I�u�W�F�N�g����

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player") //Object�^�O�̕t�����Q�[���I�u�W�F�N�g�ƏՓ˂���������
    //    {
    //        Instantiate(particleObject, (this.transform.position + other.transform.position) / 2, Quaternion.identity); //�p�[�e�B�N���p�Q�[���I�u�W�F�N�g����
    //                                                                                                                        //Destroy(this.gameObject); //�Փ˂����Q�[���I�u�W�F�N�g���폜

    //    }
    //}


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

}

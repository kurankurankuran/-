using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generated_particle : MonoBehaviour
{
    [SerializeField] public GameObject particleObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DamageObj") //Object�^�O�̕t�����Q�[���I�u�W�F�N�g�ƏՓ˂���������
        {
            Instantiate(particleObject, this.transform.position, Quaternion.identity); //�p�[�e�B�N���p�Q�[���I�u�W�F�N�g����
            Destroy(this.gameObject); //�Փ˂����Q�[���I�u�W�F�N�g���폜
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

}

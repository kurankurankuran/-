using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changegenerated_effect : MonoBehaviour
{
    [Header("�؂�ւ�����u�Ԃ̃G�t�F�N�g")]
    [SerializeField] public GameObject particleObject1;

    [Header("�������̃G�t�F�N�g")]
    [SerializeField] public GameObject particleObject2;

    Vector3 Vec;

    [Header("�������̃G�t�F�N�g��\�����邩�ǂ���(true�ŕ\��)")]
    [SerializeField]
    private bool bInvEffect = true; 
    
    void Start()
    {
        Vec = new Vector3(transform.position.x, 0.0f, transform.position.z);
        Vec = Vec.normalized / 3.0f;
        Vec = new Vector3(
                Vec.x,
                Vec.y - 0.3f,
                Vec.z);

        if (bInvEffect)
        {
            if (transform.GetComponent<Collider>().isTrigger)
            {
                GameObject Particle = Instantiate(particleObject2, this.transform.position - Vec, Quaternion.identity); //�p�[�e�B�N���p�Q�[���I�u�W�F�N�g����
                Particle.transform.parent = this.transform;

            }
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Gage") //Object�^�O�̕t�����Q�[���I�u�W�F�N�g�ƏՓ˂���������
        {

            if (/*transform.childCount > 0*/transform.Find("eff_pfb_off(Clone)") != null)
            {
                Destroy(transform.Find("eff_pfb_off(Clone)").gameObject);

            }
            else
            {
                if (bInvEffect)
                {
                    GameObject Particle2 = Instantiate(particleObject2, this.transform.position - Vec, Quaternion.identity); //�p�[�e�B�N���p�Q�[���I�u�W�F�N�g����
                    Particle2.transform.parent = this.transform;
                }
            }

            GameObject Particle1 = Instantiate(particleObject1, this.transform.position - Vec, Quaternion.identity); //�p�[�e�B�N���p�Q�[���I�u�W�F�N�g����
            Particle1.transform.parent = this.transform;

        }
    }

    public void PlayEffect()
    {
        GameObject Particle = Instantiate(particleObject1, this.transform.position, Quaternion.identity); //�p�[�e�B�N���p�Q�[���I�u�W�F�N�g����
        Particle.transform.parent = transform;
    }
}

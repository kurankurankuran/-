//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SwitchWall : MonoBehaviour
//{


//    // ���g�̃R���C�_�[�i�[�p�iisTrigger�ؑ֗p�j
//    private Collider m_ObjectWCollider;

//    [Header("����������ݒ�itrue�ōŏ��͎��̂����j")]
//    [SerializeField]
//    private bool bInstance;

//    // ���g�̃��b�V�������_���[�擾
//    MeshRenderer myMeshRendere;

//    private void OnValidate()
//    {
//        myMeshRendere = GetComponent<MeshRenderer>();

//        // ���g�̃R���C�_�[�擾
//        m_ObjectWCollider = GetComponent<Collider>();

//        // �\���ؑւ�isTrigger�ݒ�
//        if (bInstance)
//        {
//            myMeshRendere.enabled = true;
           



//            m_ObjectWCollider.isTrigger = false;

//        }
//        else
//        {
//            myMeshRendere.enabled = false;

            
//            m_ObjectWCollider.isTrigger = true;

//        }


//    }



//    // Start is called before the first frame update
//    void Start()
//    {
//        myMeshRendere = GetComponent<MeshRenderer>();

    

//        // ���g�̃R���C�_�[�擾
//        m_ObjectWCollider = GetComponent<Collider>();

//        // �\���ؑւ�isTrigger�ݒ�
//        if (bInstance)
//        {
//            myMeshRendere.enabled = true;


//            m_ObjectWCollider.isTrigger = false;

//        }
//        else
//        {
//            myMeshRendere.enabled = false;

            
//            m_ObjectWCollider.isTrigger = true;

//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

//    private void OnTriggerExit(Collider other)
//    {

//        if (other.gameObject.tag == "Gage")
//        {
          

//            // isTrigger�ؑ�
//            m_ObjectWCollider.isTrigger = !m_ObjectWCollider.isTrigger;



//            // �����x�ؑ�
//            if (m_ObjectWCollider.isTrigger)
//            {
//                myMeshRendere.enabled = false;
              

//            }
//            else
//            {
//                myMeshRendere.enabled = true;
               

//            }
//        }
//    }
//}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyMove1 : MonoBehaviour
//{
//    //�C���X�y�N�^�[�Őݒ肷��
//    #region
//    [Header("�ړ����x")] public float speed;                        // �ړ����x
//    //[Header("�d��")] public float gravity;                        // �d��
//    [Header("��ʊO�ł��s������")] public bool nonVisibleAct;       // ��ʊO�ł��s������t���O
//    #endregion

//    //�v���C�x�[�g�ϐ�
//    #region
//    private Rigidbody rb = null;
//    private MeshRenderer mr = null;
//    private bool rightTleftF = false; // true�̎��E�ɐi�݁Afalse�̎����ɐi��
//    #endregion

//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        mr = GetComponent<MeshRenderer>();
//    }

//    void FixedUpdate()
//    {
//        // ��ʓ��ɂ�����s��
//        if (mr.isVisible || nonVisibleAct)
//        {
//            if (rightTleftF)
//            {
//                rb.velocity = new Vector3(speed, rb.velocity.y, 0);
//            }
//            else
//            {
//                rb.velocity = new Vector3(-speed, rb.velocity.y, 0);
//            }
//        }
//        else
//        {
//            rb.Sleep();
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (mr.isVisible || nonVisibleAct)
//        {
//            Debug.Log("��ʂɌ����Ă���");
//        }
//        else
//        {

//        }
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (rightTleftF)
//        {
//            rightTleftF = false;
//        }
//        else
//        {
//            rightTleftF = true;
//        }
//    }
//}

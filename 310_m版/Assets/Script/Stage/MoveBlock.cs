/**
* @file MoveBlock.cs
* @brief MoveBlock�N���X�̎���
* @author �q�@�a�K
* @date 5/5
*
* @details 
* @note 
*/

using UnityEngine;
using System.Collections;


/** �N���X�̊T�v���� */
/**
* ���g���㉺�ɂ���瓮����
*/
public class MoveBlock : MonoBehaviour
{
    [Header("�h��̕�")]
    [SerializeField]
    private float Radius = 0;

    //! ������Rigidbody�i�[�p
    private Rigidbody rigid;


    //! �����̏����ʒu�ۑ��p
    private Vector3 defaultPos;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        defaultPos = transform.position;
    }

    private void FixedUpdate()
    {
        rigid.MovePosition(new Vector3(defaultPos.x, defaultPos.y + Mathf.PingPong(Time.time, Radius), defaultPos.z));

    }
}

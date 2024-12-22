/**
* @file CirclePlacement.cs
* @brief CirclePlacement�N���X�̎���
* @author �q�@�a�K
* @date 5/5
*
* @details 
* @note 
*/


using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/** �N���X�̊T�v���� */
/**
* ���P�ʂŃI�u�W�F�N�g���~��ɔz�u����N���X
*/
public class CirclePlacement : MonoBehaviour
{


    [Header("���B�̐e�I�u�W�F�N�g���w��")]
    [SerializeField]
    GameObject Pillars;

    [Header("�z�u���钌�̔ԍ�")]
    [SerializeField]
    private int PillarNum;

    // �~���̔��a��菬�������a�擾
    private float Radius;

    [Header("�~����蔼�a���ǂꂾ����������")]
    [SerializeField]
    private float DiffRadius = 1;

    

    //=================================================================================
    //������
    //=================================================================================

    private void Awake()
    {
        Deploy();
     
    }

    //Inspector�̓��e(���a)���ύX���ꂽ���Ɏ��s
    private void OnValidate()
    {
        Deploy();

    }

    //�I�u�W�F�N�g���w�肵�����ɔz�u����(ContextMenu�Ō��}�[�N�̏��Ƀ��j���[�ǉ�)
    [ContextMenu("Deploy")]
    private void Deploy()
    {
        Vector3 SavePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Quaternion SaveQuatenion = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        if (!Pillars)
            return;
        // ���a�擾
        Radius = Pillars.GetComponent<CircleDeployer>()._radius - DiffRadius;

        // ���������擾
        int MaxPillarNum = Pillars.GetComponent<distortion>().MaxPillarNum;

        if (MaxPillarNum == 0)
        {
            Debug.Log(transform.name);
        }
       
        if (MaxPillarNum < PillarNum)
        {
            if(MaxPillarNum != 0)
            {
                PillarNum = PillarNum % MaxPillarNum;
            }
           
           
        }
        float angleDiff = 0;
        if (MaxPillarNum != 0)
        {
            //�I�u�W�F�N�g�Ԃ̊p�x��
            angleDiff = 360.0f / MaxPillarNum;
        }
           

        transform.rotation = new Quaternion(transform.rotation.x, 0.0f, transform.rotation.z, 0.0f);
        transform.Rotate(/*transform.parent.up*/new Vector3(0.0f,1.0f,0.0f), PillarNum * angleDiff);

        Vector3 myPostion = new Vector3(0.0f, transform.position.y, 0.0f);




        float angle = (90 - angleDiff * PillarNum) * Mathf.Deg2Rad;
            myPostion.x += Radius * Mathf.Cos(angle);
            myPostion.z += Radius * Mathf.Sin(angle);



        if (float.IsNaN(myPostion.x))
        {
            
            myPostion.x = SavePosition.x;
            transform.rotation = SaveQuatenion;

        }
        if (float.IsNaN(myPostion.y))
        {
            myPostion.y = SavePosition.y;
            transform.rotation = SaveQuatenion;
        }

        if (float.IsNaN(myPostion.z))
        {
            myPostion.z = SavePosition.z;
            transform.rotation = SaveQuatenion;
        }

        transform.position = new Vector3(myPostion.x, myPostion.y, myPostion.z);

      

    }
    void Start()
    {
      

        
    }
    private void Update()
    {
       
    }

}
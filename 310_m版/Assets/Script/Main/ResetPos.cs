/**
* @file ResetPos.cs
* @brief ResetPos�N���X�̎���
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
* �@�\�F
* �E�@�v���C���[�̈ʒu�����Z�b�g����
* �g����:
* �P�@ ���̃X�N���v�g��ResetTransform()�����Z�b�g�����^�C�~���O�Ŏg�p����
*/

public class ResetPos : MonoBehaviour
{
    [Header("���Z�b�g�������I�u�W�F�N�g�Ɠ����ʒu�A��]�̃I�u�W�F")]
    [SerializeField]
    private GameObject BaseObj;



    //GameObject BaseObj;
    //private List<GameObject> BaseList = new List<GameObject>();



    private PlayerMove PlayerMoveScript;

    // Start is called before the first frame update
    void Start()
    {
       
        PlayerMoveScript = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerMoveScript.CirCleMove(BaseObj.transform);
    }

    //public void RestPosition()
    //{
    //    //transform.position = new Vector3(BaseObj.transform.position.x, BaseObj.transform.position.y + 0.7f, BaseObj.transform.position.z);
    //    transform.position = new Vector3(BaseObj.transform.position.x, BaseObj.transform.position.y, BaseObj.transform.position.z);

    //}

    //public void BasePosition(GameObject OriginObj)
    //{
    //    BaseList.Add(Instantiate(OriginObj));
    //    //transform.position = new Vector3(BaseObj.transform.position.x, BaseObj.transform.position.y + 0.7f, BaseObj.transform.position.z);

    //}

    public void ResetTransform()
    {
        //for(int i = 0; i < BaseList.Count; i++)
        //{
        //    if (BaseList[i].transform.name == name) 
        //    {
        //        ResetTransform.position = new Vector3(BaseList[i].transform.position.x, BaseList[i].transform.position.y, BaseList[i].transform.position.z);
        //        ResetTransform.rotation = new Quaternion(BaseList[i].transform.rotation.x, BaseList[i].transform.rotation.y, BaseList[i].transform.rotation.z, BaseList[i].transform.rotation.w);

        //        break;
        //    }
        //}
        transform.position = new Vector3(BaseObj.transform.position.x, BaseObj.transform.position.y, BaseObj.transform.position.z);
        transform.rotation = new Quaternion(BaseObj.transform.rotation.x, BaseObj.transform.rotation.y, BaseObj.transform.rotation.z, BaseObj.transform.rotation.w);

    }

    //public bool GetThisorflg()
    //{
    //    return BaseObj.GetComponent<BaseObj>().GetThisorflg();
    //}

}

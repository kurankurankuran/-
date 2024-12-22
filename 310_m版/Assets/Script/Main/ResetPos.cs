/**
* @file ResetPos.cs
* @brief ResetPosクラスの実装
* @author 倉　和規
* @date 5/5
*
* @details 
* @note 
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** クラスの概要説明 */
/**
* 機能：
* ・　プレイヤーの位置をリセットする
* 使い方:
* １　 他のスクリプトでResetTransform()をリセットしたタイミングで使用する
*/

public class ResetPos : MonoBehaviour
{
    [Header("リセットしたいオブジェクトと同じ位置、回転のオブジェ")]
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

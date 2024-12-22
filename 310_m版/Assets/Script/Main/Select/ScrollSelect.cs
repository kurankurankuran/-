/**
* @file ScrollSelect.cs
* @brief ScrollSelectクラスの実装
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
* ・セレクトシーンカメラをスクロールさせる
* 
* 使い方:
* １　カメラオブジェクトにアタッチして他のスクリプト内でScrollDown() ScrollUp()で移動
*/

public class ScrollSelect : MonoBehaviour
{
    [SerializeField]
    private float Distance = 10.0f;

    [SerializeField]
    private float moveZ = 10.0f;

    [SerializeField]
    private float angle = 55.0f;
    private Vector3 Destination;

    private Vector3 PlusVec;

    private bool bScrollW = false;

    private bool bScrollS = false;

    Vector3 normarizeVec;


    private void Awake()
    {
        var q = new Vector3(0.0f, 0.0f, -1.0f);

        var p = Quaternion.Euler(new Vector3(0.0f, angle, 0.0f));

        var s = p * q;

        normarizeVec = s;


        PlusVec = s * (Distance / moveZ);
        if (StageSelect.CursolNum >= 4)
        {
           
            transform.position = transform.position + normarizeVec * Distance * (StageSelect.CursolNum / StageSelect.PageinStage);
           
        }

    }
    

    // Update is called once per frame
    void Update()
    {
      

        if (bScrollW)
        {
            if (bScrollS)
            {
                bScrollS = false;
            }

            if (transform.position.z <= Destination.z)
            {
                bScrollW = false;
            }
            else
            {
                transform.position += PlusVec;
            }
        }


        if (bScrollS)
        {
            if (bScrollW)
            {
                bScrollW = false;
            }
            if (transform.position.z >= Destination.z)
            {
                bScrollS = false;
            }
            else
            {
                transform.position += -PlusVec;
            }
        }

    }


    public bool ScrollUp()
    {
        bool bSuccess = false;

        if (!bScrollW)
        {
            if (!bScrollS)
            {

                Destination = transform.position + normarizeVec * Distance;
                bScrollW = true;
               

                return bSuccess = true;
            }
        }

      

        return bSuccess;
    }

    public bool ScrollDown()
    {
        bool bSuccess = false;

        if (!bScrollW)
        {
            if (!bScrollS)
            {

                Destination = transform.position - normarizeVec * Distance;
                bScrollS = true;

                return bSuccess = true;
            }
        }

        return bSuccess;
    }

    public bool CursolMove()
    {
        //Debug.Log(StageSelect.bNoeLoading);
        bool bScroll = false;
        if (!bScrollW && !bScrollS)
        {
            bScroll = true;
        }

        if (StageSelect.bNowLoading/*!GameObject.Find("UI_Select").activeSelf*/)
        {
            bScroll = false;
        }

       

        return bScroll;
    }
}

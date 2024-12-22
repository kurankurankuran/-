/**
* @file CirclePlacement.cs
* @brief CirclePlacementクラスの実装
* @author 倉　和規
* @date 5/5
*
* @details 
* @note 
*/


using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/** クラスの概要説明 */
/**
* 柱単位でオブジェクトを円状に配置するクラス
*/
public class CirclePlacement : MonoBehaviour
{


    [Header("柱達の親オブジェクトを指定")]
    [SerializeField]
    GameObject Pillars;

    [Header("配置する柱の番号")]
    [SerializeField]
    private int PillarNum;

    // 円筒の半径より小さい半径取得
    private float Radius;

    [Header("円筒より半径がどれだけ小さいか")]
    [SerializeField]
    private float DiffRadius = 1;

    

    //=================================================================================
    //初期化
    //=================================================================================

    private void Awake()
    {
        Deploy();
     
    }

    //Inspectorの内容(半径)が変更された時に実行
    private void OnValidate()
    {
        Deploy();

    }

    //オブジェクトを指定した柱に配置する(ContextMenuで鍵マークの所にメニュー追加)
    [ContextMenu("Deploy")]
    private void Deploy()
    {
        Vector3 SavePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Quaternion SaveQuatenion = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);
        if (!Pillars)
            return;
        // 半径取得
        Radius = Pillars.GetComponent<CircleDeployer>()._radius - DiffRadius;

        // 柱総数を取得
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
            //オブジェクト間の角度差
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
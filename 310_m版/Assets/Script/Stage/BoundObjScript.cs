/**
* @file BoundObjScript.cs
* @brief BoundObjScriptクラスの実装
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
* ねじれにより飛び跳ねるギミックの実装
*/

public class BoundObjScript : MonoBehaviour
{
    //! プレイヤーの脚が触れているフラグ
    private bool bTouchiFoot;

    //! 飛んでいるフラグ
    private bool bSky;

    //! 初期地点 座標保存
    Vector3 pos;
    
    //! プレイヤーオブジェクト格納用
    private GameObject Player;

    //Rigidbody RbPlayer;

    [Header("上昇量掛け値")]
    [SerializeField]
    float upValue;

    //! 初期upValue1一時格納用
    float SaveupValue;

    [Header("上昇量")]
    [SerializeField]
    private float moveY;

    [Header("落下速度")]
    [SerializeField]
    float downValue = 0.1f;

    //! 初期moveY一時格納用
    float SavemoveY;

    //! 上昇中かどうか
    private bool bUp;
    
   
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        SavemoveY = moveY;
        bUp = true;
     
        pos = transform.localPosition;

        SaveupValue = upValue;

        bTouchiFoot = false;
        bSky = false;
    }

    private void FixedUpdate()
    {
        if (bSky)
        {

            

            if (moveY < 0.1f && upValue > 0)
            {
                bUp = false;
            }

            if (bUp)
            {
                moveY *= upValue;

                transform.position = new Vector3(transform.position.x, transform.position.y + moveY, transform.position.z);

                if (bTouchiFoot)
                {

                    Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + moveY, Player.transform.position.z);

                }
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - downValue, transform.position.z);
                if (bTouchiFoot)
                {
                    Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - downValue, Player.transform.position.z);

                }
            }
            

            if (transform.position.y < pos.y)
            {

                bUp = true;
                moveY = SavemoveY;

                bSky = false;


                transform.localPosition = new Vector3(pos.x, pos.y, pos.z);
              
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
     
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Foot")
        {
            bTouchiFoot = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
     
        if (!bSky)
        {
            if (other.tag == "Gage")
            {
                bSky = true;
              
            }
        }
        if (other.tag == "Foot")
        {
            bTouchiFoot = false;
        }
    }
}

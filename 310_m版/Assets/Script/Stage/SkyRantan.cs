/**
* @file SkyRantan.cs
* @brief SkyRantanクラスの実装
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
* 触れながら霊力消費で目的地まで自動で動く足場
*/
public class SkyRantan : MonoBehaviour
{
    // 触れているフラグ
    private bool bTouchi;
    // プレイヤーの脚が触れているフラグ
    private bool bTouchiFoot;

    // 飛んでいるフラグ
    private bool bSky;

    [Header("効果発動までの要チャージ時間")]
    [SerializeField]
    private int ChargeTime;

    [Header("浮く時間")]
    [SerializeField]
    private int InsTime;

    [Header("目的地に着いてからの待機時間")]
    [SerializeField]
    private int breakTime;

    [Header("消費霊力")]
    [SerializeField]
    private int Cost;

    [Header("移動量X")]
    [SerializeField]
    private float moveX;

    [Header("移動量Y")]
    [SerializeField]
    private float moveY;

    [Header("StageObjectをD＆D")]
    [SerializeField]
    private GameObject StageObj;

    [Header("PlayerをD＆D")]
    [SerializeField]
    private GameObject Player;



    // チャージ時間カウント
    private int ChargeCnt;

    // 実体化時間カウント
    private int InsCnt;


    //// 初期は透明
    //private bool bInstance;
    
    private PlayerStatus PlayerStatusScript;

    private CRGenerate_Effect EffectPlay;

    // Start is called before the first frame update
    void Start()
    {
        EffectPlay = GetComponent<CRGenerate_Effect>();
        
        PlayerStatusScript = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();

        bSky = false;
        bTouchi = false;
        ChargeCnt = 0;
        InsCnt = 0;
        bTouchiFoot = false;
        //bInstance = false;

     
    }

    // Update is called once per frame
    void Update()
    {
        if (bTouchi)
        {
            if (Input.GetKey("k"))
            {
                if (PlayerStatusScript.GetHp() > 0)
                {
                    ChargeCnt++;
                    //if (InsCnt > 0)
                    //{
                    //    if (!m_ObjectWCollider.isTrigger)
                    //    {
                    //        ChargeCnt--;
                    //        PlayerStatusScript.SetHp(PlayerStatusScript.GetHp() - 1);
                    //        InsCnt--;
                    //        Debug.Log(InsCnt);
                    //    }
                    //}
                }



                if (ChargeTime < ChargeCnt)
                {
                    if (PlayerStatusScript.GetHp() > Cost && !bSky)

                    {
                        PlayerStatusScript.SetHp(PlayerStatusScript.GetHp() - Cost);

                        ChargeCnt = 0;

                        bSky = true;

                        EffectPlay.DestroyParticle();

                        //transform.position = new Vector3(,)

                    }
                    else if (!bSky)
                    {
                        ChargeCnt = 0;
                    }
                }

            }
        }


        if (bSky)
        {
            if (InsCnt == 0) 
            {
                EffectPlay.GenerateParticle();
            }


            InsCnt++;

           

            if (InsCnt < InsTime)
            {
                
                // 目的地まで動く

                transform.position = new Vector3(transform.position.x, transform.position.y + moveY, transform.position.z);
                transform.RotateAround(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), -moveX);

                if (bTouchiFoot)
                {
                    Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + moveY, Player.transform.position.z);
                    StageObj.transform.RotateAround(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), moveX);
                }
            }
            else if(InsCnt < InsTime + breakTime)
            {
                // その場で待機する
            }
            else if(InsCnt < InsTime * 2 + breakTime)
            {
                // 目的地から帰ってくる

                transform.position = new Vector3(transform.position.x, transform.position.y - moveY, transform.position.z);
                transform.RotateAround(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), moveX);

                if (bTouchiFoot)
                {
                    Player.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - moveY, Player.transform.position.z);
                    StageObj.transform.RotateAround(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), -moveX);
                }
            }
            else if (InsCnt >= InsTime * 2 + breakTime)
            {
                bSky = false;

                InsCnt = 0;
            }

            //if (InsCnt > InsTime)
            //{
            //    bSky = false;

            //    InsCnt = 0;
            //}
        }


    }

  

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("触れている");
            bTouchi = true;
        }

        
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("離れた");
            bTouchi = false;
        }

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Foot")
        {
            Debug.Log("脚に触れている");
            bTouchiFoot = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Foot")
        {
            Debug.Log("脚が離れた");
            bTouchiFoot = false;
        }
    }

}

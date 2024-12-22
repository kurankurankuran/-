/**
* @file Tyouchin.cs
* @brief Tyouchinクラスの実装
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
* 触れて霊力消費で実体化する
*/
public class Tyouchin : MonoBehaviour
{

    // 触れているフラグ
    private bool bTouchi;

    [Header("効果発動までの要チャージ時間")]
    [SerializeField]
    private int ChargeTime;

    [Header("実体化している時間")]
    [SerializeField]
    private int InsTime;

    [Header("消費霊力")]
    [SerializeField]
    private int Cost;


    // チャージ時間カウント
    private int ChargeCnt;

    // 実体化時間カウント
    private int InsCnt;


    //// 初期は透明
    //private bool bInstance;

    // 自身のコライダー格納用（isTrigger切替用）
    private Collider m_ObjectWCollider;

    private PlayerStatus PlayerStatusScript;

    // Start is called before the first frame update
    void Start()
    {
        PlayerStatusScript = GameObject.FindWithTag("Player").GetComponent<PlayerStatus>();
        // 自身のコライダー取得
        m_ObjectWCollider = GetComponent<Collider>();

        bTouchi = false;
        ChargeCnt = 0;
        InsCnt = 0;
        //bInstance = false;

        GetComponent<Renderer>().material.color = new Color(
                    GetComponent<Renderer>().material.color.r,
                    GetComponent<Renderer>().material.color.g,
                    GetComponent<Renderer>().material.color.b
                    , 0.3f);
        
        m_ObjectWCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(bTouchi)
        {
            if (Input.GetKey("k"))
            {
                if (PlayerStatusScript.GetHp() > 0)
                {
                    ChargeCnt++;
                    if (InsCnt > 0)
                    {
                        if (!m_ObjectWCollider.isTrigger)
                        {
                            ChargeCnt--;
                            PlayerStatusScript.SetHp(PlayerStatusScript.GetHp() - 1);
                            InsCnt--;
                            Debug.Log(InsCnt);
                        }
                    }
                }
                
               
   
                if (ChargeTime < ChargeCnt)
                {
                    if (PlayerStatusScript.GetHp() > Cost && m_ObjectWCollider.isTrigger)
                        
                    {
                        PlayerStatusScript.SetHp(PlayerStatusScript.GetHp() - Cost);

                        ChargeCnt = 0;

                        GetComponent<Renderer>().material.color = new Color(
                       GetComponent<Renderer>().material.color.r,
                       GetComponent<Renderer>().material.color.g,
                       GetComponent<Renderer>().material.color.b
                       , 1.0f);

                        m_ObjectWCollider.isTrigger = false;

                    }
                    else if(!m_ObjectWCollider.isTrigger)
                    {
                        ChargeCnt = 0;
                    }
                }
                
            }
        }


        if (!m_ObjectWCollider.isTrigger)
        {
            InsCnt++;
            if (InsCnt > InsTime) 
            {
                GetComponent<Renderer>().material.color = new Color(
                GetComponent<Renderer>().material.color.r,
                GetComponent<Renderer>().material.color.g,
                GetComponent<Renderer>().material.color.b
                , 0.3f);

                m_ObjectWCollider.isTrigger = true;

                InsCnt = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("触れている");
            bTouchi = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("離れた");
            bTouchi = false;
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
}

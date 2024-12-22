/**
* @file SwitchAlpha.cs
* @brief SwitchAlphaクラスの実装
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
* オブジェクトをねじれによって透明、不透明に切り替える
* 
* 使い方：
* １　すり抜ける抜けないの性質を持たせるオブジェクトにアタッチ
* ２　インスペクターから値を設定
*/
public class SwitchAlpha : MonoBehaviour
{
   

    // 自身のコライダー格納用（isTrigger切替用）
    private Collider m_ObjectWCollider;

    [Header("初期性質を設定（trueで最初は実体を持つ）")]
    [SerializeField]
    private bool bInstance;

    

    GroundChecker GroundCheckerScript;

    private int EntetFoot;

    TestJump PlayerJump;

    // 自身のメッシュレンダラー取得
    MeshRenderer myMeshRendere;

    //Inspectorの内容が変更された時に実行
    private void OnValidate()
    {
        myMeshRendere = GetComponent<MeshRenderer>();

        // 自身のコライダー取得
        m_ObjectWCollider = GetComponent<Collider>();
     
        // 表示切替とisTrigger設定
        if (bInstance)
        {
            myMeshRendere.enabled = true;
            //GetComponent<Renderer>().material.color = new Color(
            //         GetComponent<Renderer>().material.color.r,
            //         GetComponent<Renderer>().material.color.g,
            //         GetComponent<Renderer>().material.color.b
            //         , 1.0f);


            m_ObjectWCollider.isTrigger = false;
        
        }
        else
        {
            myMeshRendere.enabled = false;

            //GetComponent<Renderer>().material.color = new Color(
            //        GetComponent<Renderer>().material.color.r,
            //        GetComponent<Renderer>().material.color.g,
            //        GetComponent<Renderer>().material.color.b
            //        , 0.3f);

            m_ObjectWCollider.isTrigger = true;
          
        }


    }


    // Start is called before the first frame update
    void Start()
    {
        myMeshRendere = GetComponent<MeshRenderer>();

        EntetFoot = 0;

        GroundCheckerScript = GameObject.FindGameObjectWithTag("Foot").GetComponent<GroundChecker>();
        PlayerJump = GameObject.FindGameObjectWithTag("Player").GetComponent<TestJump>();

        // 自身のコライダー取得
        m_ObjectWCollider = GetComponent<Collider>();

        // 表示切替とisTrigger設定
        if (bInstance)
        {
            myMeshRendere.enabled = true;

            //GetComponent<Renderer>().material.color = new Color(
            //         GetComponent<Renderer>().material.color.r,
            //         GetComponent<Renderer>().material.color.g,
            //         GetComponent<Renderer>().material.color.b
            //         , 1.0f);
            

            m_ObjectWCollider.isTrigger = false;
            
        }
        else
        {
            myMeshRendere.enabled = false;

            //GetComponent<Renderer>().material.color = new Color(
            //        GetComponent<Renderer>().material.color.r,
            //        GetComponent<Renderer>().material.color.g,
            //        GetComponent<Renderer>().material.color.b
            //        , 0.3f);
            

            m_ObjectWCollider.isTrigger = true;
          
        }

      
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Foot") 
        {
            EntetFoot--;
        }

        if (other.gameObject.tag == "Gage")
        {
            if (EntetFoot == 1)
            {
                if (!m_ObjectWCollider.isTrigger)
                {
                    GroundCheckerScript.DelentetNum();
                    if (GroundCheckerScript.GetEnterNum() <= 0)
                    {
                        PlayerJump.PlayerFall();
                        GroundCheckerScript.OnExitGround.Invoke();
                    }
                }
                else
                {
                    GroundCheckerScript.PlusentetNum();
                    if (GroundCheckerScript.GetEnterNum() > 0)
                    {
                        
                        GroundCheckerScript.OnEnterGround.Invoke();
                    }
                }
            }
           

            // isTrigger切替
            m_ObjectWCollider.isTrigger = !m_ObjectWCollider.isTrigger;

            

            // 透明度切替
            if (m_ObjectWCollider.isTrigger)
            {
                myMeshRendere.enabled = false;
                //GetComponent<Renderer>().material.color = new Color(
                //   GetComponent<Renderer>().material.color.r,
                //   GetComponent<Renderer>().material.color.g,
                //   GetComponent<Renderer>().material.color.b
                //   , 0.3f);

            }
            else
            {
                myMeshRendere.enabled = true;
                //GetComponent<Renderer>().material.color = new Color(
                //     GetComponent<Renderer>().material.color.r,
                //     GetComponent<Renderer>().material.color.g,
                //     GetComponent<Renderer>().material.color.b
                //     , 1.0f);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Foot")
        {
            if (EntetFoot <= 0)
            {
                EntetFoot++;
            }
        }
    }
    
}


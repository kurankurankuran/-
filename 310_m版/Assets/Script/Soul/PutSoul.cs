/**
* @file PutSoul.cs
* @brief PutSoulクラスの実装
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
* ・プレイヤーが魂を持った状態でアタッチされたオブジェにあたると魂をそこに置かれた状態にする
* 使い方:
* １　ゴール目標にしたいオブジェクトにアタッチ
*/

public class PutSoul : MonoBehaviour
{
   
    [SerializeField]
    public GameObject Soul;

    [Header("初期性質を設定（trueで最初は実体を持つ）")]
    [SerializeField]
    private bool bTouch;

    private DisCharge_Generate_Effect DisEffect;

    private void OnValidate()
    {
        //GetComponent<Renderer>().material.color = Soul.GetComponent<Renderer>().material.color;

        // 色切替と触れる設定
        if (bTouch)
        {
            //GetComponent<Renderer>().material.color = new Color(
            //         GetComponent<Renderer>().material.color.r,
            //         GetComponent<Renderer>().material.color.g,
            //         GetComponent<Renderer>().material.color.b
            //         , 1.0f);

        }
        else
        {
            //GetComponent<Renderer>().material.color = new Color(
            //        GetComponent<Renderer>().material.color.r,
            //        GetComponent<Renderer>().material.color.g,
            //        GetComponent<Renderer>().material.color.b
            //        , 0.1f);

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        DisEffect = GetComponent<DisCharge_Generate_Effect>();

        //GetComponent<Renderer>().material.color = Soul.GetComponent<Renderer>().material.color;

        // 色切替と触れる設定
        if (bTouch)
        {
            //GetComponent<Renderer>().material.color = new Color(
            //         GetComponent<Renderer>().material.color.r,
            //         GetComponent<Renderer>().material.color.g,
            //         GetComponent<Renderer>().material.color.b
            //         , 1.0f);

        }
        else
        {
            //GetComponent<Renderer>().material.color = new Color(
            //        GetComponent<Renderer>().material.color.r,
            //        GetComponent<Renderer>().material.color.g,
            //        GetComponent<Renderer>().material.color.b
            //        , 0.1f);

        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerStay(Collider other)
    {
        //if (bTouch)
        //{
        if (other.tag == "Player" || other.tag == "PlayerLR") 
        {
            if (Soul.GetComponent<Soul>().bRot)
            {
                if (Soul.GetComponent<Soul>().transform.name == "Soul")
                {
                    GameObject.Find("SoullconPanel").GetComponent<SoulScore>().ScaleON1();
                }
                else if(Soul.GetComponent<Soul>().transform.name == "Soul (1)")
                {
                    GameObject.Find("SoullconPanel").GetComponent<SoulScore>().ScaleON2();
                }
                else if(Soul.GetComponent<Soul>().transform.name == "Soul (2)")
                {
                    GameObject.Find("SoullconPanel").GetComponent<SoulScore>().ScaleON3();
                }



                Soul.GetComponent<Soul>().bRot = false;
                Soul.GetComponent<Soul>().bPut = true;

                DisEffect.Generate_Effect();



                GameObject.Find("AudioController").GetComponent<GAudio>().HPBarSEStop();

                GameObject.Find("Souls").GetComponent<SoulCnt>().DelSoul();

                Soul.transform.position = transform.position;

                Soul.transform.parent = transform;
                
            }
        }
        //}
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Gage")
        {

            bTouch = !bTouch;
            // 透明度切替
            if (bTouch)
            {

                //GetComponent<Renderer>().material.color = new Color(
                //   GetComponent<Renderer>().material.color.r,
                //   GetComponent<Renderer>().material.color.g,
                //   GetComponent<Renderer>().material.color.b
                //   , 1.0f);


            }
            else
            {

                //GetComponent<Renderer>().material.color = new Color(
                //     GetComponent<Renderer>().material.color.r,
                //     GetComponent<Renderer>().material.color.g,
                //     GetComponent<Renderer>().material.color.b
                //     , 0.3f);


            }
        }

    }
}

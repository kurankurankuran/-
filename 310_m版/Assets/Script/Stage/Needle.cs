/**
* @file Needle.cs
* @brief Needleクラスの実装
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
* 自身がプレイヤーに触れるとリスポーン地点まで戻す
*/
public class Needle : MonoBehaviour
{
    //! リスポーンオブジェクト格納用
    private GameObject ResPlayerObj;

    //! リスポーンオブジェクトのトランスフォーム格納用
    private Transform ResTransform;
    
    [Header("Playerストップ時間")]
    [SerializeField]
    private int StopTime = 30;

    //! ヒットストップCnt
    private int StopCnt = 0;

    //! プレイヤーが触れたかどうか
    private bool Touch = false;

    //! PlayerMoveスクリプト格納用
    PlayerMove PlayerMoveScript;


    [Header("ダメージ")]
    [SerializeField]
    private int Damage = 100;

    //! PlayerAnimスクリプト格納用
    //PlayerAnim PlayerAnimScript;

    //! CameraShakeスクリプト格納用
    private CameraShake Shake;
   
    
    // Start is called before the first frame update
    void Start()
    {
        Shake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();

        ResPlayerObj = GameObject.Find("ResPlayer").gameObject;

        ResTransform = ResPlayerObj.transform;

        //PlayerAnimScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAnim>();
    }


    private void FixedUpdate()
    {
        if (Touch)
        {
            StopCnt++;
            if (StopTime < StopCnt)
            {
                //PlayerBehavior.enabled = true;
                PlayerMoveScript.LeftObj = null;
                PlayerMoveScript.RightObj = null;
                PlayerMoveScript.bMoveLeft = true;
                PlayerMoveScript.bMoveRight = true;

                PlayerMoveScript.SetMoveFlg(true);

                Touch = false;
                StopCnt = 0;


                ResPlayerObj.GetComponent<RespornScript>().Resporn();


            }
        }
    }


    //// Update is called once per frame
    //void Update()
    //{
    //    if (Touch)
    //    {
    //        StopCnt++;
    //        if (StopTime < StopCnt)
    //        {
    //            //PlayerBehavior.enabled = true;
    //            PlayerMoveScript.LeftObj = null;
    //            PlayerMoveScript.RightObj = null;
    //            PlayerMoveScript.bMoveLeft = true;
    //            PlayerMoveScript.bMoveRight = true;

    //            PlayerMoveScript.SetMoveFlg(true);

    //            Touch = false;
    //            StopCnt = 0;


    //            ResPlayerObj.GetComponent<RespornScript>().Resporn();


    //        }
    //    }
    //}
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag=="Player")
        {
            //Debug.Log(1233);

            Shake.Shake(5.0f, 0.1f);

            Touch = true;

            //PlayerBehavior = collision.transform.GetComponent<Behaviour>();
            PlayerMoveScript = collision.transform.GetComponent<PlayerMove>();
            PlayerMoveScript.SetMoveFlg(false);

            PlayerStatus playerStatus = collision.gameObject.GetComponent<PlayerStatus>();
            int hp = playerStatus.GetHp() - Damage;
            if (hp < 0) 
            {
                hp = 0;
            }
            playerStatus.SetHp(hp);

            PlayerAnim.AnimationAllReset();
            //PlayerAnimScript.AnimationAllReset();
            PlayerAnim.SetDamageAnim(true);
            //PlayerAnimScript.SetDamageAnim(true);

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>().Shake(5.0f, 0.3f);
            GameObject.FindGameObjectWithTag("Audio").GetComponent<GAudio>().DamageSEPlay();
        }
    }
}

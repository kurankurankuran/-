

/**
* @file Soul.cs
* @brief Soulクラスの実装
* @author 倉　和規
* @date 5/5
*
* @details 
* @note 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/** クラスの概要説明 */
/**
* 機能：
* ・プレイヤーにあたるとプレイヤーの周りを回転し始める
* ・プレイヤーのステータスを参照して霊力ゲージが０になるといったん上昇してから元位置に戻る
* 
* 使い方:
* １　性質を与えたいオブジェクトにアタッチする
*/

public class Soul : MonoBehaviour
{
   
    SupriseAlpha supriseAlpha;

    [Header("逃げてから元の場所に戻るまでの時間")]
    [SerializeField] private float waitTime = 5;

    [Header("逃げてからの上昇速度")]
    [SerializeField] private float upValue = 0.5f;

    [Header("プレイヤー保持中エフェクト")]
    [SerializeField] private GameObject particleObject1;

    [Header("逃げている最中エフェクト")]
    [SerializeField] private GameObject particleObject2;


    [Header("初期性質を設定（trueで最初は実体を持つ）")]
    [SerializeField]
    public bool bTouch;
    //private bool bInstance;

    [Header("アクティブを切り替えるオブジェクト1")]
    [SerializeField]
    private GameObject Particle1;

    [Header("アクティブを切り替えるオブジェクト2")]
    [SerializeField]
    private GameObject Particle2;



    //　旋回するターゲット
    private Transform target;
    //　現在の角度
    private float angle;

    [HideInInspector]
    public bool bRot;
    [HideInInspector]
    public bool bPut;
    [HideInInspector]
    public bool bEscape;

    private bool bReturn;
  
    // 自身のコライダー格納用（isTrigger切替用）
    private Collider m_ObjectWCollider;

    // 初期位置保存
    Transform DefTransform;
   
    private PlayerMove PlayerMoveScript;

    Vector3 PtoS;

    private Vector3 CameraForword;

    private void OnValidate()
    {
     

        //// 色切替と触れる設定
        //if (bTouch)
        //{
          
        //    Particle1.SetActive(true);
        //    Particle2.SetActive(true);
        //}
        //else
        //{
        //    Particle1.SetActive(false);
        //    Particle2.SetActive(false);

        //}


    }


    private void Start()
    {
        CameraForword = GameObject.FindWithTag("MainCamera").transform.forward;

        bRot = false;
        bPut = false;
        bEscape = false;
        bReturn = false;

        PlayerMoveScript = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        supriseAlpha = GameObject.FindWithTag("Mark").GetComponent<SupriseAlpha>();
    }

    // Update is called once per frame
    void Update()
    {
        //PlayerMoveScript.CirCleMove(DefTransform);
        if (bRot)
        {

            // 回転のクォータニオン作成
            var angleAxis = Quaternion.AngleAxis(360 / 2 * Time.deltaTime,transform.up/* CameraForword*/);

            // 円運動の位置計算
            var pos = PtoS;

            pos = angleAxis * pos;

            PtoS = pos;


            //ユニットの位置 = ターゲットの位置 ＋ ターゲットから見たユニットの角度 ×　ターゲットからの距離
            if (bReturn)
            {

                PtoS = new Vector3(0.0f, upValue, 0.0f);
                transform.position += /*target.position +*/ PtoS;
            }
            else
            {
                transform.position = target.position + PtoS;
            }

            //transform.position = target.position /*+ PtoS*/;

            // Debug.Log("回転開始！");
            if (target.GetComponent<PlayerStatus>().GetHp() <= 0 || SoulRelease.bRelease) 
            {
                //Debug.Log("Soulが逃げました");
                //GetComponent<ResetPos>().ResetTransform();
                //bRot = false;

                if (!bReturn)
                {
                    GameObject.Find("AudioController").GetComponent<GAudio>().LostSoulSEPlay();
                    //supriseAlpha.AlphaUpDown(30.0f);
                    supriseAlpha/*.GetComponent<SupriseAlpha>()*/.AlphaUpDown(1.0f);

                    bEscape = true;
                    bRot = false;
                    bReturn = true;

                    particleObject1.SetActive(false);
                    particleObject2.SetActive(true);

                    // コルーチンの起動
                    StartCoroutine(DelayCoroutine());

                    
                }
            }
        }

        if(bEscape)
        {
            PtoS = new Vector3(0.0f, upValue, 0.0f);
            transform.position += /*target.position +*/ PtoS;
        }

        if (bPut)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            particleObject1.SetActive(false);
        }
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (!bPut)
        {
            //if (bTouch)
            //{
                if (!bRot)
                {
                    if (!bEscape)
                    {
                        if (other.gameObject.tag == "Player")
                        {



                        PtoS = other.transform.forward/* CameraForword.normalized*/ / 2.0f;

                        PtoS = new Vector3(PtoS.x, PtoS.y + 0.15f, PtoS.z);
                        //PtoS = new Vector3(0.0f, 0.0f, 0.0f);

                        GetComponent<Charge_generated_effect>().PlayEffect();



                        bRot = true;

                        target = other.transform;
                        GameObject.Find("AudioController").GetComponent<GAudio>().SoulGetSEPlay();


                        transform.GetChild(0).gameObject.SetActive(false);


                        particleObject1.SetActive(true);

                        //GameObject Particle = Instantiate(
                        //    particleObject, 
                        //    this.transform.position + new Vector3(0.0f,1.0f,0.0f), 
                        //    Quaternion.identity); //パーティクル用ゲームオブジェクト生成

                        //Particle.transform.parent = this.transform;

                    }
                }
                }
            //}
        }


        //if (!bRot)
        //{
        //    if (!bPut)
        //    {
        //        if (other.tag == "Screen")
        //        {
        //            bTouch = true;
        //            Particle1.SetActive(true);
        //            Particle2.SetActive(true);
        //        }
        //        else if (other.tag == "ThatScreen")
        //        {
        //            bTouch = false;
        //            Particle1.SetActive(false);
        //            Particle2.SetActive(false);
        //        }
        //    }
        //}

    }
    

    // コルーチン本体
    private IEnumerator DelayCoroutine()
    {

        // ～秒間待つ
        yield return new WaitForSeconds(waitTime);

        particleObject2.SetActive(false);
        GetComponent<ResetPos>().ResetTransform();
        transform.GetChild(0).gameObject.SetActive(true);
        
        bReturn = false;
        bEscape = false;

        //bTouch = GetComponent<ResetPos>().GetThisorflg();
    }
}
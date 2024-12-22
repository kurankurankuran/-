/**
* @file DarkSoulScript.cs
* @brief DarkSoulScriptクラスの実装
* @author 倉　和規
* @date 5/5
*
* @details 
* @note 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/** クラスの概要説明 */
/**
* 機能：
* ・プレイヤーを追尾
* ・当たると霊力ゲージを０に
* ・ねじれに巻き込まれると固まり足場に
* ・さらに巻き込まれると消える
*/
public class DarkSoulScript : MonoBehaviour
{
    [Header("cubeをD&D")]
    [SerializeField]
    private GameObject Brock; 

    //[Header("PlayerをD&D")]
    //[SerializeField]

    //! プレイヤーオブジェクト格納用
    private GameObject Player;
    
    [Header("ダメージ")]
    [SerializeField]
    private int Damage = 100;

    [Header("追跡速度X")]
    [SerializeField]
    private float SpeedX = 0.1f;

    private float _SpeedX = 0.0f;

    [Header("追跡速度Y")]
    [SerializeField]
    private float SpeedY = 0.025f;
    private float _SpeedY = 0.0f;

    [Header("移動慣性係数X")]
    [SerializeField]
    private float RotateX = 0.025f;

    [Header("移動慣性係数Y")]
    [SerializeField]
    private float RotateY = 0.025f;


    // 自身のメッシュレンダラー取得
    //MeshRenderer myMeshRendere;

    //! 追跡ONOFF
    public bool Horming = false;

    //! CameraShakeスクリプト格納用
    private CameraShake Shake;

    //[Header("初期性質")]
    //[SerializeField]
    //! 固まっているフラグ
    private bool bSolid = false;

    //! 自身のコライダー格納用
    Collider myCollider;


    bool bTouchFoot = false;

   

    // Start is called before the first frame update
    void Start()
    {
        //myMeshRendere = GetComponent<MeshRenderer>();
    }

    private void FixedUpdate()
    {
        GroundChecker groundChecker = GameObject.FindGameObjectWithTag("Foot").GetComponent<GroundChecker>();

        if (Player != null)
        {
            if (!bSolid)
            {

                if (Horming)
                {
                   

                    if (0 < Vector3.SignedAngle(Player.transform.position, transform.position, new Vector3(0.0f, 1.0f, 0.0f)))
                    {
                        _SpeedX -= SpeedX;

                        transform.RotateAround(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), _SpeedX/*-SpeedX*/);
                    }
                    else
                    {
                        _SpeedX += SpeedX;
                        transform.RotateAround(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), _SpeedX/*SpeedX*/);
                    }

                    if (transform.position.y < Player.transform.position.y)
                    {
                        _SpeedY += SpeedY;

                        transform.position = new Vector3(transform.position.x, transform.position.y + _SpeedY/*SpeedY*/, transform.position.z);
                    }
                    else
                    {
                        _SpeedY -= SpeedY;
                        transform.position = new Vector3(transform.position.x, transform.position.y + _SpeedY/*SpeedY*/, transform.position.z);
                    }

                    _SpeedX += (0.0f - _SpeedX) * RotateX;
                    _SpeedY += (0.0f - _SpeedY) * RotateY;
                }
            }
            else
            {

            }
        }
    }
    



    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Gage")
        {
            if (bSolid)
            {
                if (bTouchFoot)
                {
                  
                    GroundChecker groundChecker = GameObject.FindGameObjectWithTag("Foot").GetComponent<GroundChecker>();
                   
                    groundChecker.DelentetNum();
                    if (groundChecker.GetEnterNum() <= 0)
                    {
                        groundChecker.OnExitGround.Invoke();
                    }
                }

                Destroy(this.gameObject.transform.parent.gameObject);
            }
            else
            {

                bSolid = true;
                myCollider.isTrigger = false;

                //myMeshRendere.enabled = false;
                foreach (Transform childTransform in transform)
                {
                    childTransform.gameObject.SetActive(false);

                    break;
                }

                Brock.SetActive(true);

                GetComponent<Changegenerated_effect>().PlayEffect();


            }
        }

        

        if (!bSolid)
        {
            if (other.tag == "Player")
            {
                GameObject.FindGameObjectWithTag("Audio").GetComponent<GAudio>().DamageSE2Play();

                PlayerStatus playerStatus = other.GetComponent<PlayerStatus>();
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>().Shake(5.0f, 0.3f);

                playerStatus.SetHp(playerStatus.GetHp() - Damage);


                Destroy(this.gameObject.transform.parent.gameObject);
            }
        }else if(other.tag == "Foot")
        {
            bTouchFoot = true;
           
        }
       
    }


    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Foot")
        {
            bTouchFoot = false;
        }
    


        //if (other.tag == "Screen")
        //{
        //    if (bSolid)
        //    {
        //        Debug.Log("破壊");
        //        Destroy(this.gameObject.transform.parent.gameObject);
        //    }
        //}

        //if (other.tag == "ThatScreen")
        //{

        //    bSolid = true;
        //    myCollider.isTrigger = false;

        //}
    }

    


    public void SetPlayer(GameObject _Player)
    {

        Player = _Player;

        myCollider = transform.GetComponent<Collider>();

       
    }
}

/**
* @file distortion.cs
* @brief distortionクラスの実装
* @author 倉　和規
* @date 5/5
*
* @details 
* @note 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObjScript : MonoBehaviour
{
    [Header("プレイヤーに当たった時のダメージ")]
    [SerializeField]
    public int Damage;

    [Header("初期性質を設定（trueで最初は実体を持つ）")]
    [SerializeField]
    private bool bTouch;

    [Header("PlayerをD＆D")]
    [SerializeField]
    private GameObject Player;

    private generated_effect HitEffect;

    private void OnValidate()
    {
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

        HitEffect = GetComponent<generated_effect>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
       
        if (bTouch)
        {
            if (other.tag == "Player")
            {
                Debug.Log("ダメージ！");
                Player.GetComponent<PlayerStatus>().SetHp(Player.GetComponent<PlayerStatus>() .GetHp() - Damage);
                HitEffect.generate_Effect_Hit((this.transform.position + other.transform.position) / 2);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //Destroy(this);

        if (other.gameObject.tag == "Gage")
        {

            //// isTrigger切替
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

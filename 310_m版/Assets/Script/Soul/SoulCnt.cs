/**
* @file SoulCnt.cs
* @brief SoulCntクラスの実装
* @author 倉　和規
* @date 5/5
*
* @details 
* @note 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/** クラスの概要説明 */
/**
* 機能：
* ・put状態の魂の数を数えて、規定数以上になったらクリアフラグを立てる
* 使い方:
* １　Souの親オブジェクトにアタッチ
*/


public class SoulCnt : MonoBehaviour
{
    //魂の量
    public int CoinCount;
    PlayerMove PlayerMoveScript;//0523追記

    ParticleSystem ps;
    void Start()
    {
        PlayerMoveScript = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        ps = GameObject.Find("eff_hanabi").GetComponent<ParticleSystem>();
  
    }

    //魂破壊の時
    public void DelSoul()
    {
        //Score.x -= 1;

        //魂の量 -1
        CoinCount -= 1;

        //SoulScore.destroyCount += 1;

        //GameObject.Find("SoullconPanel").GetComponent<SoulScore>().UpdatePlayerIcons();

        GameObject.Find("AudioController").GetComponent<GAudio>().SoulGetSEPlay();
        //こういう時
        if (CoinCount <= 0)
        {
            GameObject.Find("AudioController").GetComponent<GAudio>().ClearSEPlay();

            ClearShow.DanChu = true;

            PlayerMoveScript.SetMoveFlg(false);//クリア時移動させない

            ps.Play();
        }

    }

}

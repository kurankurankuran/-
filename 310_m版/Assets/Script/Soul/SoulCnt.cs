/**
* @file SoulCnt.cs
* @brief SoulCnt�N���X�̎���
* @author �q�@�a�K
* @date 5/5
*
* @details 
* @note 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/** �N���X�̊T�v���� */
/**
* �@�\�F
* �Eput��Ԃ̍��̐��𐔂��āA�K�萔�ȏ�ɂȂ�����N���A�t���O�𗧂Ă�
* �g����:
* �P�@Sou�̐e�I�u�W�F�N�g�ɃA�^�b�`
*/


public class SoulCnt : MonoBehaviour
{
    //���̗�
    public int CoinCount;
    PlayerMove PlayerMoveScript;//0523�ǋL

    ParticleSystem ps;
    void Start()
    {
        PlayerMoveScript = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
        ps = GameObject.Find("eff_hanabi").GetComponent<ParticleSystem>();
  
    }

    //���j��̎�
    public void DelSoul()
    {
        //Score.x -= 1;

        //���̗� -1
        CoinCount -= 1;

        //SoulScore.destroyCount += 1;

        //GameObject.Find("SoullconPanel").GetComponent<SoulScore>().UpdatePlayerIcons();

        GameObject.Find("AudioController").GetComponent<GAudio>().SoulGetSEPlay();
        //����������
        if (CoinCount <= 0)
        {
            GameObject.Find("AudioController").GetComponent<GAudio>().ClearSEPlay();

            ClearShow.DanChu = true;

            PlayerMoveScript.SetMoveFlg(false);//�N���A���ړ������Ȃ�

            ps.Play();
        }

    }

}

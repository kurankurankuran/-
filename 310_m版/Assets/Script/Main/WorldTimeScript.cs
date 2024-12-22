/**
* @file WorldTimeScript.cs
* @brief WorldTimeScript�N���X�̎���
* @author �q�@�a�K
* @date 5/5
*
* @details 
* @note 
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/** �N���X�̊T�v���� */
/**
* �@�\�F
* �ETimeScale���w�莞�ԁiunscaledDeltaTime�j����0�ɂ���
* �g����:
* �P�@��]�����q�I�u�W�F�N�g�Ƃ���e�I�u�W�F�N�g�ɃA�^�b�`����
* �Q�@TimeStop(float stopTime)���~�߂������Ԃ����~�߂�
* �R�@�ȏ�
*/


public class WorldTimeScript : MonoBehaviour
{
    private static bool Stop = false;
    private static float StopTime = 0;
    private float StopCnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Stop)
        {
            StopCnt += Time.unscaledDeltaTime;

            if (StopTime < StopCnt)
            {
                StopCnt = 0;
                Stop = false;
                Time.timeScale = 1;

            }
        }
    }

    public static void TimeStop(float stopTime)
    {
        Time.timeScale = 0;
        Stop = true;
        StopTime = stopTime;
    }
}

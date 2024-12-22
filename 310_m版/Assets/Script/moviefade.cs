/**
* @file moviefade.cs
* @brief moviefade�N���X�̎���
* @author �q�@�a�K
* @date 5/5\27
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
* �E���[�r�[�p�t�F�[�h�����p
* 
* �g����:
* �P�@��̃I�u�W�F�N�g�ɃA�^�b�`����x�L�[
*/

public class moviefade : MonoBehaviour
{
    //�摜
    [SerializeField]
    private Texture image;

    //�����l
    float alpha;
    //�t�F�[�h���x
    public float speed;

    private bool bOut;

    private bool bFadeNow;

    // Start is called before the first frame update
    void Start()
    {
        bFadeNow = false;
        bOut = true;
        alpha = 0.0f;
    }

    private void OnGUI()
    {
        if (!bFadeNow)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                bFadeNow = true;
               
            }
        }
        else
        {
            if (bOut)
            {
                alpha += speed;

                if (alpha >= 1.0)
                {
                    bFadeNow = false;
                    bOut = false;
                }
            }
            else
            {
                alpha -= speed;

                if (alpha <= 0.0)
                {
                    bFadeNow = false;
                    bOut = true;
                }
            }
        }




        //�摜��color
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        //��ʑS�̓I�ɕ\��
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), image);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

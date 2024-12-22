using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadShow : MonoBehaviour
{

    //�摜
    public Texture image;

    //�����l
    static float alpha = 0f;
    //�t�F�[�h���x
    public float speed;
    //�t�F�[�h�C��
    public static bool DanChu = false;
    public static bool Danru = false;


    public int Shijian = 0;
    //�V�[���̔ԍ�
    public int Number;
    private void OnGUI()
    {
        //�X�C�b�`ON�̎�
        if (DanChu)
        {
            
            Time.timeScale = 0;

            alpha += speed * Time.unscaledDeltaTime;



            //������������������
            if (alpha >= 1)
            {

                //�X�C�b�`off
                DanChu = false;
              

            }
        }


        //�摜��color
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        //��ʑS�̓I�ɕ\��
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), image);

        //�X�C�b�`ON�̎�
        if (Danru)
        {
            //�t�F�[�h�A�E�g�J�n

            alpha -= speed * Time.unscaledDeltaTime;
            //������������������
            if (alpha <= 0)
            {
                Time.timeScale = 1;//����
                //�X�C�b�`off
                Danru = false;

                //�t�F�[�h�C���J�n
                fade.DanChu = true;
                //�s�������V�[���̔ԍ�
                fade.ScenesNum = Number;

            }
        }

    }
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (alpha >= 1)
        {
            Shijian--;

            if (Shijian == 0)
            {
                Danru = true;
            }
        }
    }
}

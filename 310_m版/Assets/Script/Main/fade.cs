//**************************************************************:
// �@�\�F
// �E�V�[���؂�ւ�鎞�̉��o
//**************************************************************�F
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class fade : MonoBehaviour
{
    //�摜
    public Texture image;
    //�����l
    static float alpha = 0f;
    //�t�F�[�h�C��
    public static bool DanChu = false;
    //�t�F�[�h�A�E�g
    public static bool Danru = false;
    //�t�F�[�h���x
    public float speed = 0.002f;
    //�V�[���̔ԍ�
    public static int ScenesNum;

    //private bool Show = true;
  
    public void OnGUI()
    {
        //�X�C�b�`ON�̎�
        if (DanChu)
        {

            //Time.timeScale = 0;//�����Ȃ�
            WorldTimeScript.TimeStop(10.0f);
            //�t�F�[�h�C���J�n
            alpha += speed /*Time.unscaledDeltaTime*/;
            //alpha += speed * Time.deltaTime;

            //������������������
            if (alpha>=1)
            {
                //�V�[���J��
                SceneManager.LoadScene(ScenesNum);
                //�X�C�b�`off
                DanChu = false;
                //�t�F�[�h�A�E�g�J�n
                Danru = true;
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
            alpha -= speed /*Time.unscaledDeltaTime*/;
            //alpha -= speed * Time.deltaTime;

            //������������������
            if (alpha <= 0.8f)
            {
                //if (Show)
                //{

                    
                    //Show = false;
                    //// �R���[�`���̋N��
                    //StartCoroutine(DelayCoroutine());
                //}
            }


            if (alpha <= 0)
            {
                //Time.timeScale = 1;//����
                //�X�C�b�`off
                Danru = false;

                //StartShow.DanChu = true;
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

       


    }


    //// �R���[�`���{��
    //private IEnumerator DelayCoroutine()
    //{
     
    //    // 3�b�ԑ҂�
    //    yield return new WaitForSeconds(3);

    //    Debug.Log("ssss");
    //    StartShow.DanChu = true;
    //}
  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartShow : MonoBehaviour
{

    //�摜
    public Texture image;
 
    //�����l
    float alpha = 0.0f;
    //�t�F�[�h���x
    public float speed;
    //�t�F�[�h�C��
    public bool DanChu = false;
    public bool Danru = false;

    public int Shijian = 0;

    private bool flag = true;
    private float StartTime = 0;
    private GameObject Player;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnGUI()
    {
        if (flag)
        {
           
            //StartTime += Time.unscaledDeltaTime;
            StartTime += Time.deltaTime;


            //Player.GetComponent<PlayerMove>().SetMoveFlg(false);
            if (StartTime > 16.0f)
            {
                

                //// �R���[�`���̋N��
                //StartCoroutine(DelayCoroutine());
                DanChu = true;
                flag = false;
            }

        }
       
       
        //�X�C�b�`ON�̎�
        if (DanChu)
        {
            //Debug.Log(Time.unscaledDeltaTime);

            //Time.timeScale = 0;

            alpha += speed/* * Time.unscaledDeltaTime*/;
            //alpha += speed * Time.deltaTime;



            //������������������
            if (alpha >= 1.0)
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

            alpha -= speed /** Time.unscaledDeltaTime*/;
            //alpha -= speed * Time.deltaTime;
            //������������������
            if (alpha <= 0)
            {
                //Time.timeScale = 1;//����
                //�X�C�b�`off

               
                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    //Debug.Log("1111");
                    Tutorial.PlayTutorial(Tutorial.TUTORIAL.START_TUTORIAL);
                }
                else if(SceneManager.GetActiveScene().buildIndex == 10)
                {
                    Tutorial.PlayTutorial(Tutorial.TUTORIAL.DARKSOUL_TUTORIAL);
                }
                else
                {
                   
                    Player.GetComponent<PlayerMove>().SetMoveFlg(true);
                }

                
                Danru = false;

            }
        }

    }
    // Start is called before the first frame update
    void Start()
    {
      

        Player.GetComponent<PlayerMove>().SetMoveFlg(false);
        GameObject.FindGameObjectWithTag("Audio").GetComponent<GAudio>().StartJinglePlay();
        

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


    // �R���[�`���{��
    private IEnumerator DelayCoroutine()
    {

        // 3�b�ԑ҂�
        yield return new WaitForSeconds(3);

        
        DanChu = true;
    }
}

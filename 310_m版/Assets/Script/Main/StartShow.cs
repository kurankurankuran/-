using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartShow : MonoBehaviour
{

    //画像
    public Texture image;
 
    //透明値
    float alpha = 0.0f;
    //フェード速度
    public float speed;
    //フェードイン
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
                

                //// コルーチンの起動
                //StartCoroutine(DelayCoroutine());
                DanChu = true;
                flag = false;
            }

        }
       
       
        //スイッチONの時
        if (DanChu)
        {
            //Debug.Log(Time.unscaledDeltaTime);

            //Time.timeScale = 0;

            alpha += speed/* * Time.unscaledDeltaTime*/;
            //alpha += speed * Time.deltaTime;



            //こういう時だったら
            if (alpha >= 1.0)
            {
               
                //スイッチoff
                DanChu = false;
               
               
            }
        }

       
        //画像のcolor
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        //画面全体的に表示
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), image);

        //スイッチONの時
        if (Danru)
        {
            //フェードアウト開始

            alpha -= speed /** Time.unscaledDeltaTime*/;
            //alpha -= speed * Time.deltaTime;
            //こういう時だったら
            if (alpha <= 0)
            {
                //Time.timeScale = 1;//動く
                //スイッチoff

               
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


    // コルーチン本体
    private IEnumerator DelayCoroutine()
    {

        // 3秒間待つ
        yield return new WaitForSeconds(3);

        
        DanChu = true;
    }
}

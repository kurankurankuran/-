using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadShow : MonoBehaviour
{

    //画像
    public Texture image;

    //透明値
    static float alpha = 0f;
    //フェード速度
    public float speed;
    //フェードイン
    public static bool DanChu = false;
    public static bool Danru = false;


    public int Shijian = 0;
    //シーンの番号
    public int Number;
    private void OnGUI()
    {
        //スイッチONの時
        if (DanChu)
        {
            
            Time.timeScale = 0;

            alpha += speed * Time.unscaledDeltaTime;



            //こういう時だったら
            if (alpha >= 1)
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

            alpha -= speed * Time.unscaledDeltaTime;
            //こういう時だったら
            if (alpha <= 0)
            {
                Time.timeScale = 1;//動く
                //スイッチoff
                Danru = false;

                //フェードイン開始
                fade.DanChu = true;
                //行きたいシーンの番号
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

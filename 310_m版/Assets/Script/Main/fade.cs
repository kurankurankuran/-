//**************************************************************:
// 機能：
// ・シーン切り替わる時の演出
//**************************************************************：
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class fade : MonoBehaviour
{
    //画像
    public Texture image;
    //透明値
    static float alpha = 0f;
    //フェードイン
    public static bool DanChu = false;
    //フェードアウト
    public static bool Danru = false;
    //フェード速度
    public float speed = 0.002f;
    //シーンの番号
    public static int ScenesNum;

    //private bool Show = true;
  
    public void OnGUI()
    {
        //スイッチONの時
        if (DanChu)
        {

            //Time.timeScale = 0;//動かない
            WorldTimeScript.TimeStop(10.0f);
            //フェードイン開始
            alpha += speed /*Time.unscaledDeltaTime*/;
            //alpha += speed * Time.deltaTime;

            //こういう時だったら
            if (alpha>=1)
            {
                //シーン遷移
                SceneManager.LoadScene(ScenesNum);
                //スイッチoff
                DanChu = false;
                //フェードアウト開始
                Danru = true;
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
            alpha -= speed /*Time.unscaledDeltaTime*/;
            //alpha -= speed * Time.deltaTime;

            //こういう時だったら
            if (alpha <= 0.8f)
            {
                //if (Show)
                //{

                    
                    //Show = false;
                    //// コルーチンの起動
                    //StartCoroutine(DelayCoroutine());
                //}
            }


            if (alpha <= 0)
            {
                //Time.timeScale = 1;//動く
                //スイッチoff
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


    //// コルーチン本体
    //private IEnumerator DelayCoroutine()
    //{
     
    //    // 3秒間待つ
    //    yield return new WaitForSeconds(3);

    //    Debug.Log("ssss");
    //    StartShow.DanChu = true;
    //}
  
}

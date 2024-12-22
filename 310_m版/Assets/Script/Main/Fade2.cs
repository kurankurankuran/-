using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Fade2 : MonoBehaviour
{
    public Image bgimages;

    public float showTime = 5;
    public float ShowTimeTrigger = 0;


    //透明値
    static float alpha = 1f;
    //フェード速度
    public float speed = 0.002f;

    //public float fadeTime = 3;
    //public float fadeTimeTrigger = 0;
    //private bool show = true;
    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
            //フェードイン開始
            alpha -= speed /*Time.unscaledDeltaTime*/;
            bgimages.color = new Color(1, 1, 1,alpha );

            //GameObject.Find("Parameter").GetComponent<CanvasGroup>().alpha = alpha;
        //こういう時だったら
        //if (alpha <= 0.0f)
        //    {
        //        //シーン遷移
        //        SceneManager.LoadScene(2);
                
        //        //フェードアウト開始
        //        // Danru = true;
        //    }
            //    if (fadeTimeTrigger >= 0 && fadeTimeTrigger < fadeTime)
            //    {
            //        fadeTimeTrigger += Time.deltaTime;
            //        if (show)
            //        {
            //            bgimages.color = new Color(1, 1, 1, 1 - (fadeTimeTrigger / fadeTime));




            //        }
            //        else
            //        {
            //            bgimages.color = new Color(1, 1, 1, (fadeTimeTrigger / fadeTime));

            //        }
            //    }
            //    else
            //    {
            //        SceneManager.LoadScene(1);
            //        fadeTimeTrigger = 0;
            //        ShowTimeTrigger = 0;

            //        if (show)
            //        {
            //            show = false;
            //        }
            //        else
            //        {
            //            show = true;
            //        }
            //    }
        

        }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public Slider slider;
    public Text text;
    public GameObject Load;
    float loadPro = 0;

    private static AsyncOperation AsyncOp = null;

    private int currentSceneNum;

    void Start()
    {
        currentSceneNum = SceneManager.GetActiveScene().buildIndex;
        slider.value = 0;
       
    }

    void Update()
    {

        if (currentSceneNum == 0 || currentSceneNum == 1)
        {
            if (AsyncOp != null)
            {
                Load.SetActive(true);
                loadPro = AsyncOp.progress;
            }
            if (loadPro >= 0.9f)
            {
                loadPro = 1;
            }
            slider.value = Mathf.Lerp(slider.value, loadPro, 1 * Time.deltaTime);
            if (slider.value > 0.99f)
            {
                slider.value = 1;

                wavefade.FadeStart();
                //AsyncOp.allowSceneActivation = true;
                //WaterWaveFade.Onoff = true;

            }
            text.text = string.Format("{0:F0}%", slider.value * 100);


        }

    }




    public static void StartLoad(int Num)
    {
        if (AsyncOp == null)
        {
            AsyncOp = SceneManager.LoadSceneAsync(Num, LoadSceneMode.Single);
            AsyncOp.allowSceneActivation = false;

            if(SceneManager.GetActiveScene().buildIndex == 1)
            GameObject.Find("UI_Select").SetActive(false);
        }
    }

    public static void StartLoad()
    {
        if (AsyncOp == null)
        {
          
            AsyncOp = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
            AsyncOp.allowSceneActivation = false;
            wavefade.FadeStart();
        }
       
    }

    public static void ReLoad()
    {
        if (AsyncOp == null)
        {
            AsyncOp = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
            AsyncOp.allowSceneActivation = false;
            wavefade.FadeStart();
        }

    }

    public static void StartNextScene()
    {
     
        AsyncOp.allowSceneActivation = true;
    }

    public static void SetNull()
    {
        AsyncOp = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

//==============================================================
// pauseボタンと十字キー上下、決定ボタンを各if文条件式に追記
//==============================================================

public class Pause : MonoBehaviour
{
    public GameObject Menu;

    private static bool Onoff;
    private bool UIOnoff;

    public GameObject[] SelecUIAnim;
    public Animator[] UIanim;

    public int currState = 0;


    private bool bInput = false;


    private GAudio gAudio;

    private bool bCursolMove;

    public void PauseOnButton()
    {

        Time.timeScale = 0;

    }

    public void PauseOffButton()
    {

        Time.timeScale = 1;
    }

    public void QuitButton()
    {
        Debug.Log("QUIT!");

        Application.Quit();
    }

    public void SelectButton()
    {
        //SceneManager.LoadScene(1);
        LoadScene.StartLoad();
    }

    public void ReopenButton()
    {
        //Time.timeScale = 1;
        //WorldTimeScript.TimeStop(10.0f);

        int index = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(index);
        LoadScene.ReLoad();

    }
    public void SwitchOnoff()
    {
        Onoff = !Onoff;
    }

    // Start is called before the first frame update
    void Start()
    {
        bCursolMove = true;

        Onoff = false;
      
        gAudio = GameObject.Find("AudioController").GetComponent<GAudio>();
        //UIanim[0].Play("UI1");

    }

    // Update is called once per frame
    void Update()
    {

        if (bCursolMove)
        {

            if (Input.GetKeyDown(KeyCode.P) || Input.GetButtonDown("Pause"))//Pause追記
            {
                SwitchOnoff();
                MenuActive();
                gAudio.AudioJSE.Play();
            }

            if (UIOnoff == true)
            {

                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Con_Vertical") <= -1 || Input.GetAxisRaw("D_pad_V") > 0)//十字キー上下:D_pad_V追記
                {
                    if (!bInput)
                    {

                        currState -= 1;
                        SetAnim();

                        bInput = true;
                        gAudio.AudioSSE.Play();
                    }
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetAxisRaw("Vertical") < 0 || Input.GetAxisRaw("Con_Vertical") >= 1 || Input.GetAxisRaw("D_pad_V") < 0)//十字キー上下:D_pad_V追記
                {
                    if (!bInput)
                    {

                        currState += 1;
                        SetAnim();

                        bInput = true;
                        gAudio.AudioSSE.Play();
                    }
                }
                else
                {
                    bInput = false;
                }


                if (currState == 4)
                {
                    currState = 0;
                    SetAnim();

                }

                if (currState == -1)
                {
                    currState = 3;
                    SetAnim();
                }


                if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Con_Ok"))//Con_Ok:コントローラーでの決定ボタン追記
                {
                    SetNum();
                    gAudio.AudioJSE.Play();
                }



            }


        }
    }

    public static bool GetOnoffflg()
    {
        return Onoff;
    }


    private void MenuActive()
    {
        if (Onoff == true)
        {
            Menu.SetActive(true);
            PauseOnButton();
            UIOnoff = true;
            currState = 0;
            SetAnim();



        }
        if (Onoff == false)
        {
            Menu.SetActive(false);
            PauseOffButton();
            UIOnoff = false;

        }

    }

    private void SetNum()
    {
        switch (currState)
        {
            case 0:
                Menu.SetActive(false);
                PauseOffButton();
                Onoff = false;
                UIOnoff = false;
                break;
            case 1:
                bCursolMove = false;

                Onoff = false;
                ReopenButton();
               
                break;
            case 2:
                bCursolMove = false;

                SelectButton();
                Onoff = false;
                break;
            case 3:
                QuitButton();
                EndGame();
                break;
        }

    }

    private void SetAnim()
    {
        switch (currState)
        {
            case 0:

                SelecUIAnim[0].GetComponent<CanvasGroup>().alpha = 1;
                SelecUIAnim[1].GetComponent<CanvasGroup>().alpha = 0;
                SelecUIAnim[2].GetComponent<CanvasGroup>().alpha = 0;
                SelecUIAnim[3].GetComponent<CanvasGroup>().alpha = 0;

                break;
            case 1:

                SelecUIAnim[1].GetComponent<CanvasGroup>().alpha = 1;
                SelecUIAnim[2].GetComponent<CanvasGroup>().alpha = 0;
                SelecUIAnim[3].GetComponent<CanvasGroup>().alpha = 0;
                SelecUIAnim[0].GetComponent<CanvasGroup>().alpha = 0;
                break;
            case 2:

                SelecUIAnim[2].GetComponent<CanvasGroup>().alpha = 1;
                SelecUIAnim[1].GetComponent<CanvasGroup>().alpha = 0;
                SelecUIAnim[0].GetComponent<CanvasGroup>().alpha = 0;
                SelecUIAnim[3].GetComponent<CanvasGroup>().alpha = 0;
                break;
            case 3:

                SelecUIAnim[3].GetComponent<CanvasGroup>().alpha = 1;
                SelecUIAnim[1].GetComponent<CanvasGroup>().alpha = 0;
                SelecUIAnim[2].GetComponent<CanvasGroup>().alpha = 0;
                SelecUIAnim[0].GetComponent<CanvasGroup>().alpha = 0;
                break;
        }

    }

    public void EndGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }

}

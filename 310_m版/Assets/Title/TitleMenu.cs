using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenu : MonoBehaviour
{
    GameObject menuObj;

    GameObject optionArrowRObj;
    GameObject optionArrowLObj;
    GameObject option;

    private Vector3 pos;
    private GameObject arrow;

    private bool bInput;

    private AudioController tAudio;

    private bool bNowLoeding;

    // Start is called before the first frame update
    void Start()
    {
        bNowLoeding = false;

        bInput = false;

        tAudio = GameObject.Find("TitleSound").GetComponent<AudioController>();

        menuObj = GameObject.Find("MenuManager");

        optionArrowRObj = GameObject.Find("Option_arrowR");
        optionArrowLObj = GameObject.Find("Option_arrowL");
        option = GameObject.Find("Option");

        arrow = GameObject.Find("TitleLogo_arrow");
        pos = new Vector3(arrow.transform.position.x, arrow.transform.position.y, arrow.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TitleControll()
    {
        if (!bNowLoeding)
        {

            if (pos.z == -18.0f)
            {
                if (!bInput)
                {
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)
                           || Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Con_Vertical") <= -1 || Input.GetAxisRaw("D_pad_V") < 0
                        || Input.GetAxisRaw("Vertical") < 0 || Input.GetAxisRaw("Con_Vertical") >= 1 || Input.GetAxisRaw("D_pad_V") > 0

                        )
                    {
                        pos.z = -29.0f;
                        tAudio.AudioSSE.Play();
                        bInput = true;
                    }

                }
                else if (!(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)
                           || Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Con_Vertical") <= -1 || Input.GetAxisRaw("D_pad_V") < 0
                        || Input.GetAxisRaw("Vertical") < 0 || Input.GetAxisRaw("Con_Vertical") >= 1 || Input.GetAxisRaw("D_pad_V") > 0))
                {
                    bInput = false;
                }

                if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Con_Ok"))
                {
                    bNowLoeding = true;
                    tAudio.SEPlay();
                    //GameObject.Find("Load_Canvas").GetComponent<LoadScene>().StartLoad(1);
                    LoadScene.StartLoad(1);

                    
                }
            }
            else
            {
                if (!bInput)
                {
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)
                           || Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Con_Vertical") <= -1 || Input.GetAxisRaw("D_pad_V") < 0
                        || Input.GetAxisRaw("Vertical") < 0 || Input.GetAxisRaw("Con_Vertical") >= 1 || Input.GetAxisRaw("D_pad_V") > 0
                        )
                    {
                        pos.z = -18.0f;
                        tAudio.AudioSSE.Play();
                        bInput = true;
                    }

                }
                else if (!(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)
                           || Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Con_Vertical") <= -1 || Input.GetAxisRaw("D_pad_V") < 0
                        || Input.GetAxisRaw("Vertical") < 0 || Input.GetAxisRaw("Con_Vertical") >= 1 || Input.GetAxisRaw("D_pad_V") > 0))
                {
                    bInput = false;
                }

                if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Con_Ok"))
                {
                    optionArrowRObj.SetActive(true);
                    optionArrowLObj.SetActive(true);
                    option.SetActive(true);
                    menuObj.GetComponent<MenuManager>().SwitchMenu();
                    tAudio.AudioJSE.Play();

                    tAudio.SwitchAudioControll(true);
                }
            }


            arrow.transform.position = pos;
        }
    }
}

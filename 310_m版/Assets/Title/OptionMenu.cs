using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
   
    GameObject menuObj;
    GameObject SoundObj;

    GameObject optionArrowRObj;
    GameObject optionArrowLObj;
    GameObject option;

    private Vector3 posL;
    private Vector3 posR;
    private GameObject arrowL;
    private GameObject arrowR;

    private float posLHighX = -40.0f;
    private float posLHighY = 50.0f;
    private float posLHighZ = -0.3f;
    private float posRHighX = 40.0f;
    private float posRHighY = 50.0f;
    private float posRHighZ = -0.3f;
    private float posLLowX = -14.0f;
    private float posLLowY = 50.0f;
    private float posLLowZ = -21.5f;
    private float posRLowX = 14.0f;
    private float posRLowY = 50.0f;
    private float posRLowZ = -21.5f;

    private AudioController gAudio;

    private bool bInput;

    private OPTION  CurrentOption;

    public enum OPTION
    {
        NONE_OPTION = 0,
        PARAM_OPTION,
        EXIT_OPTION,

        MAX_OPTION
    }

    private void Awake()
    {
        optionArrowRObj = GameObject.Find("Option_arrowR");
        optionArrowLObj = GameObject.Find("Option_arrowL");
        option = GameObject.Find("Option");

        arrowL = GameObject.Find("Option_arrowL");
        arrowR = GameObject.Find("Option_arrowR");
    }

    // Start is called before the first frame update
    void Start()
    {
        bInput = false;
        menuObj = GameObject.Find("MenuManager");
        SoundObj = GameObject.Find("TitleSound");
     
        CurrentOption = OPTION.PARAM_OPTION;

        posL = new Vector3(arrowL.transform.position.x, arrowL.transform.position.y, arrowL.transform.position.z);
        posR = new Vector3(arrowR.transform.position.x, arrowR.transform.position.y, arrowR.transform.position.z);
      
        gAudio = GameObject.Find("TitleSound").GetComponent<AudioController>();

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OptionControll()
    {
     
        if (CurrentOption == OPTION.PARAM_OPTION/*posL.x == posLHighX && posR.x == posRHighX*/)
        {
            
            if (!bInput)
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)
                    || Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Con_Vertical") <= -1 || Input.GetAxisRaw("D_pad_V") < 0
                    || Input.GetAxisRaw("Vertical") < 0 || Input.GetAxisRaw("Con_Vertical") >= 1 || Input.GetAxisRaw("D_pad_V") > 0
                    )
                {
                    posL.x = posLLowX;
                    posR.x = posRLowX;
                    posL.y = posLLowY;
                    posR.y = posRLowY;
                    posL.z = posLLowZ;
                    posR.z = posRLowZ;
                    gAudio.AudioSSE.Play();
                    gAudio.GetComponent<AudioController>().SwitchAudioControll(false);

                    bInput = true;

                    CurrentOption = OPTION.EXIT_OPTION;
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

            }
        }
        else if(CurrentOption == OPTION.EXIT_OPTION)
        {
          

            if (!bInput)
            {
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)
                 || Input.GetAxisRaw("Vertical") > 0 || Input.GetAxisRaw("Con_Vertical") <= -1 || Input.GetAxisRaw("D_pad_V") < 0
                || Input.GetAxisRaw("Vertical") < 0 || Input.GetAxisRaw("Con_Vertical") >= 1 || Input.GetAxisRaw("D_pad_V") > 0
                )
                {
                    posL.x = posLHighX;
                    posR.x = posRHighX;
                    posL.y = posLHighY;
                    posR.y = posRHighY;
                    posL.z = posLHighZ;
                    posR.z = posRHighZ;
                    gAudio.AudioSSE.Play();

                    gAudio.GetComponent<AudioController>().SwitchAudioControll(true);

                    bInput = true;

                    CurrentOption = OPTION.PARAM_OPTION;
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
                posL.x = posLHighX;
                posR.x = posRHighX;
                posL.y = posLHighY;
                posR.y = posRHighY;
                posL.z = posLHighZ;
                posR.z = posRHighZ;



                optionArrowRObj.SetActive(false);
                optionArrowLObj.SetActive(false);
                gAudio.AudioKSE.Play();
                option.SetActive(false);
                menuObj.GetComponent<MenuManager>().SwitchMenu();
              


            }
        }

        
        arrowL.transform.position = posL;
        arrowR.transform.position = posR;

      
    }
}

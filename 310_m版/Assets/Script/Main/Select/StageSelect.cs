using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelect : MonoBehaviour
{

    private GameObject CameraObj;
    private ScrollSelect ScrollSelectScript;
    private bool bInputRight = false;
    private bool bInputLeft = false;
    [SerializeField]
    public List<GameObject> StageList = new List<GameObject>();

    static public List<GameObject> StaticStageList = new List<GameObject>();

    static public int CursolNum = 0;

    private SAudio sAudio;

    // １ページ内のステージ数
    public static int PageinStage { get; set; }

    public static bool bNowLoading { get; set; }
    private void Awake()
    {
        PageinStage = 4;
        StaticStageList.Clear();

        for (int i = 0; i < StageList.Count; ++i) 
        {
            StaticStageList.Add(StageList[i]);
        }
       
    }

    // Start is called before the first frame update
    void Start()
    {
        bNowLoading = false;

        sAudio = GameObject.Find("AudioController").GetComponent<SAudio>();

        StageList[CursolNum].transform.GetChild(0).gameObject.SetActive(true);

        CameraObj = GameObject.FindGameObjectWithTag("MainCamera");

        ScrollSelectScript = CameraObj.GetComponent<ScrollSelect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ScrollSelectScript.CursolMove())
        {

            if ((Input.GetKeyDown(KeyCode.D) ||
                Input.GetKeyDown(KeyCode.W) || 
                Input.GetAxisRaw("Con_Horizontal") > 0.2f ||
                Input.GetAxisRaw("D_pad_H") > 0) )
            {
                
                if (!bInputRight)
                {
                    if (Input.GetKeyDown(KeyCode.D) || Input.GetAxis("Con_Horizontal") > 0.2f)
                    {
                        if (StageList.Count - 1 > CursolNum)
                        {
                            sAudio.SSEPlay();
                            if ((CursolNum + 1) % PageinStage == 0)
                            {
                                if (ScrollSelectScript.ScrollUp())
                                {
                                

                                    StageList[CursolNum].transform.GetChild(0).gameObject.SetActive(false);
                                    CursolNum++;
                                    StageList[CursolNum].transform.GetChild(0).gameObject.SetActive(true);
                                }
                            }
                            else
                            {
                                StageList[CursolNum].transform.GetChild(0).gameObject.SetActive(false);
                                CursolNum++;
                                StageList[CursolNum].transform.GetChild(0).gameObject.SetActive(true);
                            }

                        }
                    }
                    else if(Input.GetKeyDown(KeyCode.W) || Input.GetAxisRaw("D_pad_H") > 0)
                    {
                        if (StageList.Count - PageinStage > CursolNum)
                        {
                            sAudio.SSEPlay();

                            if (ScrollSelectScript.ScrollUp())
                            {
                            

                                StageList[CursolNum].transform.GetChild(0).gameObject.SetActive(false);
                                CursolNum = (CursolNum / PageinStage + 1) * PageinStage;
                                StageList[CursolNum].transform.GetChild(0).gameObject.SetActive(true);
                            }


                        }
                    }
                        bInputRight = true;
               
                }
            }
            else
            {
                bInputRight = false;
               
            }

            if ((Input.GetKeyDown(KeyCode.S) || 
                Input.GetKeyDown(KeyCode.A) || 
                Input.GetAxisRaw("Con_Horizontal") < -0.2f ||
                Input.GetAxisRaw("D_pad_H") < 0))
            {
                if (!bInputLeft)
                {
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetAxis("Con_Horizontal") < -0.2f)
                    {
                        if (0 < CursolNum)
                        {
                            sAudio.SSEPlay();

                            if (CursolNum % 4 == 0)
                            {
                                if (ScrollSelectScript.ScrollDown())
                                {
                                 
                                    StageList[CursolNum].transform.GetChild(0).gameObject.SetActive(false);
                                    CursolNum--;
                                    StageList[CursolNum].transform.GetChild(0).gameObject.SetActive(true);
                                }
                            }
                            else
                            {
                                StageList[CursolNum].transform.GetChild(0).gameObject.SetActive(false);
                                CursolNum--;
                                StageList[CursolNum].transform.GetChild(0).gameObject.SetActive(true);
                            }
                        }
                    }
                    else if (Input.GetKeyDown(KeyCode.S) || Input.GetAxisRaw("D_pad_H") < 0)
                    {
                        if (PageinStage <= CursolNum)
                        {
                            sAudio.SSEPlay();

                            if (ScrollSelectScript.ScrollDown())
                            {
                             
                                StageList[CursolNum].transform.GetChild(0).gameObject.SetActive(false);
                                CursolNum = (CursolNum / PageinStage - 1) * PageinStage;
                                StageList[CursolNum].transform.GetChild(0).gameObject.SetActive(true);
                            }


                        }
                    }
                }
                bInputLeft = true;
              
            }
            else
            {
                bInputLeft = false;
               
            }


        }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Con_Ok"))//Con_Ok追記
        {
            SAudio.AudioSE.Play();

            //GameObject.Find("Load_Canvas").GetComponent<LoadScene>().StartLoad(CursolNum + 2);
            LoadScene.StartLoad(CursolNum + 2);

            bNowLoading = true;
        }
    }
}

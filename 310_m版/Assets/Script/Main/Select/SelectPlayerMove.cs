using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlayerMove : MonoBehaviour
{
    private ScrollSelect ScrollSelectScript;

    private int CurrentNum;

    private GameObject CameraObj;

    // Start is called before the first frame update
    void Start()
    {
        CameraObj = GameObject.FindGameObjectWithTag("MainCamera");

        ScrollSelectScript = CameraObj.GetComponent<ScrollSelect>();

        CurrentNum = StageSelect.CursolNum;

        //Vector3 test = StageSelect.StaticStageList[CurrentNum].transform.position;

        Vector3 posVec = new Vector3(
                   StageSelect.StaticStageList[CurrentNum].transform.position.x - CameraObj.transform.position.x,
                   0.0f,
                   StageSelect.StaticStageList[CurrentNum].transform.position.z - CameraObj.transform.position.z);
        posVec.Normalize();

        transform.position = StageSelect.StaticStageList[CurrentNum].transform.position - posVec * 3;

        transform.parent = StageSelect.StaticStageList[CurrentNum].transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (ScrollSelectScript.CursolMove())
        {
           
            if (StageSelect.CursolNum != CurrentNum)
            {
                CurrentNum = StageSelect.CursolNum;

                Vector3 posVec = new Vector3(
                    StageSelect.StaticStageList[CurrentNum].transform.position.x - CameraObj.transform.position.x,
                    0.0f,
                    StageSelect.StaticStageList[CurrentNum].transform.position.z - CameraObj.transform.position.z);
                posVec.Normalize();

                transform.position = StageSelect.StaticStageList[CurrentNum].transform.position - posVec * 3;
                transform.position = new Vector3(transform.position.x, 0.0f, transform.position.z);

                transform.parent = StageSelect.StaticStageList[CurrentNum].transform.GetChild(1);

                
            }
        }
        if (transform.position.y < -0.05f)
        {
            transform.position = new Vector3(transform.position.x, -0.05f, transform.position.z);
        }
    }
}

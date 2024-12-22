using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate: MonoBehaviour
{
   
    private GameObject Distortion;
    private Vector3 SPos;


    private Vector3 result;
    private Vector3 result2;
    private Vector3 CubeVec;
    //private Vector3 targetDir;

    //GAudio gAudio;

    // Start is called before the first frame update
    void Start()
    {
        //gAudio = GameObject.Find("AudioController").GetComponent<GAudio>();
        //gAudio.distSEPlay();
        //中心点
        SPos =new Vector3(0.0f, 0.0f, 0.0f);

        //半径までの位置
        Distortion = GameObject.Find("Gage");
        CubeVec = new Vector3(0.0f, 0.0f, Distortion.GetComponent<CircleDeployer>()._radius);

        //Cube1位置
        //Y軸回転
        result = Quaternion.Euler(0, GameObject.Find("Gage").GetComponent<distortion>().childNum, 0) * CubeVec;

        ////Cube2位置
        ////Y軸回転
        //result2 = Quaternion.Euler(0, GameObject.Find("Gage").GetComponent<distortion>().childNum - 1, 0) * CubeVec;

        ////スピード　　　　　　　　　　　　　　　　　　　　　　　　　20
        //Speed = GameObject.Find("Gage").GetComponent<distortion>().RotTime / 360.0f;

        //最初の位置
        this.transform.position = result;

        //targetDir = result2 - result; // 

        //Speed = Vector3.Angle(transform.forward, targetDir); // 


    }

    // Update is called once per frame
    void Update()
    {
       
        

    }

    public  void SetCubePos(int Num)
    {
        result2 = Quaternion.Euler(0, Num, 0) * CubeVec;
        this.transform.position = result2;
        //transform.RotateAround(SPos, -Vector3.up, Speed);
       
    }

 

   
}

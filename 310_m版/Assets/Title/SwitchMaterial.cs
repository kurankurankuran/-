using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Title Scene UI
// TitleLogo_UI
public class SwitchMaterial : MonoBehaviour
{
    public Material mat1;
    public Material mat2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*var*/string[] controllerNames = Input.GetJoystickNames();

        int currentConnectionCount = 0;
        Debug.Log(controllerNames.Length/*controllerNames[i]*/);
        for (int i = 0; i < controllerNames.Length; i++)
        {
            Debug.Log("コントローラー名");
            Debug.Log(/*controllerNames.Length*/Input.GetJoystickNames()[i]);

            currentConnectionCount++;
            //if (controllerNames[i] != "")
            //{
            //    currentConnectionCount++;
            //}
        }
        Debug.Log("接続数");
        Debug.Log(currentConnectionCount);

        if (/*controllerNames[0].Length*/currentConnectionCount == 0)
        {
            // PC用のマテリアル変換処理
            GetComponent<MeshRenderer>().material = mat1;
        }
        else
        {
            // Xbox controller用のマテリアル変換処理
            GetComponent<MeshRenderer>().material = mat2;
        }


    }
}

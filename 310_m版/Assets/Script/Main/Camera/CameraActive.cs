using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActive : MonoBehaviour
{
    [SerializeField]
    public GameObject CameraObj;

    [SerializeField]
    public GameObject ThatCameraObj;


    //Renderer targetRenderer; // 判定したいオブジェクトのrendererへの参照

    // Start is called before the first frame update
    void Start()
    {
        //targetRenderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (targetRenderer.isVisible)
        //{
        //    // 表示されている場合の処理
        //    CameraObj.SetActive(true);
        //    Debug.Log("カメラOn");
        //}
        //else
        //{
        //    // 表示されていない場合の処理
        //    CameraObj.SetActive(false);
        //    Debug.Log("カメラOff");
        //}
    }

    //private void OnBecameVisible()
    //{

    //    Debug.Log("カメラOn");
    //    CameraObj.SetActive(true);

    //}

    //private void OnBecameInvisible()
    //{
    //    Debug.Log("カメラOff");
    //    CameraObj.SetActive(false);
    //}

}

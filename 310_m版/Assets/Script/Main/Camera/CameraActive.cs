using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraActive : MonoBehaviour
{
    [SerializeField]
    public GameObject CameraObj;

    [SerializeField]
    public GameObject ThatCameraObj;


    //Renderer targetRenderer; // ���肵�����I�u�W�F�N�g��renderer�ւ̎Q��

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
        //    // �\������Ă���ꍇ�̏���
        //    CameraObj.SetActive(true);
        //    Debug.Log("�J����On");
        //}
        //else
        //{
        //    // �\������Ă��Ȃ��ꍇ�̏���
        //    CameraObj.SetActive(false);
        //    Debug.Log("�J����Off");
        //}
    }

    //private void OnBecameVisible()
    //{

    //    Debug.Log("�J����On");
    //    CameraObj.SetActive(true);

    //}

    //private void OnBecameInvisible()
    //{
    //    Debug.Log("�J����Off");
    //    CameraObj.SetActive(false);
    //}

}

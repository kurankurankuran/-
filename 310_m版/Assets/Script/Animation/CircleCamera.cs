using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
public class CircleCamera : MonoBehaviour
{
    [SerializeField]
    private float AxisX = 0.1f; 

    private CinemachineOrbitalTransposer _transposer;

    [SerializeField]
    private CinemachineVirtualCamera _camera; //エディタでVirtual Cameraをアタッチ

    private Vector3 PosVec;

    //[SerializeField]
    //private int RotTime = 0;

    //private int RotCnt = 0;

    //// 円運動周期
    //[SerializeField] private float _period = 2;

    //private float Angle; // 1フレーム毎の回転角度

    // Start is called before the first frame update
    void Start()
    {
        //PosVec = - new Vector3(transform.position.x, transform.position.y, transform.position.z);
        ////Angle = 360.0f / AxisX;
        //_transposer = _camera.GetCinemachineComponent<CinemachineOrbitalTransposer>();
        //transform.forward = Vector3.Cross(-transform.position, transform.up);

        transform.forward = transform.position.normalized;

    }

    private void Update()
    {
        transform.transform.RotateAround(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f), AxisX/*360 / _period * Time.deltaTime*/);
      

        //_transposer.m_XAxis.m_InputAxisValue = AxisX;
        transform.forward = transform.position.normalized;

        Debug.Log(AxisX);

        //transform.position = new Vector3(PosVec.x, PosVec.y, PosVec.z);
        ////transform.forward = Vector3.Cross(transform.position, transform.up);
    }


    //// Update is called once per frame
    //void Update()
    //{
    //    _transposer.m_XAxis.m_InputAxisValue = AxisX;
    //}
}

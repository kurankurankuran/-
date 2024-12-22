using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//!�_�ŗp�N���X
public class Blink : MonoBehaviour
{
    //!�_�ŃX�s�[�h
    [SerializeField] float blinkSpeed = 1.0f;

    //!
    private float time;
    private Color color;

    void Start()
    {
        color = GetComponent<MeshRenderer>().material.color;
    }

    void Update()
    {
        
        //!Alpha�l���X�V
        color = GetAlphaColor(color);
        GetComponent<MeshRenderer>().material.color = color;
    }

    //Alpha�l���X�V����Color��Ԃ�
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * blinkSpeed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//!点滅用クラス
public class Blink : MonoBehaviour
{
    //!点滅スピード
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
        
        //!Alpha値を更新
        color = GetAlphaColor(color);
        GetComponent<MeshRenderer>().material.color = color;
    }

    //Alpha値を更新してColorを返す
    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * blinkSpeed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }
}

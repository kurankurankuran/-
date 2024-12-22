//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;


//public class SwitchTimeBarCtr : MonoBehaviour
//{
//    [SerializeField] GameObject BWObj;
//    BWSwitch script;


//    static int nMaxGage = 5;
//    static int nUpdateGage;
//    Slider[] _slider = new Slider[nMaxGage];

//    public Image[] Background = new Image[nMaxGage];
//    public Image[] Fill = new Image[nMaxGage];

//    void Start()
//    {
//        BWObj = GameObject.Find("BWManager");
//        script = BWObj.GetComponent<BWSwitch>();
//        nUpdateGage = 0;

//        // スライダーを取得する
//        _slider[0] = GameObject.Find("Slider").GetComponent<Slider>();
//        _slider[1] = GameObject.Find("Slider (1)").GetComponent<Slider>();
//        _slider[2] = GameObject.Find("Slider (2)").GetComponent<Slider>();
//        _slider[3] = GameObject.Find("Slider (3)").GetComponent<Slider>();
//        _slider[4] = GameObject.Find("Slider (4)").GetComponent<Slider>();


//        for (int i = 0; i < nMaxGage; ++i)
//        {
//            Background[i].color = Color.white;
//            Fill[i].color = Color.black;
//        }

//        float fMaxValue = script.nSwitchTime / (nMaxGage + 1);

//        _slider[0].maxValue = fMaxValue;
//        _slider[1].maxValue = fMaxValue;
//        _slider[2].maxValue = fMaxValue * 2;
//        _slider[3].maxValue = fMaxValue;
//        _slider[4].maxValue = fMaxValue;

//    }

//    float[] _hp = new float[nMaxGage];

//    void Update()
//    {
//        for (int i = nUpdateGage; i < nMaxGage; ++i)
//        {
//            if (_hp[i] < _slider[i].maxValue)
//            {
//                // HP上昇
//                _hp[i] += 1.0f;

//                if (_hp[i] >= _slider[i].maxValue)
//                {
//                    nUpdateGage = i + 1;
//                }

//                // HPゲージに値を設定
//                _slider[i].value = _hp[i];

//                break;
//            }
//        }
        

//        if (_hp[nMaxGage-1] >= _slider[nMaxGage-1].maxValue)
//        {
//            for (int i = 0; i < nMaxGage; ++i)
//            {
//                _hp[i] = 0;
//                nUpdateGage = 0;
//                // HPゲージに値を設定
//                _slider[i].value = _hp[i];

//                if(Background[i].color == Color.black)
//                {
//                    Background[i].color = Color.white;
//                    Fill[i].color = Color.black;
//                }
//                else
//                {
//                    Background[i].color = Color.black;
//                    Fill[i].color = Color.white;
//                }
//            }
//        }
//    }
//}

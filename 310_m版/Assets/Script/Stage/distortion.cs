/**
* @file distortion.cs
* @brief distortionクラスの実装
* @author 倉　和規
* @date 5/5
*
* @details 
* @note 
*/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//using System.Linq;


/** クラスの概要説明 */
/**
* 機能：
* ・円筒自体の回転
* ・回転柱の回転速度、方向の設定
* ・ねじれの方向、速さの設定
* ・表示のON/OFF
* ・ワイヤーフレーム処理
* 
* 使い方:
* １　回転柱を子オブジェクトとする親オブジェクトにアタッチする
* ２　インスペクターからそれぞれの値を決定
* ３　以上
*/

public class distortion : MonoBehaviour
{
    [Header("回転柱１本ごとの回転速度")]
    [SerializeField]
    public float RotValue;

    [Header("ねじれが一周するまでのフレーム数")]
    [SerializeField]
    public float RotTime;

    [Header("回転柱１本ごとの回転方向を逆にする")]
    [SerializeField]
    private bool RotReverse;

    [Header("ねじれの進行方向を逆にする")]
    [SerializeField]
    private bool distortionReverse;

    [Header("表示のON/OFF")]
    [SerializeField]
    private bool Renderer;

    //[Header("ワイヤーフレーム表示（仮）（RenderのON必須）")]
    //[SerializeField]
    //private bool WireFrame;

    //[Header("円筒の回転速度（実質プレイヤーの移動速度）")]
    //public float RotSpeed;

    //[Header("円柱内側のテクスチャ―群の親オブジェクト")]
    //[SerializeField]
    //private GameObject parentTex;

    // 円柱内側のテクスチャ―群の子オブジェクト
    //private List<GameObject> childTexList = new List<GameObject>();

    //[Header("円柱外側のテクスチャ―群の親オブジェクト")]
    //[SerializeField]
    //private GameObject parentTexOut;

    // 円柱外側のテクスチャ―群の子オブジェクト
    //private List<GameObject> childTexOutList = new List<GameObject>();

    //! 次の回転柱が回転し始めるまでの時間
    private float DiffCnt;

    //! 回転柱全てのオブジェクト格納用List
    private List<GameObject> childList = new List<GameObject>();

    [Header("ねじれ発生場所番号")]
    //[SerializeField]
    //! 回転する回転柱の番号を指す
    public int childNum = 0;
    
    //! これがDiffCntを超えると次の回転柱が回転し始める
    private float childCnt;

    //! それぞれの回転柱に付与されたRotObjスクリプト格納用
    private List<RotObj> RotObjScript = new List<RotObj>();

    //! それぞれの回転柱の角度をRotValue分だけ回転させた回数
    private List<int> RotCnt = new List<int>();

    //! RotCntの値からもとめる,柱が180°回転したときのRotCntの値
    private float RotMax;

    //! 他のスクリプトに回転柱の数を渡す用
    [System.NonSerialized] // publicだがインスペクターに表示しない
    public int MaxPillarNum = 360;

    Rotate distBGM;
    
    
    private void Awake()
    {
        //! 子を取得
        foreach (Transform child in transform)//! transformの要素の数だけ繰り返す（たぶん子オブジェクトのtransformの数だけ繰り返しているはず）
        {
            bool bSkip = false;
            for (int i = 0; i < childList.Count; ++i)
            {
                if (childList[i].gameObject.name == child.gameObject.name)
                {
                    bSkip = true;
                }
            }

            if (!bSkip)
            {
                childList.Add(child.gameObject);
                RotCnt.Add(0);
            }

        }

        //! 数値、アルファベット順にソート
        childList.Sort(
          (a, b) =>
          {
              return string.Compare(a.name, b.name);
          }
        );

        

        //! 値を代入
        MaxPillarNum = childList.Count;





        ///////////////////////////////////////////////////////////////////////////////////

        //! 子オブジェクト（回転柱にRotObjとBWSwitchスクリプトを付与）
        for (int i = 0; i < childList.Count; ++i)
        {
            if (childList[i].GetComponent<RotObj>() == null)
            {
                childList[i].AddComponent<RotObj>();
            }

            //if (childList[i].GetComponent<BWSwitch>() == null)
            //{
            //    childList[i].AddComponent<BWSwitch>();
            //}

            //! それぞれの回転柱に付与されたRotObjスクリプト取得
            RotObjScript.Add(childList[i].GetComponent<RotObj>());


        }




    }

    //Inspectorの内容が変更された時に実行
    private void OnValidate()
    {
        //! 子を取得
        foreach (Transform child in transform)//! transformの要素の数だけ繰り返す（たぶん子オブジェクトのtransformの数だけ繰り返しているはず）
        {
            bool bSkip = false;
            for (int i = 0; i < childList.Count; ++i)
            {
                if (childList[i].gameObject.name == child.gameObject.name)
                {
                    bSkip = true;
                }
            }

            if (!bSkip)
            {
                childList.Add(child.gameObject);
                RotCnt.Add(0);
            }

        }

        //! 数値、アルファベット順にソート
        childList.Sort(
          (a, b) =>
          {
              return string.Compare(a.name, b.name);
          }
        );

        
        //! 値を代入
        MaxPillarNum = childList.Count;

        


        //PlayerMoveScript = GameObject.FindWithTag("Player").GetComponent<PlayerMove>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //RotTime *= 60;

        if(SceneManager.GetActiveScene().buildIndex!=0)
        distBGM = GameObject.Find("DistortionBGM").GetComponent<Rotate>();

        DiffCnt = RotTime / childList.Count;//! 次の柱が回転するまでの時間




        //Debug.Log(DiffCnt);
        childCnt = 0;

        RotMax = 180 / RotValue;

        float distDiff = 180 / RotValue;//! 回転中それぞれが半周にかかるフレーム数
                                        //! float distCnt = distDiff / DiffCnt;
                                        //! Debug.Log(distDiff);


        if (RotReverse)
        {
            RotValue = -RotValue;
        }
       

        
        //! 初期ねじれ位置
        int j = 0;
        if (distortionReverse)
        {

            //childNum = 0;
            for (int i = childNum; i < childNum + distDiff; ++i, ++j)
            {
                childList[i].transform.Rotate(j * -RotValue /** DiffCnt*/, 0.0f, 0.0f);
               

                RotObjScript[i].RotBool = true;

                //RotCnt[i] = j;
                RotCnt[i] = (int)((distDiff - j));

                if (RotCnt[i] >= (int)distDiff)
                {
                    RotObjScript[i].RotBool = false;
                    RotCnt[i] = 0;
                }

            }
            childNum += (int)distDiff;
        }
        else
        {
            //childNum = (int)distCnt;
            for (int i = childNum; i > childNum - distDiff; --i, ++j)
            {
                if (i < 0)
                    return;

                childList[i].transform.Rotate(j * -RotValue /** DiffCnt*/, 0.0f, 0.0f);
               
                RotObjScript[i].RotBool = true;
                
                RotCnt[i] = (int)((distDiff - j));

                if (RotCnt[i] >= (int)distDiff)
                {
                    RotObjScript[i].RotBool = false;
                    RotCnt[i] = 0;
                }
            }

            childNum -= (int)distDiff;
        }
    }

    private void FixedUpdate()
    {
        //! 円筒回転処理と回転柱それぞれの回転処理
        for (int i = 0; i < childList.Count; i++)
        {


            //! 回転柱それぞれの回転処理
            if (!RotObjScript[i].RotBool) continue;

            childList[i].transform.Rotate(RotValue, 0f, 0f/*, Space.Self*/);
            //GameObject.Find("AudioController").GetComponent<GAudio>().NejireSE.Play();


            RotCnt[i]++;
            if (RotCnt[i] >= RotMax/* - 1*/)
            {
                RotObjScript[i].RotBool = false;
                RotCnt[i] = 0;

                //! 子オブジェクトを全て取得する
                foreach (Transform childTransform in RotObjScript[i].transform)
                {
                    childTransform.gameObject.GetComponent<MeshRenderer>().enabled = true;
                }

            }
        }


        //! 隣接する回転させる回転柱を次々に回転させていく処理（ねじれを生み出す）
        childCnt += 1.0f;
        if (childCnt > DiffCnt)
        {
            RotObjScript[childNum].RotBool = true;
           
            //! 子オブジェクトを全て取得する
            foreach (Transform childTransform in RotObjScript[childNum].transform)
            {
                //childTransform.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }

            childCnt = 0;
            if (distortionReverse)
            {
                childNum++;
                if (childNum >= childList.Count)
                {
                    childNum = 0;

                }
            }
            else
            {
                childNum--;
                if (childNum < 0)
                {
                    childNum = childList.Count - 1;

                }

            }

            if (SceneManager.GetActiveScene().buildIndex != 0)
                distBGM.SetCubePos(childNum);
            //GAudio.distBGMPlay();
            //gAudio.distBGMPlay();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //// 円筒回転処理と回転柱それぞれの回転処理
        //for (int i = 0; i < childList.Count; i++)
        //{


        //    // 回転柱それぞれの回転処理
        //    if (!RotObjScript[i].RotBool) continue;
        //    childList[i].transform.Rotate(RotValue, 0f, 0f/*, Space.Self*/);


        //    RotCnt[i]++;
        //    if (RotCnt[i] > RotMax - 1)
        //    {
        //        RotObjScript[i].RotBool = false;
        //        RotCnt[i] = 0;

        //        // 子オブジェクトを全て取得する
        //        foreach (Transform childTransform in RotObjScript[i].transform)
        //        {
        //            childTransform.gameObject.GetComponent<MeshRenderer>().enabled = true;
        //        }

        //    }
        //}


        //// 隣接する回転させる回転柱を次々に回転させていく処理（ねじれを生み出す）
        //childCnt += 0.1f;
        //if (childCnt > DiffCnt)
        //{
        //    RotObjScript[childNum].RotBool = true;

        //    // 子オブジェクトを全て取得する
        //    foreach (Transform childTransform in RotObjScript[childNum].transform)
        //    {
        //        //childTransform.gameObject.GetComponent<MeshRenderer>().enabled = false;
        //    }

        //    childCnt = 0;
        //    if (distortionReverse)
        //    {
        //        childNum++;
        //        if (childNum >= childList.Count)
        //        {
        //            childNum = 0;

        //        }
        //    }
        //    else
        //    {
        //        childNum--;
        //        if (childNum < 0)
        //        {
        //            childNum = childList.Count - 1;

        //        }

        //    }
        //}


    }

}

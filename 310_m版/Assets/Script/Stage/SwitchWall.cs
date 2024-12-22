//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class SwitchWall : MonoBehaviour
//{


//    // 自身のコライダー格納用（isTrigger切替用）
//    private Collider m_ObjectWCollider;

//    [Header("初期性質を設定（trueで最初は実体を持つ）")]
//    [SerializeField]
//    private bool bInstance;

//    // 自身のメッシュレンダラー取得
//    MeshRenderer myMeshRendere;

//    private void OnValidate()
//    {
//        myMeshRendere = GetComponent<MeshRenderer>();

//        // 自身のコライダー取得
//        m_ObjectWCollider = GetComponent<Collider>();

//        // 表示切替とisTrigger設定
//        if (bInstance)
//        {
//            myMeshRendere.enabled = true;
           



//            m_ObjectWCollider.isTrigger = false;

//        }
//        else
//        {
//            myMeshRendere.enabled = false;

            
//            m_ObjectWCollider.isTrigger = true;

//        }


//    }



//    // Start is called before the first frame update
//    void Start()
//    {
//        myMeshRendere = GetComponent<MeshRenderer>();

    

//        // 自身のコライダー取得
//        m_ObjectWCollider = GetComponent<Collider>();

//        // 表示切替とisTrigger設定
//        if (bInstance)
//        {
//            myMeshRendere.enabled = true;


//            m_ObjectWCollider.isTrigger = false;

//        }
//        else
//        {
//            myMeshRendere.enabled = false;

            
//            m_ObjectWCollider.isTrigger = true;

//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

//    private void OnTriggerExit(Collider other)
//    {

//        if (other.gameObject.tag == "Gage")
//        {
          

//            // isTrigger切替
//            m_ObjectWCollider.isTrigger = !m_ObjectWCollider.isTrigger;



//            // 透明度切替
//            if (m_ObjectWCollider.isTrigger)
//            {
//                myMeshRendere.enabled = false;
              

//            }
//            else
//            {
//                myMeshRendere.enabled = true;
               

//            }
//        }
//    }
//}

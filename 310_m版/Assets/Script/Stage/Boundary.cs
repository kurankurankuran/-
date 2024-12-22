///**
//* @file Boundary.cs
//* @brief Boundaryクラスの実装
//* @author 倉　和規
//* @date 5/5
//*
//* @details 
//* @note 
//*/

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Boundary : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {
//        GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 1.0f);
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        if (other.gameObject.tag == "Gage") 
//        {
//            other.gameObject.transform.RotateAround(
//                other.transform.position,
//                other.transform.right,
//                180.0f
//                );
//        }

//        if (other.gameObject.tag == "Screen")
//        {
//            other.gameObject.transform.RotateAround(
//                other.transform.position,
//                other.transform.right,
//                180.0f
//                );

//            Vector3 ZeroVec = -other.transform.position;
//            ZeroVec = ZeroVec.normalized;

//        }

//        if (other.gameObject.tag == "ThatScreen")
//        {
//            other.gameObject.transform.RotateAround(
//                this.transform.position,
//                this.transform.right,
//                180.0f
//                );
//        }
//    }
//}

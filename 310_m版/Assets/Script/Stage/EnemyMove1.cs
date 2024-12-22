//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyMove1 : MonoBehaviour
//{
//    //インスペクターで設定する
//    #region
//    [Header("移動速度")] public float speed;                        // 移動速度
//    //[Header("重力")] public float gravity;                        // 重力
//    [Header("画面外でも行動する")] public bool nonVisibleAct;       // 画面外でも行動するフラグ
//    #endregion

//    //プライベート変数
//    #region
//    private Rigidbody rb = null;
//    private MeshRenderer mr = null;
//    private bool rightTleftF = false; // trueの時右に進み、falseの時左に進む
//    #endregion

//    // Start is called before the first frame update
//    void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//        mr = GetComponent<MeshRenderer>();
//    }

//    void FixedUpdate()
//    {
//        // 画面内にいたら行動
//        if (mr.isVisible || nonVisibleAct)
//        {
//            if (rightTleftF)
//            {
//                rb.velocity = new Vector3(speed, rb.velocity.y, 0);
//            }
//            else
//            {
//                rb.velocity = new Vector3(-speed, rb.velocity.y, 0);
//            }
//        }
//        else
//        {
//            rb.Sleep();
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (mr.isVisible || nonVisibleAct)
//        {
//            Debug.Log("画面に見えている");
//        }
//        else
//        {

//        }
//    }

//    private void OnCollisionEnter(Collision collision)
//    {
//        if (rightTleftF)
//        {
//            rightTleftF = false;
//        }
//        else
//        {
//            rightTleftF = true;
//        }
//    }
//}

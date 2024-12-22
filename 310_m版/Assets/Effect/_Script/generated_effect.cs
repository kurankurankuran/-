using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generated_effect : MonoBehaviour
{
    [Header("エフェクトの種類のプレハブ")]
    [SerializeField] public GameObject particleObject;

    //private void OnTriigerEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "DamageObj") //Objectタグの付いたゲームオブジェクトと衝突したか判別
    //    {
    //        Instantiate(particleObject, (this.transform.position + collision.transform.position) / 2, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
    //        //Destroy(this.gameObject); //衝突したゲームオブジェクトを削除

    //    }
    //}


   
    //　生成タイミングを他のスクリプトで追記する 
    public void generate_Effect_Hit(Vector3 pos)
    {
        Instantiate(particleObject, pos, Quaternion.identity); //パーティクル用ゲームオブジェクト生成

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player") //Objectタグの付いたゲームオブジェクトと衝突したか判別
    //    {
    //        Instantiate(particleObject, (this.transform.position + other.transform.position) / 2, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
    //                                                                                                                        //Destroy(this.gameObject); //衝突したゲームオブジェクトを削除

    //    }
    //}


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generated_particle : MonoBehaviour
{
    [SerializeField] public GameObject particleObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "DamageObj") //Objectタグの付いたゲームオブジェクトと衝突したか判別
        {
            Instantiate(particleObject, this.transform.position, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
            Destroy(this.gameObject); //衝突したゲームオブジェクトを削除
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

}

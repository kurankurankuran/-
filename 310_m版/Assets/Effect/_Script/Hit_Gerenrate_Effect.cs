using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Gerenrate_Effect : MonoBehaviour
{
    [SerializeField] public GameObject particleObject;

    [Header("当たり判定がTriggerならtrue")]
    [SerializeField] private bool bTrigger = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!bTrigger)
        {
            if (collision.transform.tag == "Player")
            {

                GameObject Particle = Instantiate(particleObject, this.transform.position + (collision.transform.position - this.transform.position) / 2, Quaternion.identity); //パーティクル用ゲームオブジェクト生成

                Particle.transform.parent = GameObject.FindGameObjectWithTag("Root").transform/*this.transform*/;


            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (bTrigger)
        {
            if (other.tag == "Player")
            {

                GameObject Particle = Instantiate(particleObject, this.transform.position + (other.transform.position - this.transform.position) / 2, Quaternion.identity); //パーティクル用ゲームオブジェクト生成

                Particle.transform.parent = GameObject.FindGameObjectWithTag("Root").transform/*this.transform*/;


            }
        }
    }
}

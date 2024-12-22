using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisCharge_Generate_Effect : MonoBehaviour
{
    [SerializeField] public GameObject particleObject;

    GameObject Particle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generate_Effect()
    {
        Particle = Instantiate(particleObject, this.transform.position, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
        Particle.transform.parent = transform;
    }
}

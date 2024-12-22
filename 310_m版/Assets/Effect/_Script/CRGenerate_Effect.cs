using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRGenerate_Effect : MonoBehaviour
{
    [SerializeField] public GameObject particleObject1;

    [SerializeField] public GameObject particleObject2;

    GameObject Particle1;
    GameObject Particle2;


    private int Enter;

    bool Generate;

    // Start is called before the first frame update
    void Start()
    {
        Enter = 0;
        Generate = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Generate)
        {
            if (Enter > 0)
            {
                if (Input.GetKeyDown(KeyCode.K))
                {
                    Particle1 = Instantiate(particleObject1, this.transform.position, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
                    Particle1.transform.parent = transform;
                    Generate = false;
                }
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.K))
            {
                Destroy(Particle1);

                Generate = true;

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Foot")
        {

        
            Enter++;
        }
       

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Foot")
        {

            Enter--;
        }
    }

    public void DestroyParticle()
    {
        Destroy(Particle1);
    }

    public void GenerateParticle()
    {
        Particle2 = Instantiate(particleObject2, this.transform.position, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
        Particle2.transform.parent = transform;
    }
}

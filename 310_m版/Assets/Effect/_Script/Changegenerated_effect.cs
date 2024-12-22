using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changegenerated_effect : MonoBehaviour
{
    [Header("切り替わった瞬間のエフェクト")]
    [SerializeField] public GameObject particleObject1;

    [Header("透明中のエフェクト")]
    [SerializeField] public GameObject particleObject2;

    Vector3 Vec;

    [Header("透明中のエフェクトを表示するかどうか(trueで表示)")]
    [SerializeField]
    private bool bInvEffect = true; 
    
    void Start()
    {
        Vec = new Vector3(transform.position.x, 0.0f, transform.position.z);
        Vec = Vec.normalized / 3.0f;
        Vec = new Vector3(
                Vec.x,
                Vec.y - 0.3f,
                Vec.z);

        if (bInvEffect)
        {
            if (transform.GetComponent<Collider>().isTrigger)
            {
                GameObject Particle = Instantiate(particleObject2, this.transform.position - Vec, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
                Particle.transform.parent = this.transform;

            }
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Gage") //Objectタグの付いたゲームオブジェクトと衝突したか判別
        {

            if (/*transform.childCount > 0*/transform.Find("eff_pfb_off(Clone)") != null)
            {
                Destroy(transform.Find("eff_pfb_off(Clone)").gameObject);

            }
            else
            {
                if (bInvEffect)
                {
                    GameObject Particle2 = Instantiate(particleObject2, this.transform.position - Vec, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
                    Particle2.transform.parent = this.transform;
                }
            }

            GameObject Particle1 = Instantiate(particleObject1, this.transform.position - Vec, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
            Particle1.transform.parent = this.transform;

        }
    }

    public void PlayEffect()
    {
        GameObject Particle = Instantiate(particleObject1, this.transform.position, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
        Particle.transform.parent = transform;
    }
}

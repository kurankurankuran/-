using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [Header("SoulObjをD&D")]
    [SerializeField]
    public List<GameObject> SoulList = new List<GameObject>();

    [Header("ResPlayerをD&D")]
    [SerializeField]
    GameObject ResObj;

    [Header("Effect(hatena)をD&D")]
    [SerializeField]
    GameObject Effect;

    [Header("DischargeをD&D")]
    [SerializeField]
    GameObject Effect2;

    private GameObject particle;

    public bool ResPornFlg { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        ResPornFlg = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ResPornFlg)
        {
            int PutSoulCnt = 0; 
        
            for(int i = 0; i < SoulList.Count; ++i)
            {
                if (!SoulList[i].GetComponent<Soul>().bPut) break;

                PutSoulCnt++;
            }

            if (SoulList.Count <= PutSoulCnt)
            {
                //particle = Instantiate(Effect2, transform.position, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
                //particle.transform.parent = this.transform;
                //ResObj.transform.position = this.transform.position;

                
                //Effect.SetActive(true);

                ResPornFlg = true;
            }
        }




    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.tag == "Player")
        {
            if (ResPornFlg && ResObj.transform.position != this.transform.position)
            {

                particle = Instantiate(Effect2, transform.position, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
                particle.transform.parent = this.transform;
                ResObj.transform.position = this.transform.position;

                Effect.SetActive(true);

                GAudio.SaveSEPlay();
            }

          
        }
    }
}

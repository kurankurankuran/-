using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
//using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{

    //　プレイヤーのMaxHP
    [SerializeField]
    private int maxHp;
    //　プレイヤーの霊力
    [SerializeField]
    private int hp;
    ////　プレイヤーの攻撃力
    //[SerializeField]
    //private int attackPower = 1;
    //private Enemy enemy;
    //　HP表示用UI
    [SerializeField]
    private GameObject HPUI;
    //　HP表示用スライダー
    private Slider hpSlider;

    //[Header("Hp０時の飛ぶシーン番号")]
    //[SerializeField]
    //private int Number;

    //[Header("世界判断フラグ(tureでこの世)")]
    //[SerializeField]
    //private bool bThisorThat;

    [Header("あの世での霊力間隔")]
    [SerializeField]
    private int HealTime = 60;

    [Header("霊力量")]
    [SerializeField]
    private int HealValue = 2;

    // 回復カウント用
    private int HealCnt;


    [Header("この世で魂を持った時霊力減る間隔")]
    [SerializeField]
    private int DelTime;

    [Header("この世で魂を持った時霊力減る量")]
    [SerializeField]
    private int DelHp = 1;

    // 減るカウント用
    private int DelCnt;

    // 持ってる魂リスト
    private static List<GameObject> SoulList = new List<GameObject>();

    // 無敵フラグ
    private bool InvFlg;

    // 無敵時間カウント用
    private int InvCnt;

    // 無敵時間
    private int InvTime;


    ////接地数
    //private int enterNum = 0;

    void Start()
    {
        SoulList.Clear();
        //enemy = GetComponent<Enemy>();
        hp = maxHp;
        hpSlider = HPUI.transform.Find("HPBar").GetComponent<Slider>();
        hpSlider.value = 1f;
        HealCnt = 0;
        DelCnt = 0;
        InvFlg = false;
        InvCnt = 0;
        InvTime = 0;
    }

    private void Update()
    {
        if (!Pause.GetOnoffflg())
        {
            if (!Tutorial.IsDoing())
            {

                if (SoulList.Count > 0)
                {
                    //Debug.Log(hp);
                    HealCnt = 0;
                    DelCnt++;
                    if (DelCnt > DelTime)
                    {
                        if (!InvFlg)
                        {


                            hp -= DelHp;
                            if (hp < 0)
                            {
                                hp = 0;
                            }

                            UpdateHPValue();
                            DelCnt = 0;

                            // 仮置き
                            for (int i = 0; i < SoulList.Count; ++i)
                            {
                                if (!SoulList[i].gameObject.GetComponent<Soul>().bRot)
                                {

                                    SoulList.Remove(SoulList[i].gameObject);
                                }
                            }
                        }

                    }
                }
                else
                {
                    DelCnt = 0;
                    if (hp < maxHp)
                    {
                        HealCnt++;
                        if (HealCnt > HealTime)
                        {
                            //hp++;

                            hp += HealValue;

                            UpdateHPValue();
                            HealCnt = 0;
                        }
                    }
                }


                if (InvFlg)
                {
                    //Debug.Log("InvTime");

                    InvCnt++;
                    if (InvCnt > InvTime)
                    {
                        InvFlg = false;
                        InvCnt = 0;
                    }
                }
            }
        }
    }

    
    public void SetHp(int hp)
    {
        if (!InvFlg)
        {
            this.hp = hp;

            //　HP表示用UIのアップデート
            UpdateHPValue();

            if (hp <= 0)
            {
                GameObject.Find("AudioController").GetComponent<GAudio>().HPBarSEStop();
                //　HP表示用UIを非表示にする
                //HideStatusUI();
            }
        }
    }

    public int GetHp()
    {
        return hp;
    }

    public int GetMaxHp()
    {
        return maxHp;
    }

    //　死んだらHPUIを非表示にする
    public void HideStatusUI()
    {
        HPUI.SetActive(false);
    }

    public void UpdateHPValue()
    {
        hpSlider.value = (float)GetHp() / (float)GetMaxHp();
    }

    public void SetInvFlg(bool bInv,int nInv)
    {
        InvFlg = bInv;
        InvTime = nInv;
    }

    private void OnTriggerEnter(Collider other)
    {
       

        //if (other.tag == "Screen")
        //{
        //    bThisorThat = true;
        //}
        //else if(other.tag == "ThatScreen")
        //{
        //    bThisorThat = false;
        //}

        if (other.tag == "Soul")
        {
            if (!other.gameObject.GetComponent<Soul>().bPut && other.gameObject.GetComponent<Soul>().bTouch)
            {
                // 持ってる魂リスト
                bool bSkip = false;
                for (int i = 0; i < SoulList.Count; ++i)
                {
                    if (SoulList[i].gameObject.name == other.gameObject.name)
                    {
                        
                        bSkip = true;
                    }


                }

                if (!bSkip)
                {
                    
                    SoulList.Add(other.gameObject);
                }
            }
        }

        if(other.tag == "Goal")
        {
            //if (!bThisorThat)
            //{
                for (int i = 0; i < SoulList.Count; ++i)
                {
                    if (SoulList[i].gameObject.name == other.gameObject.GetComponent<PutSoul>().Soul.name)
                    {
                        
                        SoulList.Remove(SoulList[i].gameObject);
                    }
                }
            //}

        }
    }

    public static List<GameObject> GetSoulList()
    {
        return SoulList;
    }

}
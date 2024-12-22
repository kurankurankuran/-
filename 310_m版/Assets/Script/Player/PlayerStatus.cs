using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
//using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{

    //�@�v���C���[��MaxHP
    [SerializeField]
    private int maxHp;
    //�@�v���C���[�̗��
    [SerializeField]
    private int hp;
    ////�@�v���C���[�̍U����
    //[SerializeField]
    //private int attackPower = 1;
    //private Enemy enemy;
    //�@HP�\���pUI
    [SerializeField]
    private GameObject HPUI;
    //�@HP�\���p�X���C�_�[
    private Slider hpSlider;

    //[Header("Hp�O���̔�ԃV�[���ԍ�")]
    //[SerializeField]
    //private int Number;

    //[Header("���E���f�t���O(ture�ł��̐�)")]
    //[SerializeField]
    //private bool bThisorThat;

    [Header("���̐��ł̗�͊Ԋu")]
    [SerializeField]
    private int HealTime = 60;

    [Header("��͗�")]
    [SerializeField]
    private int HealValue = 2;

    // �񕜃J�E���g�p
    private int HealCnt;


    [Header("���̐��ō�������������͌���Ԋu")]
    [SerializeField]
    private int DelTime;

    [Header("���̐��ō�������������͌����")]
    [SerializeField]
    private int DelHp = 1;

    // ����J�E���g�p
    private int DelCnt;

    // �����Ă鍰���X�g
    private static List<GameObject> SoulList = new List<GameObject>();

    // ���G�t���O
    private bool InvFlg;

    // ���G���ԃJ�E���g�p
    private int InvCnt;

    // ���G����
    private int InvTime;


    ////�ڒn��
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

                            // ���u��
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

            //�@HP�\���pUI�̃A�b�v�f�[�g
            UpdateHPValue();

            if (hp <= 0)
            {
                GameObject.Find("AudioController").GetComponent<GAudio>().HPBarSEStop();
                //�@HP�\���pUI���\���ɂ���
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

    //�@���񂾂�HPUI���\���ɂ���
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
                // �����Ă鍰���X�g
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
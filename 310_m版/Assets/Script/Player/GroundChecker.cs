using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
public class GroundChecker : MonoBehaviour
{

    //接地した場合の処理
    public UnityEvent OnEnterGround;
    //地面から離れた場合の処理
    public UnityEvent OnExitGround;
    //接地数
    private int enterNum = 0;

    //! ダークソウルオブジェクト格納用
    private List<GameObject> darkSoulList = new List<GameObject>();

    //private void Update()
    //{
    //    if (darkSoulList.Count > 0)
    //    {
    //        Debug.Log(darkSoulList.Count);
    //        for (int i = 0; i < darkSoulList.Count; ++i)
    //        {
    //            if (darkSoulList[i] == null)
    //            {
                   
    //                enterNum--;
    //                darkSoulList.Remove(darkSoulList[i]);

    //                if (enterNum <= 0) 
    //                    OnExitGround.Invoke();
    //                continue;
    //            }
               
    //        }
    //    }
    //}


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag != "Player")
        {
            if (collision.tag != "Screen" && collision.tag != "ThatScreen" && collision.tag != "Gage")
            {
                if (!collision.isTrigger)
                {

                    enterNum++;
                    OnEnterGround.Invoke();
                }

                //if (collision.gameObject.name == "eff_pfb_Darksoul")
                //{
                //    var render = collision.GetComponent<Renderer>();

                //    if (render.enabled )
                //    {
                //        enterNum++;
                //        darkSoulList.Add(collision.gameObject);
                //    }
                    
                //}
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag != "Player")
        {
            if (collision.tag != "Screen" && collision.tag != "ThatScreen" && collision.tag != "Gage")
            {
                if (!collision.isTrigger)
                {
                    enterNum--;
                    if (enterNum <= 0)
                    {
                        OnExitGround.Invoke();
                    }
                }
            }
        }
    }

    public void DelentetNum()
    {
        enterNum--;
    }
    public void PlusentetNum()
    {
        enterNum++;
    }


    public int GetEnterNum()
    {
        return enterNum;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunEffect : MonoBehaviour
{
    PlayerMove PlayerMoveScript;

    TestJump jump;

    public GameObject runeffect;

    // Start is called before the first frame update
    void Start()
    {
        PlayerMoveScript = GameObject.Find("miko_fin").GetComponent<PlayerMove>();

        jump = GameObject.Find("miko_fin").GetComponent<TestJump>();

        //GameObject runeffect = GameObject.Find("miko_fin/RunEffect").transform.Find("RunEffect").gameObject;
        //GameObject runeffect = this.transform.gameObject.Find("miko_fin/RunEffect");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMoveScript.GetMoveFlg())
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetAxisRaw("Con_Horizontal") < 0 || Input.GetAxisRaw("Con_Horizontal") > 0)
            {
              
                runeffect.SetActive(true);
            }
            else
            {

                runeffect.SetActive(false);
            }
        }
        else
        {
            runeffect.SetActive(false);
        }

        if(!jump.OnGround)
        {
            runeffect.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulRelease : MonoBehaviour
{
    private List<GameObject> SoulList;

    public static bool bRelease { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        bRelease = false;
        SoulList = PlayerStatus.GetSoulList();
    }

    // Update is called once per frame
    void Update()
    {

        if (bRelease)
        {
            bRelease = false;
        }
        if (Input.GetKeyDown(KeyCode.R)|| Input.GetButtonDown("Con_SoulRelease"))
        {
            bRelease = true;
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

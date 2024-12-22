using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingColorChange : MonoBehaviour
{
    public int TitleColor;
    private int nCount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "HitRing")
        {
            Debug.Log("Hit");
            nCount++;
            if (nCount == 2)
            {
                switch (TitleColor)
                {
                    case 0:
                        TitleColor = 1;
                        break;
                    case 1:
                        TitleColor = 0;
                        break;
                    default:
                        break;

                }
                nCount = 0;
            }
        }
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        TitleColor = 0;
        nCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(TitleColor == 1)
        {
            Debug.Log("TitleColor = 1");
        }
        
    }

    public int GetTitleColor()
    {
        return TitleColor;
    }
    
}

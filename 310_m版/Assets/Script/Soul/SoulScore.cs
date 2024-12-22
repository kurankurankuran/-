
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulScore : MonoBehaviour
{
   
    public GameObject[] SoulIconsON;
    public GameObject[] SoulIconsOff;

    private float X1,Y1,Z1;
    private float X2, Y2, Z2;
    private float X3, Y3, Z3;
    public bool[] ScaleON;

    private float AX1, AY1, AZ1;
    private float AX2, AY2, AZ2;
    private float AX3, AY3, AZ3;
    public bool[] Scaleoff;

    void Start()
    {
        ScaleON[0] = false;
        ScaleON[1] = false;
        ScaleON[2] = false;

        Scaleoff[0] = false;
        Scaleoff[1] = false;
        Scaleoff[2] = false;


        X1 = 1.0f;
        Y1 = 1.0f;
        Z1 = 1.0f;

        X2 = 1.0f;
        Y2 = 1.0f;
        Z2 = 1.0f;

        X3 = 1.0f;
        Y3 = 1.0f;
        Z3 = 1.0f;

        //====================================================

        AX1 = 2.0f;
        AY1 = 2.0f;
        AZ1 = 2.0f;

        AX2 = 2.0f;
        AY2 = 2.0f;
        AZ2 = 2.0f;

        AX3 = 2.0f;
        AY3 = 2.0f;
        AZ3 = 2.0f;


    }

    // Update is called once per frame
    void Update()
    {
        if (ScaleON[0] == true)
        {
            Scale1();
        }
        if (ScaleON[1] == true)
        {
            Scale2();

        }
        if (ScaleON[2] == true)
        {
            Scale3();
        }

    }

    private void Scale1()
    {
        if (X1 <= 2.0f)
        {

            X1 += 0.1f;
            Y1 += 0.1f; 
            Z1 += 0.1f; 
            SoulIconsOff[0].transform.localScale = new Vector3(X1, Y1, Z1);

        }

        if (X1 >= 2.0f)
        {
            
            SoulIconsON[0].SetActive(true);
            SoulIconsOff[0].SetActive(false);

            Scaleoff[0] = true;

        }


        if (Scaleoff[0] == true)
        {
            if (AX1 >= 1.0f)
            {
                AX1 -= 0.1f; 
                AY1 -= 0.1f;
                AZ1 -= 0.1f; 
                SoulIconsON[0].transform.localScale = new Vector3(AX1, AY1, AZ1);
            }

            if (AX1 <= 1.0f)
            {
                ScaleON[0] = false;

            }
        }


    }
    private void Scale2()
    {
        if (X2 <= 2.0f)
        {

            X2 += 0.1f;
            Y2 += 0.1f;
            Z2 += 0.1f;
            SoulIconsOff[1].transform.localScale = new Vector3(X2, Y2, Z2);

        }

        if (X2 >= 2.0f)
        {
            SoulIconsON[1].SetActive(true);
            SoulIconsOff[1].SetActive(false);
            Scaleoff[1] = true;


        }
        if (Scaleoff[1] == true)
        {
            if (AX2 >= 1.0f)
            {
                AX2 -= 0.1f;
                AY2 -= 0.1f;
                AZ2 -= 0.1f;
                SoulIconsON[1].transform.localScale = new Vector3(AX2, AY2, AZ2);
            }

            if (AX2 <= 1.0f)
            {
                ScaleON[1] = false;

            }
        }

    }
    private void Scale3()
    {
        if (X3 <= 2.0f)
        {

            X3 += 0.1f;
            Y3 += 0.1f;
            Z3 += 0.1f;
            SoulIconsOff[2].transform.localScale = new Vector3(X3, Y3, Z3);

        }

        if (X3 >= 2.0f)
        {
            SoulIconsON[2].SetActive(true);
            SoulIconsOff[2].SetActive(false);
            Scaleoff[2] = true;


        }
        if (Scaleoff[2] == true)
        {
            if (AX3 >= 1.0f)
            {
                AX3 -= 0.1f;
                AY3 -= 0.1f;
                AZ3 -= 0.1f;
                SoulIconsON[2].transform.localScale = new Vector3(AX3, AY3, AZ3);
            }

            if (AX3 <= 1.0f)
            {
                ScaleON[2] = false;

            }
        }



    }

    public void ScaleON1()
    {
        ScaleON[0] = true;
       

    }
    public void ScaleON2()
    {
        ScaleON[1] = true;
        

    }
    public void ScaleON3()
    {
        ScaleON[2] = true;
        

    }



}
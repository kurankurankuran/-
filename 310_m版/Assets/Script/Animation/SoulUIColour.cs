using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoulUIColour : MonoBehaviour
{
    public GameObject[] Soul;

    void Start()
    {
       
       

    }


    // Update is called once per frame
    void Update()
    {

        //if (Soul[0].GetComponent<Soul>().bPut)
        //{
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject.Find("SoullconPanel").GetComponent<SoulScore>().ScaleON1();



        }


        //if (Soul[1].GetComponent<Soul>().bPut)
        //{
        if (Input.GetKeyDown(KeyCode.X))
        {



            GameObject.Find("SoullconPanel").GetComponent<SoulScore>().ScaleON2();

        }

        //if (Soul[2].GetComponent<Soul>().bPut)
        //{
        if (Input.GetKeyDown(KeyCode.C))
        {



            GameObject.Find("SoullconPanel").GetComponent<SoulScore>().ScaleON3();

        }
    }

   

}

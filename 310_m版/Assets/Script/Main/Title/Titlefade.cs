using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titlefade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Con_Ok"))//if•¶’†‚ÌCon_Ok’Ç‹L
        {
            //GameObject.Find("Canvas").GetComponent<LoadScene>().StartLoad(1);
            LoadScene.StartLoad(1);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchExplanation : MonoBehaviour
{
    public Image image;

    public Sprite sprite1;
    public Sprite sprite2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var controllerNames = Input.GetJoystickNames();

        int currentConnectionCount = 0;

        for (int i = 0; i < controllerNames.Length; i++)
        {
            currentConnectionCount++;
            //if (controllerNames[i] != "")
            //{
            //    currentConnectionCount++;
            //}
        }

        if (/*controllerNames[0].Length*/currentConnectionCount == 0)
        {
            //Debug.Log("pp");
            image = GetComponent<Image>();
            image.sprite = sprite1;
        }
        else
        {
            image = GetComponent<Image>();
            image.sprite = sprite2;
        }

        if(Pause.GetOnoffflg())
        {
            image.enabled = false;
        }
        else
        {
            image.enabled = true;
        }
        
        
    }
}

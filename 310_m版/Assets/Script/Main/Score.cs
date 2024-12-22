using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public static Text txt;				
	public static float x = 3;
    public static float Num;
    void Start()
    {
        txt = GameObject.Find("ScoreText").GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Score.txt.text = "ç∞    " + Score.x + "/" + Num;
    }
}

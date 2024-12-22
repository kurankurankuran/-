//**************************************************************:
// 機能：
// ・選択シーンの音量調整
//**************************************************************：
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAudio : MonoBehaviour
{
    //BGM
    public AudioSource AudioBGM;//http://www.hmix.net/music_gallery/image/asian.htm
    public AudioSource AudioYBGM;
 
    //SE
    public static AudioSource AudioSE;////https://maou.audio/category/se/
    public AudioSource AudioSSE;

    // Start is called before the first frame update
    void Start()
    {
        AudioSE = GameObject.Find("SE").GetComponent<AudioSource>();
        AudioSSE.volume = AudioController.Volume;
        //音量＝AudioControllerのVolume
        AudioBGM.volume = AudioController.Volume / 2;
        AudioYBGM.volume = AudioController.Volume;
        //AudioSE.volume = AudioController.Volume;

    }


    //SEを流す
    public static void SEPlay()
    {
        AudioSE.Play();

    }
    public void SSEPlay()
    {
        AudioSSE.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

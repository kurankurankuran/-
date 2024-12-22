//**************************************************************:
// 機能：
// ・音量調整・SE/BGMを流す
//**************************************************************：
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioController : MonoBehaviour
{
    //音量調整棒
    public Slider Slider;
    //BGM
    public AudioSource AudioBGM; //http://www.hmix.net/music_gallery/image/asian.htm
    //SE
    public AudioSource AudioSE;//https://maou.audio/category/se/
    //SE
    public AudioSource AudioSSE;
    //SE
    public AudioSource AudioKSE;
    //SE
    public AudioSource AudioJSE;

    //音量
    public static float Volume = 0.5f;
    //最初の音量
    public static float SVolume = 0.5f;
    // 制御可能・不可能切替
    private bool bAudio;

    //音量調整
    public void AudioControll()
    {

        //音量＝棒の値
        Volume = Slider.value;
        SVolume = Volume;
        AudioBGM.volume = Slider.value;

        AudioSE.volume = Slider.value;
        AudioSSE.volume = Slider.value;
        AudioKSE.volume = Slider.value;
        AudioJSE.volume = Slider.value * 2.0f;

    }

    //SEを流す
    public void SEPlay()
    {
        AudioSE.Play();

    }

    //public void SwitchAudioControll()
    //{
    //    if(bAudio)
    //    {
    //        bAudio = false;
    //    }
    //    else
    //    {
    //        bAudio = true;
    //    }
    //}

    // Start is called before the first frame update
    //最初の音量
    void Start()
    {
        Slider.value = SVolume;
        AudioBGM.volume = SVolume;


        AudioSE.volume = SVolume;
        AudioSSE.volume = SVolume;
        AudioKSE.volume = SVolume;
        AudioJSE.volume = SVolume;

        bAudio = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(bAudio)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetAxisRaw("Con_Horizontal") > 0 || Input.GetAxisRaw("D_pad_H") >= 1) 
            {
                AudioSSE.Play();
                if (Slider.value < 1.0f)
                {
                    Slider.value += 0.01f;
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetAxisRaw("Con_Horizontal") < 0 || Input.GetAxisRaw("D_pad_H") <= -1)
            {
                AudioSSE.Play();

                if (Slider.value > -1.0f)
                {
                    Slider.value -= 0.01f;
                }
            }
        }
        
    }

    public void SwitchAudioControll(bool audio)
    {
        bAudio = audio;

        //if (bAudio)
        //{
        //    Debug.Log("bAudio:on");
        //}
        //else
        //{
        //    Debug.Log("bAudio:off");
        //}
    }
}


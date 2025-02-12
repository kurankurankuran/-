//**************************************************************:
// @\F
// E¹Ê²®ESE/BGMð¬·
//**************************************************************F
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioController : MonoBehaviour
{
    //¹Ê²®_
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

    //¹Ê
    public static float Volume = 0.5f;
    //ÅÌ¹Ê
    public static float SVolume = 0.5f;
    // §äÂ\EsÂ\ØÖ
    private bool bAudio;

    //¹Ê²®
    public void AudioControll()
    {

        //¹Ê_Ìl
        Volume = Slider.value;
        SVolume = Volume;
        AudioBGM.volume = Slider.value;

        AudioSE.volume = Slider.value;
        AudioSSE.volume = Slider.value;
        AudioKSE.volume = Slider.value;
        AudioJSE.volume = Slider.value * 2.0f;

    }

    //SEð¬·
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
    //ÅÌ¹Ê
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


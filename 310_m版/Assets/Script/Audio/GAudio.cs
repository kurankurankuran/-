//**************************************************************:
// 機能：
// ・ゲームシーンの音量調整
//**************************************************************：
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAudio : MonoBehaviour
{
    //BGM
    [SerializeField]
    private AudioSource AudioBGM;//http://www.hmix.net/music_gallery/image/asian.htm
    //SE
    [SerializeField]
    private AudioSource JumpSE;//https://maou.audio/category/se/

    [SerializeField]
    private AudioSource SoulGetSE;//https://maou.audio/category/se/

    [SerializeField]
    private AudioSource HPBarSE;//https://maou.audio/category/se/

    [SerializeField]
    private AudioSource OverSE;//https://maou.audio/category/se/

    [SerializeField]
    private AudioSource ClearSE;//https://pocket-se.info/archives/tag/%E4%B8%89%E5%91%B3%E7%B7%9A/

    [SerializeField]
    private AudioSource SoulPutSE;//https://maou.audio/category/se/

    [SerializeField]
    private AudioSource DamageSE; // https://maou.audio/se_battle14/

    [SerializeField]
    private AudioSource DamageSE2; //https://maou.audio/se_battle05/ 

    [SerializeField]
    private AudioSource StartJingle;//https://maou.audio/se_jingle11/

    [SerializeField]
    private AudioSource LostSoulSE;//https://maou.audio/se_onepoint28/

   

    //SE
    public AudioSource AudioSSE;
    //SE
    public AudioSource AudioKSE;
    //SE
    public AudioSource AudioJSE;
    //SE
    public AudioSource AudioPSE;


  

    //[SerializeField]
    //private static AudioSource DistortionBGM;

    [SerializeField]
    private AudioSource DistortionBGM;

   
    private static AudioSource SaveSE;//https://maou.audio/category/se/se-onepoint/page/3/

    // Start is called before the first frame update
    void Start()
    {
        SaveSE =transform.Find("SaveSE").GetComponent<AudioSource>(); 
        //DistortionBGM = GameObject.Find("DistortionBGM").GetComponent<AudioSource>();

        //音量＝AudioControllerのVolume
        AudioBGM.volume = AudioController.Volume / 4;
        JumpSE.volume = AudioController.Volume;
        SoulGetSE.volume = AudioController.Volume;
        SoulPutSE.volume = AudioController.Volume;
        HPBarSE.volume = AudioController.Volume;
        OverSE.volume = AudioController.Volume;
        ClearSE.volume = AudioController.Volume;
        DamageSE.volume = AudioController.Volume * 2;
        DamageSE2.volume = AudioController.Volume;
        StartJingle.volume = AudioController.Volume;
        DistortionBGM.volume = AudioController.Volume;
        AudioSSE.volume = AudioController.Volume;
        AudioKSE.volume = AudioController.Volume;
        AudioJSE.volume = AudioController.Volume;
        AudioPSE.volume = AudioController.Volume;
        SaveSE.volume = AudioController.Volume;
    }


    //何のSEを流す
    //GameObject.Find("AudioController").GetComponent<GAudio>().SEPlay();
    public void JumpSEPlay()
    {
        JumpSE.Play();

    }
    public void SoulGetSEPlay()
    {
        SoulGetSE.Play();

    }
    public void SoulPutSEPlay()
    {
        SoulPutSE.Play();

    }
    public void HPBarSEPlay()
    {
        HPBarSE.Play();

    }
    public void HPBarSEStop()
    {
        HPBarSE.Stop();

    }

    public void OverSEPlay()
    {

        OverSE.Play();

    }
    public void ClearSEPlay()
    {

        ClearSE.Play();

    }

    public void DamageSEPlay()
    {

        DamageSE.Play();

    }

    public void DamageSE2Play()
    {

        DamageSE2.Play();

    }

    public void StartJinglePlay()
    {

        StartJingle.Play();

    }
    public void LostSoulSEPlay()
    {

        LostSoulSE.Play();

    }

    public  void distSEPlay()
    {
        DistortionBGM.Play();
      
    }

    public static void SaveSEPlay()
    {
        SaveSE.Play();
    }


    //// Update is called once per frame
    //void Update()
    //{

    //}

}




//**************************************************************:
// �@�\�F
// �E�I���V�[���̉��ʒ���
//**************************************************************�F
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
        //���ʁ�AudioController��Volume
        AudioBGM.volume = AudioController.Volume / 2;
        AudioYBGM.volume = AudioController.Volume;
        //AudioSE.volume = AudioController.Volume;

    }


    //SE�𗬂�
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

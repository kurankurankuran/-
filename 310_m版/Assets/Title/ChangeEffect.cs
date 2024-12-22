// タイトルシーン菊・彼岸花変化用
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEffect : MonoBehaviour
{
    //!菊のGameObject探索用
    private GameObject go_kiku;
    //!菊のParticleSystem
    private ParticleSystem kiku;
    //!彼岸花のGameObject探索用
    private GameObject go_higan;
    //!彼岸花のParticleSystem
    private ParticleSystem higan;
    //!
    private ParticleSystem.MainModule kiku_main;
    //!
    private ParticleSystem.MainModule higan_main;
    //!
    public RingColorChange rcc;
    //!
    private int tc;



    void Start()
    {
        go_kiku = GameObject.Find("eff_kiku");
        kiku = go_kiku.GetComponent<ParticleSystem>();
        kiku_main = kiku.main;
        go_higan = GameObject.Find("eff_higanbana");
        higan = go_higan.GetComponent<ParticleSystem>();
        higan_main = higan.main;

        tc = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tc = rcc.GetTitleColor();
        if (tc == 0)
        {
            kiku.Play();
            higan.Stop();
        }
        if(tc == 1)
        {
            kiku.Stop();
            higan.Play();
        }

        //switch(rcc.TitleColor)
        //{
        //    case 0:
        //        //kiku_main.loop = true;
        //        kiku.Play();
        //        //higan_main.loop = false;
        //        higan.Stop();
        //        break;
        //    case 1:
        //        //kiku_main.loop = false;
        //        kiku.Stop();
        //        //higan_main.loop = true;
        //        higan.Play();
        //        break;
        //    default:
        //        break;
        //}
    }
}

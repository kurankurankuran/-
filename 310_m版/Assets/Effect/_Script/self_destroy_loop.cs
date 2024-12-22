using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class self_destroy_loop : MonoBehaviour
{
    ParticleSystem particle;
    

    void Start()
    {
        
    }

    void Update()
    {


        if (!GetComponent<Collider>().isTrigger)
        {
            particle = this.GetComponent<ParticleSystem>();



            ParticleSystem.MainModule main = particle.main;
            main.loop = false;


            if (particle.isStopped) //
            {
                Destroy(this.gameObject);//
            }
        }
    }
    
        
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play_effect : MonoBehaviour
{
    private ParticleSystem par;

    // Start is called before the first frame update
    void Start()
    {
        par = GetComponent<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    par.Play();
        //    Debug.Log("playOnAwake");
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            par.Play();
        }
    }
}

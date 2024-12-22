using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FealdParticle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void FixedUpdate()
    {
        if (Input.GetAxis("Horizontal") < 0 || Input.GetAxisRaw("Con_Horizontal") < 0)
        {
            transform.rotation = new Quaternion(
                Input.GetAxis("Horizontal") * -45,
                transform.rotation.y,
                transform.rotation.z,
                transform.rotation.w);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

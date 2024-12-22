using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOnCubeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Gage")
        {

            other.GetComponent<CameraActive>().CameraObj.SetActive(true);
            other.GetComponent<CameraActive>().ThatCameraObj.SetActive(true);
        }
    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Gage")
        {

            other.GetComponent<CameraActive>().CameraObj.SetActive(false);
            other.GetComponent<CameraActive>().ThatCameraObj.SetActive(false);
        }

    }
}
